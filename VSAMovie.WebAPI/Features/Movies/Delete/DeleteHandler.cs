using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAMovie.WebAPI.Model;

namespace VSAMovie.WebAPI.Features.Movies.Delete
{
    public class DeleteHandler : HandlerBase, IRequestHandler<DeleteMovieQuery, bool>
    {
        public DeleteHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<bool> Handle(DeleteMovieQuery request, CancellationToken cancellationToken)
        {
            var exist = await _context.Movies.AnyAsync(x=> x.Id == request.Id);
            if(!exist)
            {
                return false;
            }
            _context.Remove(new Movie() { Id = request.Id });
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
