using Movies.Domain.Models;
namespace UsersAPI.Tests;

public class UserTest {
    [Test]
    public void ShouldCreateUserSuccessfully() {
        Users movie = new Users {
            Name = "John Doe",
						BirthDate = new DateTime(2002, 01, 25),
						Email = "email@email.com",
						Id = (long)1,
						Password = "password",
        };

        Assert.IsTrue(movie.Name.Equals("John Doe"));
        Assert.IsTrue(movie.BirthDate.Equals(new DateTime(2002, 01, 25)));
        Assert.IsTrue(movie.Email.Equals("email@email.com"));
        Assert.IsTrue(movie.Id.Equals((long)1));
        Assert.IsTrue(movie.Password.Equals("password"));
    }

    [Test]
    public void ShouldBeInstanceOfUser() {
        Users movie = new Users {
            Name = "John Doe",
						BirthDate = new DateTime(2002, 01, 25),
						Email = "email@email.com",
						Id = 1,
						Password = "password",
        };

        Assert.IsInstanceOf<Users>(movie);
    }
}
