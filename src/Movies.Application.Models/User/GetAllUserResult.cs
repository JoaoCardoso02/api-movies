using System;

namespace Movies.Application.Models.User;

public class GetAllUserResult {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }

    public GetAllUserResult(long id) {
        Id = id;
    }
}

