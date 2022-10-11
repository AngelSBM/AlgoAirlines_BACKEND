using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.DTO.Vuelo;
using AlgoAirlines_BACKEND.Entidades;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;

namespace AlgoAirlines_BACKEND.Servicios
{
    public class VueloServicio : IVueloServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public VueloServicio(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Vuelo CrearVuelo(NuevoVueloDTO nuevoVuelo)
        {
            try
            {
                var vueloDB = new Vuelo();
                vueloDB.IdLugarSalida = nuevoVuelo.IdLugarSalida;
                vueloDB.IdLugarLlegada = nuevoVuelo.IdLugarLlegada;
                vueloDB.FechaSalida = nuevoVuelo.FechaSalida;
                vueloDB.FechaLlegada = nuevoVuelo.FechaLlegada;
                vueloDB.AvionId = nuevoVuelo.IdAvion;

                //var avionDB = _unitOfWork.avionRepo.ObtenerPorId(nuevoVuelo.IdAvion);

                _unitOfWork.vueloRepo.Agregar(vueloDB);


                _unitOfWork.Guardar();
                return vueloDB;
            }
            catch (Exception)
            {
                throw new Exception("Algo salió mal, por favor contacte al departamento de TI");
            }

        }

        public List<Vuelo> ObtenerVuelos()
        {
            var vuelos = _unitOfWork.vueloRepo.ObtenerTodos().ToList();
            return vuelos;
        }
    }
}