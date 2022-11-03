using AlgoAirlines_BACKEND.Entidades;

namespace AlgoAirlines_BACKEND.AccesoDatos.Abstracciones
{
    public interface IVueloRepositorio : IRepositorio<Vuelo>
    {
        public List<Vuelo> ObtenerVuelos();
    }
}
