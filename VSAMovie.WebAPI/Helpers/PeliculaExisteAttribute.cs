using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace VSAMovie.WebAPI.Helpers
{
    public class PeliculaExisteAttribute : Attribute, IAsyncResourceFilter
    {
        private readonly ApplicationDbContext _context;

        public PeliculaExisteAttribute(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var peliculaIdObject = context.HttpContext.Request.RouteValues["peliculaId"];

            if(peliculaIdObject==null)
            {
                return;
            }

            var peliculaId= int.Parse(peliculaIdObject.ToString());

            var existePelicula = await _context.Movies.AnyAsync(x => x.Id == peliculaId);
            if (!existePelicula)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                await next();
            }
        }
    }
}
