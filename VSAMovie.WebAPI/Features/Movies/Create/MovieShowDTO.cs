namespace VSAMovie.WebAPI.Features.Movies.Create
{
    public class MovieShowDTO
    {        
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Poster { get; set; }
        public List<GenreForMovieShowDTO> Genres { get; set; }
    }
}
