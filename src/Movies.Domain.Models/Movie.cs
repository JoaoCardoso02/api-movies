using System;

namespace Movies.Domain.Models;

public class Movie {
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string Picture { get; set; }
    public uint Rating { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Movie(
        string name,
        string synopsis,
        string picture,
        uint rating,
        DateTime releaseDate,
        long? id
    ) {
        Name = name;
        Synopsis = synopsis;
        Picture = picture;
        Rating = rating;
        ReleaseDate = releaseDate;
        Id = id;
    }

    public Movie() {}
}