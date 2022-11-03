using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace VSAMovie.WebAPI.Features.Movies.GetAll
{
    public class GetAllHandler : HandlerBase, IRequestHandler<GetAllQuery, List<MovieGetDTO>>
    {
        public GetAllHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<List<MovieGetDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var movies = await _context.Movies.ToListAsync();
            return _mapper.Map<List<MovieGetDTO>>(movies);
        }
    }
}
