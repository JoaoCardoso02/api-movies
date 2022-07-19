using Movies.Domain.Models;

namespace Movies.Domain.Services.Interfaces;

public interface IUserService
{
    Task<List<Users>> GetAll();
    Task<Users> Create(Users user);
}
