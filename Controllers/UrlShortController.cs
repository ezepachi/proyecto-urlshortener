using Microsoft.AspNetCore.Mvc;
using Proyecto.Data.Implementations;
using proyecto_urlshortener.Entities;

namespace proyecto_urlshortener.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UrlShortController : Controller
    {
        private readonly UrlShortenerContext _context;

        public UrlShortController(UrlShortenerContext context)
        {
            _context = context;
        }

        //Manejamos la solicitud POST y acortamos URL
        //Aagregar que ingrese categoria
        [HttpPost]
        public IActionResult ShortenUrl(string url)
        {
            //Generamos la logica para cortar el URL
            string shortCode = GeneratedShortCode( url);
            var urlMapping = new URLMapping
            {
                LongUrl = url,
                ShortUrl = shortCode
            };
            _context.URLMappings.Add(urlMapping);
            _context.SaveChanges();
            return Ok(urlMapping.shortCode);
        }

        private string GeneratedShortCode(string url)
        {
            const string charsTotal = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            char[] urlShort = new char[6];
            for (int i = 0; i < 6; i++)
            {
                urlShort[i] = charsTotal[random.Next(charsTotal.Length)];
            }
            return new string(urlShort);
        }

        //Tomar url corta, buscarla y redirigir a url larga
        //Manejar la categoria tambien
        [HttpGet]
        public IActionResult DevolverUrl(string shortCode)
        {
            try
            {
                // Buscar la URL original en la base de datos
                var urlMapping = _context.URLMappings.FirstOrDefault(mapping => mapping.ShortUrl == shortCode);

                if (urlMapping != null)
                {
                    // Redirigir al usuario a la URL original
                    return Redirect(urlMapping.LongUrl);
                }
                else
                {
                    // Manejar la URL corta no encontrada (puede ser una página de error)
                    return View("ShortCodeNotFound");
                }
            }
            catch (Exception ex)
            {
              //  log.Error(ex, "Error en la acción Redirect");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
