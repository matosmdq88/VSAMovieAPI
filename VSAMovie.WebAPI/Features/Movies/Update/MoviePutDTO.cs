using Microsoft.AspNetCore.Mvc;
using VSAMovie.WebAPI.Helpers;
using VSAMovie.WebAPI.Validaciones;

namespace VSAMovie.WebAPI.Features.Movies.Update
{
    public class MoviePutDTO
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        [PesoArchivoValidacion(pesoMaximo: 4)]
        [TipoArchivoValidacion(GrupoTipoArchivo.Imagen)]
        public IFormFile? Poster { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> Genres { get; set; }
    }
}
