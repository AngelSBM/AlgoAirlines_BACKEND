using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.DTO.Vuelo;
using AlgoAirlines_BACKEND.Entidades;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;
using AutoMapper;

namespace AlgoAirlines_BACKEND.Servicios
{
    public class VueloServicio : IVueloServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VueloServicio(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
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

        public List<VueloDTO> ObtenerVuelosFiltrados(VueloFiltroDTO filtros)
        {

            try
            {

                var vuelos = _unitOfWork.vueloRepo.ObtenerVuelos().Where(vuelo =>
                                                 (vuelo.IdLugarSalida == filtros.DesdeId && vuelo.IdLugarLlegada == filtros.HastaId
                                                || vuelo.IdLugarSalida == filtros.HastaId && vuelo.IdLugarLlegada == filtros.DesdeId) &&
                                                   vuelo.FechaSalida.DayOfYear == filtros.FechaDesde.DayOfYear || 
                                                   vuelo.FechaSalida.DayOfYear == filtros.FechaHasta.DayOfYear).ToList();



                var vuelosDto = new List<VueloDTO>();

                foreach (var vuelo in vuelos)
                {
                    vuelosDto.Add(_mapper.Map<Vuelo, VueloDTO>(vuelo));
                }

                return vuelosDto;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Vuelo> ObtenerVuelos()
        {
            var vuelos = _unitOfWork.vueloRepo.ObtenerTodos().ToList();
            return vuelos;
        }
    }
}