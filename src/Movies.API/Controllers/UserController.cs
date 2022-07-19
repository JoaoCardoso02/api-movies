﻿using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Models.User;
using Movies.Application.Services.Interfaces;
using Movies.Application.Services;

namespace Movies.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
public class UserController
{
    private readonly IUserAppService UserAppService;

    public UserController()
    {
        UserAppService = new UserAppService();
    }

    [HttpGet()]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<List<GetAllUserResult>> GetAllUser() {
        return await UserAppService.GetAll();
    }

    [HttpPost()]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<CreateUserResult> CreateUser(CreateUserRequest user) {
        return await UserAppService.Create(user);
    }
}

