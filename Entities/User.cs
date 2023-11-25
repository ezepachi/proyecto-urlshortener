using System;
// aca realizamos la creacion de la tabla user con sus atributos
namespace proyecto_urlshortener.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public List<Url> Urls { get; set; }
    }
}
