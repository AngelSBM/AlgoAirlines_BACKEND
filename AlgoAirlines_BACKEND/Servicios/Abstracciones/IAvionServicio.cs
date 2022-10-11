using AlgoAirlines_BACKEND.DTO.Avion;
using AlgoAirlines_BACKEND.Entidades;

namespace AlgoAirlines_BACKEND.Servicios.Abstracciones
{
    public interface IAvionServicio
    {
        public List<Avion> ObtenerAviones();
        public Avion AgregarAvion(NuevoAvionDTO nuevoAvion);
    }
}
