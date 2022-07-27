using Movies.Domain.Models;
using Movies.Domain.Services.Interfaces;
using Movies.Infrastructure.Data;

namespace Movies.Domain.Services;

public class MovieService : IMovieService
{
    private readonly DataContext Repository;

    public MovieService(DataContext repository) {
        Repository = repository;
    }

    public List<Movie> GetAll() {
        var movieRepository = Repository.Movie;

        var movies = movieRepository.ToList();

        return movies;
    }

    public Movie GetOne(long id) {
        var movieRepository = Repository.Movie;

        var movie = movieRepository.Where(movie => movie.Id == id).First();

        return movie;
    }

    public Movie Create(Movie movie) {
        var movieRepository = Repository.Movie;

        movieRepository.Add(movie);
        Repository.SaveChanges();

        return movie;
    }

    public Movie Update(long id, Movie movie) {
        var movieRepository = Repository.Movie;

        var movieSaved = GetOne(id);

        movieSaved.Name = movie.Name ?? movieSaved.Name;
        movieSaved.Picture = movie.Picture ?? movieSaved.Picture;
        movieSaved.Rating = movie.Rating == uint.MinValue ? movieSaved.Rating : movie.Rating;
        movieSaved.ReleaseDate = movie.ReleaseDate == DateTime.MinValue ? movieSaved.ReleaseDate : movie.ReleaseDate;
        movieSaved.Synopsis = movie.Synopsis ?? movieSaved.Synopsis;

        movieRepository.Update(movie);
        Repository.SaveChanges();

        return movie;
    }
}

