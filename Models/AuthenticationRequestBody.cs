using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
//los dtos son los objetos que se van a utilizar para la comunicacion entre el front y el back