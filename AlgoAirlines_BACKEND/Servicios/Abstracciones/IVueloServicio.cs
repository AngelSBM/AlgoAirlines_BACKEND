using AlgoAirlines_BACKEND.DTO.Vuelo;
using AlgoAirlines_BACKEND.Entidades;

namespace AlgoAirlines_BACKEND.Servicios.Abstracciones
{
    public interface IVueloServicio
    {
        public Vuelo CrearVuelo(NuevoVueloDTO nuevoVuelo);
        public List<Vuelo> ObtenerVuelos();
        public List<VueloDTO> ObtenerVuelosFiltrados(VueloFiltroDTO filtros);
    }
}


