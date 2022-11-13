using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using AlgoAirlines_BACKEND.DTO.Pasajero;
using AlgoAirlines_BACKEND.DTO.Vuelo;
using AlgoAirlines_BACKEND.Entidades;
using AlgoAirlines_BACKEND.Servicios.Abstracciones;
using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using MimeKit;
using MimeKit.Text;
using System.Net.Mail;

namespace AlgoAirlines_BACKEND.Servicios
{
    public class VueloServicio : IVueloServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public VueloServicio(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._env = env;
        }

        public Vuelo CrearVuelo(NuevoVueloDTO nuevoVuelo)
        {
            try
            {
                var vueloDB = new Vuelo();
                vueloDB.IdLugarSalida = nuevoVuelo.IdLugarSalida;
                vueloDB.IdLugarLlegada = nuevoVuelo.IdLugarLlegada;
                vueloDB.FechaSalida = nuevoVuelo.FechaSalida;
                vueloDB.FechaLlegada = nuevoVuelo.FechaLlegada;
                vueloDB.AvionId = nuevoVuelo.IdAvion;

                //var avionDB = _unitOfWork.avionRepo.ObtenerPorId(nuevoVuelo.IdAvion);

                _unitOfWork.vueloRepo.Agregar(vueloDB);


                _unitOfWork.Guardar();
                return vueloDB;
            }
            catch (Exception)
            {
                throw new Exception("Algo salió mal, por favor contacte al departamento de TI");
            }

        }

        public List<VueloDTO> ObtenerVuelosFiltrados(VueloFiltroDTO filtros)
        {

            try
            {

                var vuelos = _unitOfWork.vueloRepo.ObtenerVuelos().Where(vuelo =>
                                                 (vuelo.IdLugarSalida == filtros.DesdeId && vuelo.IdLugarLlegada == filtros.HastaId
                                                || vuelo.IdLugarSalida == filtros.HastaId && vuelo.IdLugarLlegada == filtros.DesdeId) &&
                                                   vuelo.FechaSalida.DayOfYear == filtros.FechaDesde.DayOfYear || 
                                                   vuelo.FechaSalida.DayOfYear == filtros.FechaHasta.DayOfYear).ToList();



                var vuelosDto = new List<VueloDTO>();

                foreach (var vuelo in vuelos)
                {
                    vuelosDto.Add(_mapper.Map<Vuelo, VueloDTO>(vuelo));
                }

                return vuelosDto;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Ticket> ObtenerTickets()
        {
            var tickets = _unitOfWork.ticketRepo.ObtenerTodos().ToList();
            return tickets;
        }


        public List<Ticket> AgendarVuelos(CompraVueloDTO agendaInfo)
        {

            try
            {
                
                var tickets = new List<Ticket>();
                _unitOfWork.ComenzarTransaccion();

                foreach (var pasajero in agendaInfo.Pasajeros)
                {
                    var pasajeroDB = _mapper.Map<NuevoPasajeroDTO, Pasajero>(pasajero);
                    _unitOfWork.pasajeroRepo.Agregar(pasajeroDB);
                    _unitOfWork.Guardar();


                    var ticketIda = new Ticket()
                    {
                        NumeroAsiento = pasajero.NumeroAsientoIda,
                        PasajeroId = pasajeroDB.Id,
                        VueloId = agendaInfo.VueloIdaId,
                        TipoTicket = 1,
                        Confirmado = false,
                    };

                    var ticketVuelta = new Ticket()
                    {
                        NumeroAsiento = pasajero.NumeroAsientoVuelta,
                        PasajeroId = pasajeroDB.Id,
                        VueloId = agendaInfo.VueloVueltaId,
                        TipoTicket = 2,
                        Confirmado = false,
                    };

                    _unitOfWork.ticketRepo.Agregar(ticketIda);
                    _unitOfWork.ticketRepo.Agregar(ticketVuelta);

                    tickets.Add(ticketIda);
                    tickets.Add(ticketVuelta);

                }

                _unitOfWork.CompletarTransaccion();
                _unitOfWork.Guardar();


                var template = ConstruirTemplateRecibo(agendaInfo);
                EnviarEmail(agendaInfo.MailConfirmacion, template);

                return tickets;


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                throw;
            }

        }


        public List<int> AsientosReservados(int vueloId)
        {
            try
            {
                var lista = new List<int>();

                var tickets = _unitOfWork.ticketRepo.ObtenerTodos().Where(ticket => ticket.VueloId == vueloId).ToList();
                foreach (var ticket in tickets)
                {
                    lista.Add(ticket.NumeroAsiento);
                }

                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Vuelo> ObtenerVuelos()
        {
            var vuelos = _unitOfWork.vueloRepo.ObtenerTodos().ToList();
            return vuelos;
        }

        public BodyBuilder ConstruirTemplateRecibo(CompraVueloDTO info)
        {
            string asientosIda = "";
            string asientosVuelta = "";
            foreach (var pasajero in info.Pasajeros)
            {
                asientosIda += " " + pasajero.NumeroAsientoIda + " ";
                asientosVuelta += " " + pasajero.NumeroAsientoVuelta + " ";
            }

            var bodyBuilder = new BodyBuilder();
            string texto = string.Empty;

            using(StreamReader reader = new StreamReader(_env.ContentRootPath + "static/mailTemplate.html"))
            {
                texto = reader.ReadToEnd();
            }

            var vueloIda = _unitOfWork.vueloRepo.ObtenerPorId(info.VueloIdaId);
            var vueloVuelta = _unitOfWork.vueloRepo.ObtenerPorId(info.VueloVueltaId);


            texto = texto.Replace("{numeroVueloIda}", vueloIda.PublicId.ToString());
            texto = texto.Replace("{numeroVueloVuelta}", vueloVuelta.PublicId.ToString());
            texto = texto.Replace("{asientosIda}", asientosIda);
            texto = texto.Replace("{asientosVuelta}", asientosVuelta);
            texto = texto.Replace("{fechaIda}", vueloIda.FechaSalida.ToString());
            texto = texto.Replace("{fechaVuelta}", vueloVuelta.FechaSalida.ToString());
            texto = texto.Replace("{asientosVuelta}", asientosVuelta);


            bodyBuilder.HtmlBody = texto;

            return bodyBuilder;
        }

        public void EnviarEmail(string to, BodyBuilder template)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("emisorstar@gmail.com"));
            email.To.Add(MailboxAddress.Parse("angelsebastianbellomateo@gmail.com"));
            email.Subject = "RECIBO DE TICKETS";
            email.Body = template.ToMessageBody();
            


            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587);
            smtp.Authenticate("emisorstar@gmail.com", "odxhlqmpsvjeoyph");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}