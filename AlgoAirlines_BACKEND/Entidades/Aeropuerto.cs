namespace AlgoAirlines_BACKEND.Entidades
{
    public class Aeropuerto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Ciudad { get; set; }


        #region Relaciones
        public virtual ICollection<Vuelo> VuelosSalida { get; set; }
        public virtual ICollection<Vuelo> VuelosLlegada { get; set; }
        #endregion
    }
}
