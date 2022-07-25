using Movies.Infrastructure.Cryptography.Interfaces;

namespace Movies.Infrastructure.Cryptography;

public class BcryptAdapter : ICryptography
{
    public string HashPassword(string password) {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string passwordHashed) {
        return BCrypt.Net.BCrypt.Verify(password, passwordHashed);
    }
}

