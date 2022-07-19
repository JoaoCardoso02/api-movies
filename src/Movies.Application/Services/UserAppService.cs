﻿using Movies.Domain.Services.Interfaces;
using Movies.Domain.Services;
using Movies.Application.Models.User;
using Movies.Application.Services.Interfaces;

namespace Movies.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IUserService _userService;

    public UserAppService()
    {
        _userService = new UserService();
    }

    public async Task<List<GetAllUserResult>> GetAll() {
        var users = await _userService.GetAll();

        List<GetAllUserResult> result = new List<GetAllUserResult>();

        users.ForEach(user => {
            result.Add(new GetAllUserResult(user.Id));
        });

        return result;
    }
}
