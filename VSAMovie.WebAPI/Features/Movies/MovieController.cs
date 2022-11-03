using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSAMovie.WebAPI.Features.Movies.Create;
using VSAMovie.WebAPI.Features.Movies.Delete;
using VSAMovie.WebAPI.Features.Movies.Get;
using VSAMovie.WebAPI.Features.Movies.GetAll;
using VSAMovie.WebAPI.Features.Movies.Update;

namespace VSAMovie.WebAPI.Features.Movies
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator, ApplicationDbContext context)
        {
            _context = context;
            _mediator = mediator;
        }
        
        [HttpGet("{id:int}", Name ="obtenerPelicula")]
        public async Task<ActionResult> Get(int id)
        {
            var movie = await _mediator.Send(new GetByIdQuery() { Id=id});
            if(movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var movies = await _mediator.Send(new GetAllQuery());
            if(movies == null) return NotFound();
            return Ok(movies);
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]CreateCommand command)
        {
            var added = await _mediator.Send(command);
            if (added is null)
            {
                return BadRequest("error al agregar");
            }
            return new CreatedAtRouteResult("obtenerPelicula", new { Id= added.Id }, added);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateMovieCommand command)
        {
            if (await _mediator.Send(command))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteMovieQuery query)
        {
            if (await _mediator.Send(query) )
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
