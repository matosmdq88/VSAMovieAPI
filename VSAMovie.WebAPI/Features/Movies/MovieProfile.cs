using AutoMapper;
using VSAMovie.WebAPI.Features.Movies.Create;
using VSAMovie.WebAPI.Features.Movies.Get;
using VSAMovie.WebAPI.Features.Movies.GetAll;
using VSAMovie.WebAPI.Features.Movies.Update;
using VSAMovie.WebAPI.Model;

namespace VSAMovie.WebAPI.Features.Movies
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieGetByIdDTO>()
                .ForMember(x => x.Genres, options => options.MapFrom(MapMoviesGenres));
            CreateMap<MovieDTO, Movie>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.MoviesGenres, options => options.MapFrom(MapMoviesGenresCreate));
            CreateMap<MoviePutDTO, Movie>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.MoviesGenres, options => options.MapFrom(MapMoviesGenresCreateForPut));
            CreateMap<Movie, MovieShowDTO>()
                .ForMember(x => x.Genres, options => options.MapFrom(MapMoviesGenresForPost));
            CreateMap<Movie, MovieGetDTO>();

        }

        private List<GenreForMovieGetDTO> MapMoviesGenres(Movie movie, MovieGetByIdDTO movieGetByIdDTO)
        {
            var result = new List<GenreForMovieGetDTO>();
            if (movie.MoviesGenres == null)
            {
                return result;
            }
            foreach (var MovieGenre in movie.MoviesGenres)
            {
                result.Add(new GenreForMovieGetDTO() { Name=MovieGenre.Genre.Name });
            }

            return result;
        }

        private List<MoviesGenres> MapMoviesGenresCreate(MovieDTO dto,Movie movie)
        {
            var resultado = new List<MoviesGenres>();
            if (dto.Genres == null)
            {
                return resultado;
            }
            foreach (var id in dto.Genres)
            {
                resultado.Add(new MoviesGenres() { GenreId = id });
            }

            return resultado;
        }

        private List<MoviesGenres> MapMoviesGenresCreateForPut(MoviePutDTO dto, Movie movie)
        {
            var resultado = new List<MoviesGenres>();
            if (dto.Genres == null)
            {
                return resultado;
            }
            foreach (var id in dto.Genres)
            {
                resultado.Add(new MoviesGenres() { GenreId = id });
            }

            return resultado;
        }

        private List<GenreForMovieShowDTO> MapMoviesGenresForPost(Movie movie, MovieShowDTO movieGetByIdDTO)
        {
            var result = new List<GenreForMovieShowDTO>();
            if (movie.MoviesGenres == null)
            {
                return result;
            }
            foreach (var MovieGenre in movie.MoviesGenres)
            {
                result.Add(new GenreForMovieShowDTO() { Name = MovieGenre.Genre.Name });
            }

            return result;
        }
    }
}
