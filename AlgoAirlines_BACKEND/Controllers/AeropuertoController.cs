using AlgoAirlines_BACKEND.DTO.Aeropuerto;
using AlgoAirlines_BACKEND.Entidades;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;
using Microsoft.AspNetCore.Mvc;

namespace AlgoAirlines_BACKEND.Controllers
{
    [ApiController]
    [Route("Aeropuerto")]
    public class AeropuertoController : ControllerBase
    {

        private readonly IAeropuertoServicio _aeropuertoServicio;

        public AeropuertoController(IAeropuertoServicio _aeropuertoServicio)
        {
            this._aeropuertoServicio = _aeropuertoServicio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var respuesta = _aeropuertoServicio.ObtenerAeropuertos();
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                
            }
        }

        [HttpPost]
        public IActionResult Post(NuevoAeropuertoDTO nuevoAeropuerto)
        {
            try
            {
                var respuesta = _aeropuertoServicio.NuevoAeropuerto(nuevoAeropuerto);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
