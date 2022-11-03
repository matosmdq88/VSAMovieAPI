namespace VSAMovie.WebAPI.Features.Movies.Get
{
    public class MovieGetByIdDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Poster { get; set; }
        public List<GenreForMovieGetDTO> Genres { get; set; }
    }
}
