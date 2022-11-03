using System.ComponentModel.DataAnnotations;

namespace VSAMovie.WebAPI.Model
{
    public class Movie
    {        
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Poster { get; set; }
        public List<MoviesGenres> MoviesGenres { get; set; }
    }
}
