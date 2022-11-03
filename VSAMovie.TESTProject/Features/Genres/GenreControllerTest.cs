using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSAMovie.WebAPI.Features.Genres;
using Xunit;
using Moq;
using VSAMovie.WebAPI.Features.Genres.GetAll;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace VSAMovie.UnitTests.Features.Genres
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
                .Setup(mock => mock.Send(It.IsAny<GetAllQuery>(),It.IsAny<CancellationToken>()))
                .ReturnsAsync((List<GenreGetDTO>)null);
            //Act
            var result = await _classUnderTest.Get();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
            _mediator.Verify(mock => mock.Send(It.IsAny<GetAllQuery>(), It.IsAny<CancellationToken>()),Times.Once);
        }
    }
}
