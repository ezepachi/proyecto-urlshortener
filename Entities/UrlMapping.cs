namespace proyecto_urlshortener.Entities
{

    public class URLMapping
    {
        internal string? shortCode;

        public int Id { get; set; }
        public string? LongUrl { get; set; }
        public string? ShortUrl { get; set; }
    }
}
