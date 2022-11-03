using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSAMovie.WebAPI.Features.Genres.Create;
using VSAMovie.WebAPI.Features.Genres.Delete;
using VSAMovie.WebAPI.Features.Genres.Get;
using VSAMovie.WebAPI.Features.Genres.GetAll;
using VSAMovie.WebAPI.Features.Genres.Update;

namespace VSAMovie.WebAPI.Features.Genres
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController:ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list= await _mediator.Send(new GetAllQuery());
            if(list is null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("{id:int}",Name ="obtenerGenero")]
        public async Task<ActionResult> Get(int id)
        {
            var genre = await _mediator.Send(new GetByIdQuery() { Id=id });
            if (genre is null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCommand command)
        {
            var added= await _mediator.Send(command);
            if (added is null)
            {
                return BadRequest("error al agregar");
            }
            return new CreatedAtRouteResult("obtenerGenero", added);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateCommand command)
        {
            if(! await _mediator.Send(command))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteQuery query)
        {
            if(! await _mediator.Send(query))
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
