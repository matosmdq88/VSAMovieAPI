namespace VSAMovie.WebAPI.Features.Movies.GetAll
{
    public class MovieGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Poster { get; set; }
    }
}
