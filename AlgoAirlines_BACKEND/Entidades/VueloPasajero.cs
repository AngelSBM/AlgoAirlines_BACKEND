namespace AlgoAirlines_BACKEND.Entidades
{
    public class VueloPasajero
    {
        public int Id { get; set; }
        public int IdVuelo { get; set; }
        public int IdPasajero { get; set; }

        #region Relaciones
        public virtual Vuelo Vuelo { get; set; }
        public virtual Pasajero Pasajero { get; set; }
        #endregion
    }
}
