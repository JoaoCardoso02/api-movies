﻿using Movies.Infrastructure.Data;
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

    public async Task<Users> GetById(long id) {
        var userRepository = Repository.Users;

        var user = userRepository.Where(user => user.Id == id).SingleOrDefault();

        if (user == null) {
            throw new Exception("User does not find");
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
            throw new Exception("User does not find");
        }

        var userUpdated = new Users {
            Id = user.Id,
            Name = userToEdit.Name ?? user.Name,
            Email = userToEdit.Email ?? user.Email,
            Password = userToEdit.Password ?? user.Password,
            BirthDate = userToEdit.BirthDate == DateTime.MinValue ? user.BirthDate : userToEdit.BirthDate,
        };

        userRepository.Update(userUpdated);
        await Repository.SaveChangesAsync();

        return user;
    }
}

