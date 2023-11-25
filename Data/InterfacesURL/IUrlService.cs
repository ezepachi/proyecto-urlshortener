using proyecto_urlshortener.Entities;

namespace URLShortener.Data.Interfaces
{
    public interface IUrlService
    {
        Url GetUrlById(int id);
        Url GetUrlByShortUrl(string shortUrl);
        void AddUrl(Url url);
        void SaveChanges();

        void IncrementClickCounter(int id);
    }
}
