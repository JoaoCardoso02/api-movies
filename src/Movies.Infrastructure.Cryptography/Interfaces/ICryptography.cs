using System;
namespace Movies.Infrastructure.Cryptography.Interfaces;

public interface ICryptography {
    string HashPassword(string password);
    bool Verify(string password, string passwordHashed);
}

