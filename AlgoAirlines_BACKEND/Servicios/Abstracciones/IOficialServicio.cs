using AlgoAirlines_BACKEND.DTO.Oficial;

namespace AlgoAirlines_BACKEND.Servicios.Abstracciones
{
    public interface IOficialServicio
    {
        public bool Login(LoginOficialDTO loginDto);
    }
}
