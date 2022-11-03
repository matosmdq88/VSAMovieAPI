using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSAMovie.WebAPI.Model;

namespace VSAMovie.WebAPI.Features.Genres.Create
{
    public class CreateHandler : HandlerBase, IRequestHandler<CreateCommand, GenreShowDTO>
    {
        public CreateHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<GenreShowDTO> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            new CancellationToken();
            var toAdd = _mapper.Map<Genre>(request.Genre);
            _context.Add(toAdd);
            await _context.SaveChangesAsync();
            return _mapper.Map<GenreShowDTO>(toAdd);
        }
    }
}
