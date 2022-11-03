using AlgoAirlines_BACKEND.DTO.Aeropuerto;
using AlgoAirlines_BACKEND.DTO.Avion;
using AlgoAirlines_BACKEND.DTO.Vuelo;
using AlgoAirlines_BACKEND.Entidades;
using AutoMapper;

namespace AlgoAirlines_BACKEND.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Vuelo, VueloDTO>()
                .ForMember(x => x.LugarSalida, options => options.MapFrom(MapearAeropuertoSalida))
                .ForMember(x => x.LugarLlegada, options => options.MapFrom(MapearAeropuertoLlegada))
                .ForMember(x => x.Avion, options => options.MapFrom(MapearAvion));

        }

        public AeropuertoDTO MapearAeropuertoSalida(Vuelo vuelo, VueloDTO vueloDto)
        {
            var aeropuertoDto = new AeropuertoDTO()
            {
                Id = vuelo.LugarSalida.Id,
                Nombre = vuelo.LugarSalida.Nombre,
                Ciudad = vuelo.LugarSalida.Ciudad,
            };

            return aeropuertoDto;

        }

        public AeropuertoDTO MapearAeropuertoLlegada(Vuelo vuelo, VueloDTO vueloDto)
        {
            var aeropuertoDto = new AeropuertoDTO()
            {
                Id = vuelo.LugarLlegada.Id,
                Nombre = vuelo.LugarLlegada.Nombre,
                Ciudad = vuelo.LugarLlegada.Ciudad,
            };

            return aeropuertoDto;

        }

        public AvionDTO MapearAvion(Vuelo vuelo, VueloDTO vueloDto)
        {
            var avionDto = new AvionDTO()
            {
                Id = vuelo.Avion.Id,
                Nombre = vuelo.Avion.Nombre,
                Capacidad = vuelo.Avion.Capacidad,
            };

            return avionDto;
        }
    }
}
