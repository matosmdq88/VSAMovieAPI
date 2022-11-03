using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;
using VSAMovie.WebAPI.Features.Genres.GetAll;
using VSAMovie.WebAPI.Model;

namespace VSAMovie.Test.UnitTest.GenreTest
{
    [TestClass]
    public class GetAllTest : BaseTest
    {
        private readonly IMapper _mapper;
        public GetAllTest(IConfiguration configuration) : base(configuration)
        { 
            _mapper = ConfiguringAutomapper();
        }

        [TestMethod]
        public async Task GetAll()
        {
            //Arrange
            var nameDB = Guid.NewGuid().ToString();
            var context = BuildContext(nameDB);
            context.Genres.Add(new Genre() { Name = "Genre 1" });
            context.Genres.Add(new Genre() { Name = "Genre 2" });
            await context.SaveChangesAsync();
            
            //Act
            var context2=BuildContext(nameDB);
            var handler = new GetAllHandler(context2,_mapper);
            var result = await handler.Handle(new GetAllQuery(), CancellationToken.None);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Get()
        {
            Assert.IsTrue(true);
        }
    }
}
