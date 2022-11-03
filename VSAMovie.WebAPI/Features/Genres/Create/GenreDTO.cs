using System.ComponentModel.DataAnnotations;

namespace VSAMovie.WebAPI.Features.Genres.Create
{
    public class GenreDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
