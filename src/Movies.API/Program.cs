global using Movies.Infrastructure.Data;
global using Microsoft.EntityFrameworkCore;

using Movies.Domain.Services.Interfaces;
using Movies.Domain.Services;

using Movies.Application.Services.Interfaces;
using Movies.Application.Services;

using Movies.Infrastructure.Cryptography.Interfaces;
using Movies.Infrastructure.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options => {
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("5.7.12"), mySqlOptions => {
        var assembly = typeof(DataContext).Assembly;
        var assemblyName = assembly.GetName();

        mySqlOptions.MigrationsAssembly(assemblyName.Name);
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddScoped<ICryptography, BcryptAdapter>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

