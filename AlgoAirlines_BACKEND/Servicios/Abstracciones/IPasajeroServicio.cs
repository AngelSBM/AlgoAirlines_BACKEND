using AlgoAirlines_BACKEND.DTO;
using AlgoAirlines_BACKEND.DTO.Pasajero;
using AlgoAirlines_BACKEND.Entidades;

namespace AlgoAirlines_BACKEND.Servicios.Abstracciones
{
    public interface IPasajeroServicio
    {
        public List<Pasajero> ObtenerPasajeros();
        public Pasajero CrearPasajero(NuevoPasajeroDTO nuevoPasajero);
    }
}
