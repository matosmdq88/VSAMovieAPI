using MediatR;

namespace VSAMovie.WebAPI.Features.Movies.Update
{
    public class UpdateMovieCommand: IRequest<bool>
    {
        public int Id { get; set; }
        public MoviePutDTO Movie { get; set; }
    }
}
