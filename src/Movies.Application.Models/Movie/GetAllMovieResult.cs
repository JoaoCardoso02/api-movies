using System;

namespace Movies.Application.Models.Movie;

public class GetAllMovieResult {
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string Picture { get; set; }
    public uint Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
}

