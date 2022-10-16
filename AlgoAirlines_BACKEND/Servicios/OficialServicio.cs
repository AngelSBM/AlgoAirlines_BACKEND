using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.DTO.Oficial;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;

namespace AlgoAirlines_BACKEND.Servicios
{
    public class OficialServicio : IOficialServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public OficialServicio(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public bool Login(LoginOficialDTO loginDto)
        {
            bool esAutentico;

            try
            {
                var oficial = _unitOfWork.oficialRepo.BuscarPor(oficial => oficial.Correo == loginDto.Email);
                if( oficial == null ) 
                {
                    throw new Exception("¡No está registrado!");
                }
                if(!(oficial.Password == loginDto.Password))
                {
                    throw new Exception("Contraseña incorrecta");
                }
                esAutentico = true;

            }
            catch (Exception e)
            {
                esAutentico = false;
                throw;
            }

            return esAutentico;
        }
    }
}
