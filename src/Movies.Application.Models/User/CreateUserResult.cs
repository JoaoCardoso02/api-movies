using System;

namespace Movies.Application.Models.User;

public class CreateUserResult {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
}

