using System;
using Microsoft.AspNetCore.Mvc;

namespace Movies.Application.Models.User;

public class CreateUserRequest
{
    [FromBody]
    public string Name { get; set; }

    [FromBody]
    public string Email { get; set; }

    [FromBody]
    public string Password { get; set; }

    [FromBody]
    public DateOnly BirthDate { get; set; }
}

