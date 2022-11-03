using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VSAMovie.WebAPI.Features.Genres.Create;
using Xunit;

namespace VSAMovies.UnitTests.Features.Genres.Create
{
    public class CreateHandlerTest: HandlerBaseTest
    {
        [Fact]
        public async Task CreateHandler_Return_CreatedConfirmation()
        {
            //Arrange
            var nameDB = Guid.NewGuid().ToString();
            var _context = this.BuildContext(nameDB);
            var _mapper = this.ConfiguringAutomapper();
            var _classUnderTest = new CreateHandler(_context,_mapper);
            var command = new CreateCommand() { Genre = new GenreDTO() { Description = "descripcion1", Name = "genero1"} };

            //Act            
            var rta = await _classUnderTest.Handle(command, new CancellationToken());
            var _context2 = this.BuildContext(nameDB);
            var list = await _context2.Genres.ToListAsync();

            //Assert
            Assert.Equal(rta.Name, "genero1");
            Assert.IsType<GenreShowDTO>(rta);
            Assert.Equal(list.Count, 1);
        }
    }
}
