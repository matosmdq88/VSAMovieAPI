using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace VSAMovie.WebAPI.Features.Genres.GetAll
{
    public class GetAllHandler : HandlerBase, IRequestHandler<GetAllQuery, List<GenreGetDTO>>
    {
        public GetAllHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<List<GenreGetDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var genresDb= await _context.Genres.ToListAsync();
            return _mapper.Map<List<GenreGetDTO>>(genresDb);
        }
    }
}
