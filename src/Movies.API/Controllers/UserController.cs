using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Models.User;

namespace Movies.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
public class UserController
{
    public UserController()
    {
    }

    [HttpPost()]
    [Consumes(MediaTypeNames.Application.Json)]
    public CreateUserRequest CreateUser(CreateUserRequest createUserRequest) {
        return createUserRequest;
    }
}
