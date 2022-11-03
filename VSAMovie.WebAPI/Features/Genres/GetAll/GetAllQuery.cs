using MediatR;

namespace VSAMovie.WebAPI.Features.Genres.GetAll
{
    public class GetAllQuery : IRequest<List<GenreGetDTO>>
    {
    }
}
