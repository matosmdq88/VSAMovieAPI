using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAMovie.WebAPI.Model;

namespace VSAMovie.WebAPI.Features.Genres.Delete
{
    public class DeleteHandler : HandlerBase, IRequestHandler<DeleteQuery, bool>
    {
        public DeleteHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<bool> Handle(DeleteQuery request, CancellationToken cancellationToken)
        {
            var exist =  await _context.Genres.AnyAsync(x=>x.Id==request.Id);
            if (!exist)
            {
                return false;
            }
            _context.Remove(new Genre { Id = request.Id });
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
