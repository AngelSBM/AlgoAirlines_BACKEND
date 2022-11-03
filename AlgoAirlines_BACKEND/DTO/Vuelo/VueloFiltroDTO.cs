namespace AlgoAirlines_BACKEND.DTO.Vuelo
{
    public class VueloFiltroDTO
    {
        public int DesdeId { get; set; }
        public int HastaId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

    }
}
