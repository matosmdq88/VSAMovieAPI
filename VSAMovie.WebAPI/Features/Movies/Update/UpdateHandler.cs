using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAMovie.WebAPI.Servicios;

namespace VSAMovie.WebAPI.Features.Movies.Update
{
    public class UpdateHandler : HandlerBase, IRequestHandler<UpdateMovieCommand, bool>
    {
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string _container = "Movies";

        public UpdateHandler(ApplicationDbContext context, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos) : base(context, mapper)
        {
            _almacenadorArchivos= almacenadorArchivos;
        }
        public async Task<bool> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieDb= await _context.Movies.Include(x=>x.MoviesGenres).FirstOrDefaultAsync(x=>x.Id==request.Id);

            if (movieDb == null)
            {
                return false;
            }

            movieDb = _mapper.Map(request.Movie, movieDb);
            if (request.Movie.Poster != null)
            {
               using(var memoryStream = new MemoryStream())
                {
                    await request.Movie.Poster.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extencion = Path.GetExtension(request.Movie.Poster.FileName);
                    movieDb.Poster= await _almacenadorArchivos.EditarArchivo(contenido, extencion, _container, movieDb.Poster,request.Movie.Poster.ContentType);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
