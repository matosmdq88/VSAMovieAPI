using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace VSAMovie.WebAPI.Features.Movies.Get
{
    public class GetHandler : HandlerBase, IRequestHandler<GetByIdQuery, MovieGetByIdDTO>
    {
        public GetHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<MovieGetByIdDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.Include(x=>x.MoviesGenres).ThenInclude(y=>y.Genre).FirstOrDefaultAsync(x=>x.Id==request.Id); 
            if(movie==null)
            {
                return null;
            }
            return _mapper.Map<MovieGetByIdDTO>(movie);
        }
    }
}
