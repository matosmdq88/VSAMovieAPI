using AutoMapper;
using VSAMovie.WebAPI.Features.Genres.Create;
using VSAMovie.WebAPI.Features.Genres.GetAll;
using VSAMovie.WebAPI.Features.Genres.Update;
using VSAMovie.WebAPI.Model;

namespace VSAMovie.WebAPI.Features.Genres
{
    public class GenreProfile: Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreGetDTO>();
            CreateMap<Genre, GenreGetByIdDTO>();
            CreateMap<Genre, GenreShowDTO>();            
            CreateMap<GenreDTO, Genre>();
            CreateMap<GenrePutDTO, Genre>();
        }
    }
}
