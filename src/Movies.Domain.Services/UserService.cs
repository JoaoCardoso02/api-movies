using Movies.Infrastructure.Data;
using Movies.Domain.Services.Interfaces;
using Movies.Domain.Models;

namespace Movies.Domain.Services;

public class UserService : IUserService
{
    private DataContext Repository { get; }

    public UserService()
    {
        Repository = new DataContext();
    }

    public async Task<List<Users>> GetAll() {
        var userRepository = Repository.Users;

        var users = userRepository.ToList();

        return users;
    }
}

