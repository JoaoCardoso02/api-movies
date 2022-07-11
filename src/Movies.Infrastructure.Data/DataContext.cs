using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movies.Domain.Models;

namespace Movies.Infrastructure.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext() : base() { }

    public DataContext(IConfiguration configuration) : base() {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseMySql("server=127.0.0.1;uid=root;pwd=password;database=movies", ServerVersion.Parse("5.7.12"), mySqlOptions => {
            var assembly = typeof(DataContext).Assembly;
            var assemblyName = assembly.GetName();

            mySqlOptions.MigrationsAssembly(assemblyName.Name);
        });
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder) {
    //    base.OnModelCreating(modelBuilder);
    //}

    public DbSet<Users> Users { get; set; }
}

