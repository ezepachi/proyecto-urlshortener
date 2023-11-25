using System.Text;
namespace URLShortener.Helpers


//Aca realizamos la generacion del codigo corto

{
    public class GeneratedShortCode
    {

        private readonly string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public string GenerateShortUrl()
        {
            Random random = new Random();
            StringBuilder ShortUrl = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                int indice = random.Next(AllowedCharacters.Length);
                ShortUrl.Append(AllowedCharacters[indice]);
            }

            return ShortUrl.ToString();
        }
    }
}
