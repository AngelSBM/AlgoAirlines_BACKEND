namespace AlgoAirlines_BACKEND.Entidades
{
    public class Ticket
    {
        public int Id { get; set; }
        public int VueloId { get; set; }
        public int PasajeroId { get; set; }
        public int NumeroAsiento { get; set; }
        public int TipoTicket { get; set; }
        public bool Confirmado { get; set; }

        #region Relaciones
        public virtual Vuelo Vuelo { get; set; }
        public virtual Pasajero Pasajero { get; set; }
        #endregion
    }
}
