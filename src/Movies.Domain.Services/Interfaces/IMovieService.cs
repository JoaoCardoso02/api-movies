using Movies.Domain.Models;

namespace Movies.Domain.Services.Interfaces;

public interface IMovieService
{
    List<Movie> GetAll();
    Movie GetOne(long id);
    Movie Create(Movie movie);
    Movie Update(long id, Movie movie);
    bool Delete(long id);
}

