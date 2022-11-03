using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AlgoAirlines_BACKEND.AccesoDatos.Repositorios
{
    public class VueloRepositorio : Repositorio<Vuelo>, IVueloRepositorio
    {
        private ApplicationDbContext _context;
        public VueloRepositorio(ApplicationDbContext context) : base(context) 
        {
            this._context = context;
        }

        public List<Vuelo> ObtenerVuelos()
        {
            return _context.Set<Vuelo>()
                    .Include(vuelo => vuelo.LugarLlegada)
                    .Include(vuelo => vuelo.LugarLlegada)
                    .Include(vuelo => vuelo.Avion)
                    .ToList();
        }
    }
}
