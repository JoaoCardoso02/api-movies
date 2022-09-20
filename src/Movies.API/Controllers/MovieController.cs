using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Models.Movie;
using Movies.Application.Services.Interfaces;

namespace Movies.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
public class MovieController {
    private readonly IMovieAppService MovieAppService;

    public MovieController(IMovieAppService userAppService) {
        MovieAppService = userAppService;
    }

    [HttpGet()]
    [Consumes(MediaTypeNames.Application.Json)]
    public List<GetAllMovieResult> GetAllMovie() {
        return MovieAppService.GetAll();
    }

    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public GetOneMovieResult GetMovieById(string id) {
        long.TryParse(id, out long idLong);
        return MovieAppService.GetById(idLong);
    }

    [HttpPost()]
    [Consumes(MediaTypeNames.Application.Json)]
    public CreateMovieResult CreateMovie(CreateMovieRequest user) {
        return MovieAppService.Create(user);
    }

    [HttpPut("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public UpdateMovieResult UpdateMovie(string id, UpdateMovieRequest user) {
        long.TryParse(id, out long idLong);
        return MovieAppService.Update(idLong, user);
    }

    [HttpDelete("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public bool DeleteMovie(string id) {
        long.TryParse(id, out long idLong);
        return MovieAppService.Delete(idLong);
    }
}
