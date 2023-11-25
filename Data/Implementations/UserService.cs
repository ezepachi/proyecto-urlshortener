using proyecto_urlshortener.Entities;
using System.Data;
using URLShortener.Data.Interfaces;
using URLShortener.Models;

namespace URLShortener.Data.Implementations
{
    public class UserService : IUserService
    {
        private readonly UrlShortenerContext _context;
        public UserService(UrlShortenerContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.Select(u => new User()
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            }).ToList();
        }
        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }
        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }
        public void Create(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
        public void Update(CreateAndUpdateUserDto dto, int userId)
        {
            User userToUpdate = _context.Users.First(u => u.Id == userId);
            userToUpdate.Username = dto.Username;
            //userToUpdate.UserName = dto.NombreDeUsuario; //Esto no deberíamos actualizarlo, lo mejor es crear un dto para actualización que no contenga este campo.
            userToUpdate.Password = dto.Password;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            _context.SaveChanges();
        }
        public bool CheckIfUserExists(int userId)
        {
            User? user = _context.Users.FirstOrDefault(user => user.Id == userId);
            return user != null;
        }
    }

}
