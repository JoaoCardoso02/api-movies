using System;
using Microsoft.AspNetCore.Mvc;

namespace Movies.Application.Models.User;

public class UpdateUserRequest
{
    [FromBody]
    public string Name { get; set; }

    [FromBody]
    public string Email { get; set; }

    [FromBody]
    public string Password { get; set; }

    [FromBody]
    public DateTime BirthDate { get; set; }
}

