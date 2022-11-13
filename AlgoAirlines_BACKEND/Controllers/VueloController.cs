using AlgoAirlines_BACKEND.DTO.Vuelo;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;
using Microsoft.AspNetCore.Mvc;

namespace AlgoAirlines_BACKEND.Controllers
{
    [ApiController]
    [Route("Vuelo")]
    public class VueloController : ControllerBase
    {

        private readonly IVueloServicio _vueloServicio;

        public VueloController(IVueloServicio vueloServicio)
        {
            this._vueloServicio = vueloServicio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var respuesta = _vueloServicio.ObtenerVuelos();
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPost]
        public IActionResult Post(NuevoVueloDTO nuevoVuelo)
        {
            try
            {
                var respuesta = _vueloServicio.CrearVuelo(nuevoVuelo);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPost("Filtro")]
        public IActionResult Filtro(VueloFiltroDTO filtro)
        {
            try
            {
                var respuesta = _vueloServicio.ObtenerVuelosFiltrados(filtro);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpGet("Tickets")]
        public IActionResult Tickets()
        {
            try
            {
                var respuesta = _vueloServicio.ObtenerTickets();
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [HttpPost("Agendar")]
        public IActionResult Agendar(CompraVueloDTO agenda)
        {
            try
            {
                var respuesta = _vueloServicio.AgendarVuelos(agenda);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpGet("Reservaciones")]
        public IActionResult Reservaciones(int vueloId)
        {
            try
            {
                var respuesta = _vueloServicio.AsientosReservados(vueloId);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        //[HttpGet("EnviarCorreo")]
        //public IActionResult EnviarCorreo(string to)
        //{
        //    try
        //    {
        //        _vueloServicio.EnviarEmail(to);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);

        //    }
        //}
    }
}
