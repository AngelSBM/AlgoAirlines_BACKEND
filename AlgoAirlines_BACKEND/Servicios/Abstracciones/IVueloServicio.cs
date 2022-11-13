using AlgoAirlines_BACKEND.DTO.Vuelo;
using AlgoAirlines_BACKEND.Entidades;

namespace AlgoAirlines_BACKEND.Servicios.Abstracciones
{
    public interface IVueloServicio
    {
        public Vuelo CrearVuelo(NuevoVueloDTO nuevoVuelo);
        public List<Vuelo> ObtenerVuelos();
        public List<VueloDTO> ObtenerVuelosFiltrados(VueloFiltroDTO filtros);
        public List<Ticket> ObtenerTickets();
        public List<Ticket> AgendarVuelos(CompraVueloDTO agendaInfo);
        public List<int> AsientosReservados(int vueloId);
        //public void EnviarEmail(string to);
    }
}


