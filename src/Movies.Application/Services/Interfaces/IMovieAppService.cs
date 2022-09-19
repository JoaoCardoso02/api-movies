using Movies.Application.Models.Movie;

namespace Movies.Application.Services.Interfaces;

public interface IMovieAppService
{
    List<GetAllMovieResult> GetAll();
    GetOneMovieResult GetById(long id);
    CreateMovieResult Create(CreateMovieRequest movie);
    UpdateMovieResult Update(long id, UpdateMovieRequest movie);
    bool Delete(long id);
}
