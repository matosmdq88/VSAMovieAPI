using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSAMovie.WebAPI.Features.Genres.GetAll;

namespace VSAMovie.WebAPI.Features.Genres.Get
{
    public class GetHandler: HandlerBase, IRequestHandler<GetByIdQuery, GenreGetByIdDTO>
    {
        public GetHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<GenreGetByIdDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var genresDb = await _context.Genres.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if(genresDb!=null)
            {
                var dto= _mapper.Map<GenreGetByIdDTO>(genresDb);
                return dto;
            }
            return null;
        }

    }
}
