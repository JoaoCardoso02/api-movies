using Movies.Domain.Models;

namespace Movies.Domain.Services.Interfaces;

public interface IUserService
{
    Task<List<Users>> GetAll();
    Task<Users> GetById(long id);
    Task<Users> GetByEmail(string email);
    Task<Users> Create(Users user);
    Task<Users> Update(long id, Users userToEdit);
    Task<bool> Delete(long id);
}
