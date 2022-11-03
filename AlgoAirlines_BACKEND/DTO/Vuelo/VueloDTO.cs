using AlgoAirlines_BACKEND.DTO.Aeropuerto;
using AlgoAirlines_BACKEND.DTO.Avion;
using AlgoAirlines_BACKEND.Entidades;


namespace AlgoAirlines_BACKEND.DTO.Vuelo
{
    public class VueloDTO
    {
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public AvionDTO Avion { get; set; }
        public AeropuertoDTO LugarSalida { get; set; }
        public AeropuertoDTO LugarLlegada { get; set; }

    }
}
