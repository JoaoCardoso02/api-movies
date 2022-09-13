using System.Xml.Linq;
using Movies.Domain.Models;
namespace MoviesAPI.Tests;

public class MovieTest {
    [Test]
    public void ShouldCreateMovieSuccessfully() {
        Movie movie = new Movie {
            Name = "Harry Potter and The Philosopher's Stone",
            Synopsis = "Harry Potter is a ...",
            Picture = "https://some-url.com",
            Rating = 9,
            ReleaseDate = new DateTime(2001, 11, 23)
        };

        Assert.IsTrue(movie.Name.Equals("Harry Potter and The Philosopher's Stone"));
    }
}
