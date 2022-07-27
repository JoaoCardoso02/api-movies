﻿using Movies.Domain.Models;
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
}

