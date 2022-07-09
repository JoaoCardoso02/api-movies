using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;

namespace Movies.Application.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {}

    public DbSet<Users> Users { get; set; }
}

