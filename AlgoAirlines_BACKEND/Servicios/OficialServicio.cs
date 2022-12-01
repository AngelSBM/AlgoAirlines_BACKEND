using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.DTO.Oficial;
using AlgoAirlines_BACKEND.Entidades;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

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

             
                if (!(oficial.Password == hashPassword(loginDto.Password)))
                {
                    throw new Exception("Contraseña incorrecta");
                }


                esAutentico = true;

            }
            catch (Exception e)
            {
                esAutentico = false;
                throw e;
            }

            return esAutentico;
        }


        public void Registrar(RegisterUserDto registerDto)
        {


            try
            {
                var oficial = _unitOfWork.oficialRepo.BuscarPor(oficial => oficial.Correo == registerDto.Email);
                if (!(oficial == null))
                {
                    throw new Exception("Ya hay un usuario con este registro");
                }


                //SHA256 sha256 = SHA256Managed.Create(); //utf8 here as well
                //byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
                //string result = Convert.ToBase64String(bytes);

                var nuevoOficial = new Oficial()
                {
                    Activo = 1,
                    Correo = registerDto.Email,
                    Nombre = registerDto.Nombre,
                    Password = hashPassword(registerDto.Password),
                };

                _unitOfWork.oficialRepo.Agregar(nuevoOficial);
                _unitOfWork.Guardar();

            }
            catch (Exception e)
            {

                throw e;
            }

        }



        private string hashPassword(string password)
        {
            SHA256 sha256 = SHA256Managed.Create(); //utf8 here as well
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            string result = Convert.ToBase64String(bytes);

            return  result;
        }

    }
}
