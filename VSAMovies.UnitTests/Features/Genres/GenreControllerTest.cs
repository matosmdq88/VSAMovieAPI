using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VSAMovie.WebAPI.Features.Genres;
using VSAMovie.WebAPI.Features.Genres.GetAll;
using Xunit;

namespace VSAMovies.UnitTests.Features.Genres
{
    public class GenreControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly GenreController _classUnderTest;

        public GenreControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _classUnderTest = new GenreController(_mediator.Object);
        }

        [Fact]
        public async Task Get_ReturnNotFound_WhenIsNull()
        {
            //Arrange
            _mediator
                .Setup(mock => mock.Send(It.IsAny<GetAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((List<GenreGetDTO>)null);
            //Act
            var result = await _classUnderTest.Get();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
            _mediator.Verify(mock => mock.Send(It.IsAny<GetAllQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Get_ReturnList()
        {
            //Arrange
            _mediator
                .Setup(mock => mock.Send(It.IsAny<GetAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<GenreGetDTO>());
            //Act
            var result = await _classUnderTest.Get();
            var rta = result as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(rta.StatusCode,200);
            _mediator.Verify(mock => mock.Send(It.IsAny<GetAllQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
