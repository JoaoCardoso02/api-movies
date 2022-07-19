using System;

namespace Movies.Domain.Models;

public class Users {
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }

    public Users(string name, string email, string password, DateTime birthDate, long? id = null) {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        BirthDate = birthDate;
    }
}
