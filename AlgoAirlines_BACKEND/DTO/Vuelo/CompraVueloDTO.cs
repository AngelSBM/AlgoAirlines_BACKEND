using AlgoAirlines_BACKEND.DTO.Pasajero;

namespace AlgoAirlines_BACKEND.DTO.Vuelo
{
    public class CompraVueloDTO
    {
        public int VueloIdaId { get; set; }
        public int VueloVueltaId { get; set; }
        public List<NuevoPasajeroDTO> Pasajeros { get; set; }
        public string MailConfirmacion { get; set; }
    }
}
