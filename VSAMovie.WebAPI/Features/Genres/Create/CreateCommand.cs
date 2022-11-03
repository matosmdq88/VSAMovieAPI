using MediatR;

namespace VSAMovie.WebAPI.Features.Genres.Create
{
    public class CreateCommand: IRequest<GenreShowDTO>
    {
        public GenreDTO Genre { get; set; }
    }
}
