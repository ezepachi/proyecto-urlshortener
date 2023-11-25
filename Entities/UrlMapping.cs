using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//aca realizamos la creacion de la tabla url con sus atributos
namespace proyecto_urlshortener.Entities
{
    public class Url
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        [StringLength(500)]
        public int clickVisit { get; set; }
        public Category Category { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public User User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

    }
}
