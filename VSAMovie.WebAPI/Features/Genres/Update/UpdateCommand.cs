using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAMovie.WebAPI.Features.Genres.Update
{
    public class UpdateCommand : IRequest<bool>
    {
        public GenrePutDTO Genre { get; set; }
        public int Id { get; set; }
    }
}
