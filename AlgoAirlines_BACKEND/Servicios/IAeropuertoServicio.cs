using AlgoAirlines_BACKEND.DTO.Aeropuerto;
using AlgoAirlines_BACKEND.Entidades;

namespace AlgoAirlines_BACKEND.Servicios
{
    public interface IAeropuertoServicio
    {
        public IEnumerable<Aeropuerto> ObtenerAeropuertos();
        public Aeropuerto NuevoAeropuerto(NuevoAeropuertoDTO nuevoAeropuerto);
    }
}
