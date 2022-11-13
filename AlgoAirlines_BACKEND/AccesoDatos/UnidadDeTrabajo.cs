using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.Entidades;

namespace AlgoAirlines_BACKEND.AccesoDatos
{
    public class UnidadDeTrabajo : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IRepositorio<Aeropuerto> aeropuertoRepo { get; set; }
        public IRepositorio<Avion> avionRepo { get; set; }
        public IRepositorio<Pasajero> pasajeroRepo { get; set; }
        public IVueloRepositorio vueloRepo { get; set; }
        public IRepositorio<VueloPasajero> vueloPasajeroRepo { get; set; }
        public IRepositorio<Ticket> ticketRepo { get; set; }
        public IRepositorio<Oficial> oficialRepo { get; set; }

        public UnidadDeTrabajo
            (
                ApplicationDbContext _context,
                IRepositorio<Pasajero> _pasajeroRepo,
                IRepositorio<Aeropuerto> _aeropuertoRepo,
                IRepositorio<Avion> _avionRepo,
                IVueloRepositorio _vueloRepo,
                IRepositorio<Oficial> _oficialRepo,
                IRepositorio<VueloPasajero> _vueloPasajeroRepo,
                IRepositorio<Ticket> _ticketRepo
            )
        {
            this.context = _context;
            this.aeropuertoRepo = _aeropuertoRepo;
            this.pasajeroRepo = _pasajeroRepo;
            this.avionRepo = _avionRepo;
            this.vueloRepo = _vueloRepo;
            this.vueloPasajeroRepo = _vueloPasajeroRepo;
            this.ticketRepo = _ticketRepo;
            this.oficialRepo = _oficialRepo;
        }

        public void ComenzarTransaccion()
        {
            context.Database.BeginTransaction();
        }

        public void CompletarTransaccion()
        {
            context.Database.CommitTransaction();
        }

        public void CancelarTransaccion()
        {
            context.Database.RollbackTransaction();
        }

        public void Guardar()
        {
            context.SaveChanges();
        }


    }
}
