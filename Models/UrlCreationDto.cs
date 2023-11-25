namespace URLShortener.Models
{
    public class UrlCreationDto 
    {
        public int IdCategory { get; set; }
        public string LongUrl { get; set; }
        public int UserId { get; set; }
    }
}
