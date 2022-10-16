using AlgoAirlines_BACKEND.DTO.Oficial;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;
using Microsoft.AspNetCore.Mvc;

namespace AlgoAirlines_BACKEND.Controllers
{
    [ApiController]
    [Route("Oficial")]
    public class OficialController : ControllerBase
    {
        private readonly IOficialServicio _oficialServicio;

        public OficialController(IOficialServicio oficialServicio)
        {
            _oficialServicio = oficialServicio;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginOficialDTO loginDto)
        {
            try
            {
                var retorno = _oficialServicio.Login(loginDto);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
