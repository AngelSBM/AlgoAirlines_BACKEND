using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.DTO.Aeropuerto;
using AlgoAirlines_BACKEND.Entidades;

namespace AlgoAirlines_BACKEND.Servicios
{
    public class AeropuertoServicio : IAeropuertoServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public AeropuertoServicio(IUnitOfWork unidadDetrabajo)
        {
            this._unitOfWork = unidadDetrabajo;
        }


        public IEnumerable<Aeropuerto> ObtenerAeropuertos()
        {
            return _unitOfWork.aeropuertoRepo.ObtenerTodos();
        }

        public Aeropuerto NuevoAeropuerto(NuevoAeropuertoDTO nuevoAeropuerto)
        {
            Aeropuerto aeropuertoDB = new Aeropuerto();
            aeropuertoDB.Nombre = nuevoAeropuerto.Nombre;
            aeropuertoDB.Ciudad = nuevoAeropuerto.Ciudad;

            _unitOfWork.aeropuertoRepo.Agregar(aeropuertoDB);
            _unitOfWork.Guardar();

            return aeropuertoDB;

        }
    }
}
