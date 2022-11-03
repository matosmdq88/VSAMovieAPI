using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VSAMovie.WebAPI;
using VSAMovie.WebAPI.Features.Genres;
using VSAMovie.WebAPI.Features.Movies;

namespace VSAMovies.UnitTests.Features
{
    public class HandlerBaseTest
    {
        protected ApplicationDbContext BuildContext(string nameDB)
        {
            var options= new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(nameDB).Options;
            var dbContext = new ApplicationDbContext(options);
            return dbContext;
        }

        protected IMapper ConfiguringAutomapper()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile(new GenreProfile());
                options.AddProfile(new MovieProfile());
            });
            return config.CreateMapper();
        }
    }
}
