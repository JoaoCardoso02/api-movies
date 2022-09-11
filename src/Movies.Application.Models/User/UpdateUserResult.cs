using System;

namespace Movies.Application.Models.User;

public class UpdateUserResult {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}

