namespace AlgoAirlines_BACKEND.DTO.Vuelo
{
    public class NuevoVueloDTO
    {
        public int IdLugarSalida { get; set; }
        public int IdLugarLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int IdAvion { get; set; }

    }
}