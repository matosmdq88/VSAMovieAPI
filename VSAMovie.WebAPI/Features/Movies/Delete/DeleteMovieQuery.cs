using MediatR;

namespace VSAMovie.WebAPI.Features.Movies.Delete
{
    public class DeleteMovieQuery: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
