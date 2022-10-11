using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.DTO.Avion;
using AlgoAirlines_BACKEND.Entidades;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;

namespace AlgoAirlines_BACKEND.Servicios
{
    public class AvionServicio : IAvionServicio
    {

        private readonly IUnitOfWork _unitOfWork;

        public AvionServicio(IUnitOfWork unidadDetrabajo)
        {
            this._unitOfWork = unidadDetrabajo;
        }

        public Avion AgregarAvion(NuevoAvionDTO nuevoAvion)
        {
            var avionDB = new Avion();
            avionDB.Nombre = nuevoAvion.Nombre;
            avionDB.Capacidad = nuevoAvion.Capacidad;
            _unitOfWork.avionRepo.Agregar(avionDB);
            _unitOfWork.Guardar();
            return avionDB;

        }

        public List<Avion> ObtenerAviones()
        {
            
            var aviones = _unitOfWork.avionRepo.ObtenerTodos().ToList();
            return aviones;
            
        }
    }
}
