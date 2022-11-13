using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.DTO.Pasajero;
using AlgoAirlines_BACKEND.Entidades;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;

namespace AlgoAirlines_BACKEND.Servicios
{
    public class PasajeroServicio : IPasajeroServicio
    {
        private readonly IUnitOfWork _unidadDeTrabajo;

        public PasajeroServicio(IUnitOfWork unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public Pasajero CrearPasajero(NuevoPasajeroDTO nuevoPasajero)
        {
            var pasajeroDB = new Pasajero();
            pasajeroDB.Nombre = nuevoPasajero.Nombre;
            pasajeroDB.NumeroPasaporte = nuevoPasajero.NumeroPasaporte;
            pasajeroDB.Cedula = nuevoPasajero.Cedula;
            //pasajeroDB.Sexo = nuevoPasajero.Sexo;
            pasajeroDB.FechaNacimiento = nuevoPasajero.FechaNacimiento;

            _unidadDeTrabajo.pasajeroRepo.Agregar(pasajeroDB);
            _unidadDeTrabajo.Guardar();

            return pasajeroDB;

        }

        public List<Pasajero> ObtenerPasajeros()
        {
            var pasajeros = _unidadDeTrabajo.pasajeroRepo.ObtenerTodos().ToList();
            return pasajeros;
        }
    }
}
