using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Models.User;
using Movies.Application.Services.Interfaces;

namespace Movies.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
public class UserController {
    private readonly IUserAppService UserAppService;

    public UserController(IUserAppService userAppService) {
        UserAppService = userAppService;
    }

    [HttpGet()]
    [Consumes(MediaTypeNames.Application.Json)]
    public List<GetAllUserResult> GetAllUser() {
        return UserAppService.GetAll();
    }

    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<GetOneUserResult> GetUserById(string id) {
        long.TryParse(id, out long idLong);
        return await UserAppService.GetById(idLong);
    }

    [HttpPost()]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<CreateUserResult> CreateUser(CreateUserRequest user) {
        return await UserAppService.Create(user);
    }

    [HttpPut("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<UpdateUserResult> UpdateUser(string id, UpdateUserRequest user) {
        long.TryParse(id, out long idLong);
        return await UserAppService.Update(idLong, user);
    }

    [HttpDelete("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<bool> DeleteUser(string id) {
        long.TryParse(id, out long idLong);
        return await UserAppService.Delete(idLong);
    }
}
