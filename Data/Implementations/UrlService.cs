using proyecto_urlshortener.Entities;
using URLShortener.Data.Interfaces;

namespace URLShortener.Data.Implementations
{
    public class UrlService : IUrlService
    {
        private readonly UrlShortenerContext _context;

        public UrlService(UrlShortenerContext context)
        {
            _context = context;
        }

        public Url GetUrlById(int id)
        {
            return _context.Urls.FirstOrDefault(u => u.Id == id);
        }

        public Url GetUrlByShortUrl(string shortUrl)
        {
            return _context.Urls.FirstOrDefault(u => u.ShortUrl == shortUrl);
        }

        public void AddUrl(Url url)
        {
            _context.Urls.Add(url);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void IncrementClickCounter(int id)
        {
            var url = _context.Urls.FirstOrDefault(u => u.Id == id);

            if (url != null)
            {
                url.clickVisit++;
                _context.SaveChanges();
            }
        }


    }
}
