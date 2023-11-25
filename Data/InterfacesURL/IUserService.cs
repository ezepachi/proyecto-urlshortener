using proyecto_urlshortener.Entities;
using URLShortener.Models;

namespace URLShortener.Data.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User? GetById(int userId);
        void Create(CreateAndUpdateUserDto dto);
        void Delete(int id);
        void Update(CreateAndUpdateUserDto dto, int userId);
        User? ValidateUser(AuthenticationRequestBody authRequestBody);
    }
}
