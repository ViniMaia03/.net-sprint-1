using Microsoft.EntityFrameworkCore;
using sprint_1.Data;
using sprint_1.DTOs;
using sprint_1.Models;
using sprint_1.Repositorys.Interfaces;

namespace sprint_1.Repositorys.Implementations
{
    public class UserAuth : IUSerAuth
    {
        private readonly DataContext _dataContext;

        public UserAuth(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<user> CreateUser(UserRegisterDto request)
        {
            var getUser = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (getUser == null) {
                user newUser = new user
                {
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Name = request.Name
                };
                _dataContext.Users.Add(newUser);
                _dataContext.SaveChanges();

                return newUser;
            }
            return null;
        }

        public void DeleteUSer(int id)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null) {
                user.isActive = false;  
            }
        }

        public async Task<user> GetUserByEmail(USerLoginDto request)
        {
            var getUser = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (getUser == null) {
                return null;          
              }

            if (BCrypt.Net.BCrypt.Verify(request.Password, getUser.Password)) return getUser;

            return null;
        }
    }
}
