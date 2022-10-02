namespace AlgoAirlines_BACKEND.Entidades
{
    public class Avion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }

        #region Relaciones
        public virtual ICollection<Vuelo> Vuelos { get; set; }
        #endregion
    }
}
