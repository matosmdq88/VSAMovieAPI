using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VSAMovie.WebAPI;
using VSAMovie.WebAPI.Features.Genres;
using VSAMovie.WebAPI.Features.Movies;

namespace VSAMovie.Test
{
    public class BaseTest
    {
        private readonly IConfiguration _configuration;

        public BaseTest(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected ApplicationDbContext BuildContext(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(name).Options;

            var dbContext = new ApplicationDbContext(options,_configuration);
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
