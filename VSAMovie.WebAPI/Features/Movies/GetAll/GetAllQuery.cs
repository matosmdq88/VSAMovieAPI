using MediatR;

namespace VSAMovie.WebAPI.Features.Movies.GetAll
{
    public class GetAllQuery: IRequest<List<MovieGetDTO>>
    {
    }
}
