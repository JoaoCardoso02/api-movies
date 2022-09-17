using Movies.Infrastructure.Cryptography.Interfaces;

namespace Movies.Infrastructure.Cryptography;

public class BcryptAdapter : ICryptography
{
    public string HashPassword(string password) {
        return BCrypt.Net.BCrypt.HashPassword(password, 12);
    }

    public bool Verify(string password, string passwordHashed) {
        try {
            return BCrypt.Net.BCrypt.Verify(password, passwordHashed);
        } catch {
            return false;
        }
    }
}

