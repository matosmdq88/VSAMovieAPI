using MediatR;

namespace VSAMovie.WebAPI.Features.Movies.Create
{
    public class CreateCommand: IRequest<MovieShowDTO>
    {
        public MovieDTO Movie { get; set; }
    }
}
