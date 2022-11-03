using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSAMovie.WebAPI.Features.Genres.Create;
using VSAMovie.WebAPI.Features.Movies.Create;
using VSAMovie.WebAPI.Model;

namespace VSAMovies.UnitTests.Features.movies.Get
{
    public class GetHandlerTest: HandlerBaseTest
    {
        public async Task Get_ReturnMovie_WithDetails()
        {
            //Arrange
            var nameDB = Guid.NewGuid().ToString();
            var _context = BuildContext(nameDB);
            var _mapper = ConfiguringAutomapper();
            var genre = new GenreDTO() {Description="Nuevo Genero", Name="Genero1"};
            var genre2 = new GenreDTO() {Description="Nuevo Genero 2", Name="Genero2"};
            var movie = new MovieDTO() { Poster = null, Title = "Nueva Pelicula", ReleaseDate = DateTime.Now, Genres = new List<int>() { 1, 2} };

            //Act

            _context.Add(genre);
            _context.Add(genre2);
            _context.Add(movie);
            //Assert
        }
    }
}
