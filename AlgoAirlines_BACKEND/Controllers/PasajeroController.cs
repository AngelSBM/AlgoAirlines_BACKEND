using AlgoAirlines_BACKEND.DTO.Avion;
using AlgoAirlines_BACKEND.DTO.Pasajero;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;
using Microsoft.AspNetCore.Mvc;

namespace AlgoAirlines_BACKEND.Controllers
{
    [ApiController]
    [Route("Pasajero")]
    public class PasajeroController : ControllerBase
    {

        private readonly IPasajeroServicio _pasajeroServicio;

        public PasajeroController(IPasajeroServicio pasajeroServicio)
        {
            this._pasajeroServicio = pasajeroServicio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var respuesta = _pasajeroServicio.ObtenerPasajeros();
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPost]
        public IActionResult Post(NuevoPasajeroDTO nuevoPasajero)
        {
            try
            {
                var respuesta = _pasajeroServicio.CrearPasajero(nuevoPasajero);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
