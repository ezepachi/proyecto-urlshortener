using Microsoft.EntityFrameworkCore;
using proyecto_urlshortener.Controllers;

namespace Proyecto.Data.Implementations
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options)
        {
        }

        // Define DbSet para la entidad URLMapping
        public DbSet<proyecto_urlshortener.Entities.URLMapping> URLMappings { get; set; }

 
    }
}
