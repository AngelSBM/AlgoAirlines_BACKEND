using AlgoAirlines_BACKEND.Entidades;

namespace AlgoAirlines_BACKEND.AccesoDatos.Abstracciones
{
    public interface IUnitOfWork
    {
        public IRepositorio<Aeropuerto> aeropuertoRepo { get; set; }
        public IRepositorio<Avion> avionRepo { get; set; }
        public IRepositorio<Pasajero> pasajeroRepo { get; set; }
        public IVueloRepositorio vueloRepo { get; set; }
        public IRepositorio<VueloPasajero> vueloPasajeroRepo { get; set; }
        public IRepositorio<Oficial> oficialRepo { get; set; }
        public void Guardar();
    }
}
