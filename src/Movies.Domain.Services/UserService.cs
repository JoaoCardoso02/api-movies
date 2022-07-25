using Movies.Infrastructure.Data;
using Movies.Domain.Services.Interfaces;
using Movies.Domain.Models;

namespace Movies.Domain.Services;

public class UserService : IUserService
{
    private readonly DataContext Repository;

    public UserService(DataContext repository) {
        Repository = repository;
    }

    public async Task<List<Users>> GetAll() {
        var userRepository = Repository.Users;

        var users = userRepository.ToList();

        return users;
    }

    public async Task<Users> GetById(long id) {
        var userRepository = Repository.Users;

        var user = userRepository.Where(user => user.Id == id).SingleOrDefault();

        if (user == null) {
            throw new Exception("User not found");
        }

        return user;
    }

    public async Task<Users> GetByEmail(string email) {
        var userRepository = Repository.Users;

        var user = userRepository.Where(user => user.Email == email).SingleOrDefault();

        if (user == null) {
            throw new Exception("User not found");
        }

        return user;
    }

    public async Task<Users> Create(Users user) {
        var userRepository = Repository.Users;

        userRepository.Add(user);
        await Repository.SaveChangesAsync();

        return user;
    }

    public async Task<Users> Update(long id, Users userToEdit) {
        var userRepository = Repository.Users;

        var user = userRepository.Where(user => user.Id == id).SingleOrDefault();

        if (user == null) {
            throw new Exception("User not found");
        }

        user.Id = user.Id;
        user.Name = userToEdit.Name ?? user.Name;
        user.Email = userToEdit.Email ?? user.Email;
        user.Password = userToEdit.Password ?? user.Password;
        user.BirthDate = userToEdit.BirthDate == DateTime.MinValue ? user.BirthDate : userToEdit.BirthDate;

        userRepository.Update(user);
        await Repository.SaveChangesAsync();

        return user;
    }

    public async Task<bool> Delete(long id) {
        try {
            var userRepository = Repository.Users;

            var user = userRepository.Where(user => user.Id == id).SingleOrDefault();

            if (user == null) {
                throw new Exception("User not found");
            }

            userRepository.Remove(user);
            await Repository.SaveChangesAsync();

            return true;
        } catch {
            return false;
        }
    }
}

