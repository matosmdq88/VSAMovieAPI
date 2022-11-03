using MediatR;

namespace VSAMovie.WebAPI.Features.Genres.Delete
{
    public class DeleteQuery: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
