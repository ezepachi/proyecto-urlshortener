namespace proyecto_urlshortener.Entities
{
    //aca creamos la clase Category con sus atributos 
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Url> Urls { get; set; }
    }
}
