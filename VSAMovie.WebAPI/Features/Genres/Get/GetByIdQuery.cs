using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSAMovie.WebAPI.Features.Genres.GetAll;

namespace VSAMovie.WebAPI.Features.Genres.Get
{
    public class GetByIdQuery : IRequest<GenreGetByIdDTO>
    {
        public int Id { get; set; }
    }
}
