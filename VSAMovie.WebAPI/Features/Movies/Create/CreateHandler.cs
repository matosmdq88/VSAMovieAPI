using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAMovie.WebAPI.Model;
using VSAMovie.WebAPI.Servicios;

namespace VSAMovie.WebAPI.Features.Movies.Create
{
    public class CreateHandler : HandlerBase, IRequestHandler<CreateCommand, MovieShowDTO>
    {        
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string _container = "Movies";

        public CreateHandler(IAlmacenadorArchivos almacenadorArchivos,ApplicationDbContext context, IMapper mapper) : base (context,mapper)
        {
            _almacenadorArchivos = almacenadorArchivos;
        }
        public async Task<MovieShowDTO> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var toAdd = _mapper.Map<Movie>(request.Movie);
            if(request.Movie.Poster!=null)
            {
                using(var memoryStream = new MemoryStream())
                {
                    await request.Movie.Poster.CopyToAsync(memoryStream);
                    var container = memoryStream.ToArray();
                    var extension= Path.GetExtension(request.Movie.Poster.FileName);
                    toAdd.Poster = await _almacenadorArchivos.GuardarArchivo(container, extension, _container, request.Movie.Poster.ContentType);
                }
            }
            _context.Add(toAdd);
            await _context.SaveChangesAsync();
            return _mapper.Map<MovieShowDTO>(await _context.Movies.Include(x=>x.MoviesGenres).ThenInclude(y=>y.Genre).FirstOrDefaultAsync(x=>x.Id==toAdd.Id));
        }
    }
}
