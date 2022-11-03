using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAMovie.WebAPI.Model;

namespace VSAMovie.WebAPI.Features.Genres.Update
{
    public class UpdateHandler : HandlerBase, IRequestHandler<UpdateCommand, bool>
    {
        public UpdateHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var exist = await _context.Genres.AnyAsync(x=>x.Id==request.Id);
            if (!exist)
            {
                return false;
            }
            var updateGenre = _mapper.Map<Genre>(request.Genre);
            updateGenre.Id = request.Id;
            _context.Entry(updateGenre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
