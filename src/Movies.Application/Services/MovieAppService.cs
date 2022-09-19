using Movies.Domain.Services.Interfaces;
using Movies.Domain.Models;

using Movies.Application.Services.Interfaces;
using Movies.Application.Models.Movie;

using Movies.Infrastructure.Cryptography.Interfaces;

namespace Movies.Application.Services;

public class MovieAppService : IMovieAppService
{
    private readonly IMovieService MovieService;
    private readonly ICryptography Cryptography;

    public MovieAppService(
        IMovieService movieService,
        ICryptography cryptography
    ) {
        MovieService = movieService;
        Cryptography = cryptography;
    }

    public List<GetAllMovieResult> GetAll() {
        var movies = MovieService.GetAll();

        List<GetAllMovieResult> result = new List<GetAllMovieResult>();

        movies.ForEach(movie => {
            if (movie != null && movie.Id != null) {
                result.Add(new GetAllMovieResult {
                    Id = (long)movie.Id,
					Name = movie.Name,
					Synopsis = movie.Synopsis,
					Picture = movie.Picture,
					Rating = movie.Rating,
					ReleaseDate = movie.ReleaseDate,
                });
            }
        });

        return result;
    }

    public GetOneMovieResult GetById(long id) {
        var movie = MovieService.GetOne(id);

        if (movie == null || movie.Id == null) {
            throw new Exception("Movie does not exist");
        }

        return new GetOneMovieResult {
            Id = (long)movie.Id,
            Name = movie.Name,
			Synopsis = movie.Synopsis,
			Picture = movie.Picture,
			Rating = movie.Rating,
			ReleaseDate = movie.ReleaseDate,
        };
    }

    public CreateMovieResult Create(CreateMovieRequest movie) {
        var movieCreated = MovieService.Create(new Movie {
            Name = movie.Name,
			Synopsis = movie.Synopsis,
			Picture = movie.Picture,
			Rating = movie.Rating,
			ReleaseDate = movie.ReleaseDate,
        });

        if (movieCreated == null || movieCreated.Id == null) {
            throw new Exception("Movie does not created");
        }

        return new CreateMovieResult {
            Id = (long)movieCreated.Id,
            Name = movieCreated.Name,
            Synopsis = movieCreated.Synopsis,
			Picture = movieCreated.Picture,
			Rating = movieCreated.Rating,
			ReleaseDate = movieCreated.ReleaseDate,
        };
    }

    public UpdateMovieResult Update(long id, UpdateMovieRequest movie) {
        var movieUpdated = MovieService.Update(id, new Movie {
            Name = movie.Name,
			Synopsis = movie.Synopsis,
			Picture = movie.Picture,
			Rating = movie.Rating,
			ReleaseDate = movie.ReleaseDate,
        });

        if (movieUpdated == null || movieUpdated.Id == null) {
            throw new Exception("Movie does not updated");
        }

        return new UpdateMovieResult {
            Id = (long)movieUpdated.Id,
            Name = movieUpdated.Name,
			Synopsis = movieUpdated.Synopsis,
			Picture = movieUpdated.Picture,
			Rating = movieUpdated.Rating,
			ReleaseDate = movieUpdated.ReleaseDate,
        };
    }

    public bool Delete(long id) {
        return MovieService.Delete(id);
    }
}
