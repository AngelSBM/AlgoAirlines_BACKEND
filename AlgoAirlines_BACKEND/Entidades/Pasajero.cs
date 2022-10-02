namespace AlgoAirlines_BACKEND.Entidades
{
    public class Pasajero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cedula { get; set; }
        public string NumeroPasaporte { get; set; }
        public string Sexo { get; set; }

        #region Relaciones
        public virtual ICollection<VueloPasajero> VuelosPasajeros { get; set; }
        #endregion
    }
}
