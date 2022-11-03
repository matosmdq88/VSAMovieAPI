using MediatR;

namespace VSAMovie.WebAPI.Features.Movies.Get
{
    public class GetByIdQuery: IRequest<MovieGetByIdDTO>
    {
        public int Id { get; set; }
    }
}
