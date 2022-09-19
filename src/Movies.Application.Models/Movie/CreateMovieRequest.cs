using System;
using Microsoft.AspNetCore.Mvc;

namespace Movies.Application.Models.Movie;

public class CreateMovieRequest
{
    [FromBody]
	public string Name { get; set; }

    [FromBody]
	public string Synopsis { get; set; }

    [FromBody]
	public string Picture { get; set; }

    [FromBody]
	public uint Rating { get; set; }

    [FromBody]
	public DateTime ReleaseDate { get; set; }
}

