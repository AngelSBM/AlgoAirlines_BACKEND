using AlgoAirlines_BACKEND.DTO.Avion;
using AlgoAirlines_BACKEND.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace AlgoAirlines_BACKEND.Controllers
{
    [ApiController]
    [Route("Avion")]
    public class AvionController : ControllerBase
    {

        private readonly IAvionServicio _avionServicio;

        public AvionController(IAvionServicio avionServicio)
        {
            this._avionServicio = avionServicio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var respuesta = _avionServicio.ObtenerAviones();
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPost]
        public IActionResult Post(NuevoAvionDTO nuevoAvion)
        {
            try
            {
                var respuesta = _avionServicio.AgregarAvion(nuevoAvion);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
