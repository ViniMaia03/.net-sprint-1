using sprint_1.DTOs;
using sprint_1.Models;

namespace sprint_1.Repositorys.Interfaces
{
    public interface IUSerAuth
    {
        Task<user> GetUserByEmail(USerLoginDto request);
        Task<user> CreateUser(UserRegisterDto request);
        void DeleteUSer(int id);
    }
}
