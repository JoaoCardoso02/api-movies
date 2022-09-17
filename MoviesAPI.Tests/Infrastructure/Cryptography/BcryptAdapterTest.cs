using System;
using BCrypt;
using Moq;
using Movies.Infrastructure.Cryptography;
using Movies.Infrastructure.Cryptography.Interfaces;

namespace MoviesAPI.Tests.Infrastructure.Cryptography;

public class BcryptAdapterTest
{
    ICryptography _bcryptAdapter;
    string passwordToHash = "some password";

    public BcryptAdapterTest() {
        _bcryptAdapter = new BcryptAdapter();
    }

    [Test]
    public void Should_HashPassword_Successfully() {
        string hashedPassword = _bcryptAdapter.HashPassword(passwordToHash);

        Assert.AreNotEqual(passwordToHash, hashedPassword);
    }

    [Test]
    public void Should_Verify_PasswordHashed_Successfully() {
        string hashedPassword = _bcryptAdapter.HashPassword(passwordToHash);
        bool isEqualToHashed = _bcryptAdapter.Verify(passwordToHash, hashedPassword);

        Assert.IsTrue(isEqualToHashed);
    }

    [Test]
    public void Should_ReturnFalse_When_TryTo_Verify_IncorrectPassword() {
        string passwordToCompare = "some incorrect password";
        string hashedPassword = _bcryptAdapter.HashPassword(passwordToHash);
        bool isEqualToHashed = _bcryptAdapter.Verify(passwordToHash, passwordToCompare);

        Assert.IsFalse(isEqualToHashed);
    }
}

