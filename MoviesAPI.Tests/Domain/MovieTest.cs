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
        Assert.IsTrue(movie.Synopsis.Equals("Harry Potter is a ..."));
        Assert.IsTrue(movie.Picture.Equals("https://some-url.com"));
        Assert.IsTrue(movie.Rating.Equals(9));
        Assert.IsTrue(movie.ReleaseDate.Equals(new DateTime(2001, 11, 23)));
    }

    [Test]
    public void ShouldBeInstanceOfMovie() {
        Movie movie = new Movie {
            Name = "Harry Potter and The Philosopher's Stone",
            Synopsis = "Harry Potter is a ...",
            Picture = "https://some-url.com",
            Rating = 9,
            ReleaseDate = new DateTime(2001, 11, 23)
        };

        Assert.IsInstanceOf<Movie>(movie);
    }
}
