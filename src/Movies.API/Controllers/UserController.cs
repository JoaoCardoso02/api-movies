using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Models.User;
using Movies.Application.Services.Interfaces;

namespace Movies.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
public class UserController
{
    private readonly IUserAppService UserAppService;

    public UserController(IUserAppService userAppService)
    {
        UserAppService = userAppService;
    }

    [HttpGet()]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<GetAllUserResult> GetAllUser() {
        return await UserAppService.GetAll();
    }
}
