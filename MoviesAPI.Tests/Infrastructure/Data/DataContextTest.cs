using Movies.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Tests.Infrastructure;

public class DataContextTest {
    [Test]
    public void ShouldInstaceOfDataContextSucessfully() {
        var dataContext = new DataContext();

        Assert.IsInstanceOf<DataContext>(dataContext);
    }

    [Test]
    public void ShouldInstaceOfDbContextSucessfully() {
        DataContext dataContext = new DataContext();

        Assert.IsInstanceOf<DbContext>(dataContext);
    }
}

