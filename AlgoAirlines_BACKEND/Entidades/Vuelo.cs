namespace AlgoAirlines_BACKEND.Entidades
{
    public class Vuelo
    {
        public int Id { get; set; }
        public int IdLugarSalida { get; set; }
        public int IdLugarLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int AvionId { get; set; }

        #region Relaciones
        public virtual Avion Avion { get; set; }
        public virtual Aeropuerto LugarSalida { get; set; }
        public virtual Aeropuerto LugarLlegada { get; set; }
        public virtual ICollection<VueloPasajero> VuelosPasajeros { get; set; }

        #endregion
    }
}
