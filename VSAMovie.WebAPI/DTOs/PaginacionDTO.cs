namespace VSAMovie.WebAPI.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } =  1;
        private int cantRegistrosPagina = 10;
        private readonly int cantMaximaRegistrosPagina = 50;

        public int CantidadRegistrosPagina
        {
            get => cantRegistrosPagina;
            set
            {
                cantRegistrosPagina = (value> cantMaximaRegistrosPagina) ? cantMaximaRegistrosPagina : value;
            }
        }
    }
}
