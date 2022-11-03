using Microsoft.EntityFrameworkCore;
using VSAMovie.WebAPI.Model;

namespace VSAMovie.WebAPI
{
    public class ApplicationDbContext : DbContext    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesGenres>().HasKey(x => new { x.GenreId, x.MovieId });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_configuration is not null)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("OnConfiguring"));
            }
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
    }
}
