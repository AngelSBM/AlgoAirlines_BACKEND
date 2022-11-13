using AlgoAirlines_BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AlgoAirlines_BACKEND.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Aeropuerto> Aeropuertos { get; set; }
        public DbSet<Avion> Aviones { get; set; }
        public DbSet<Oficial> Oficiales { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<VueloPasajero> VuelosPasajeros { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pasajero>(pasajero =>
            {           
                pasajero.ToTable("Pasajeros");
                pasajero.HasKey(pasajero => pasajero.Id);
            });


            modelBuilder.Entity<Avion>(avion =>
            {
                avion.ToTable("Aviones");
                avion.HasKey(avion => avion.Id);

                avion.HasMany(a => a.Vuelos);
            });


            modelBuilder.Entity<Vuelo>(vuelo =>
            {
                vuelo.ToTable("Vuelos");
                vuelo.HasKey(vuelo => vuelo.Id);

                vuelo.HasOne(v => v.Avion)
                        .WithMany(a => a.Vuelos);

                vuelo.HasOne(v => v.LugarSalida)
                        .WithMany(a => a.VuelosSalida)
                        .HasForeignKey(a => a.IdLugarSalida)
                        .OnDelete(DeleteBehavior.NoAction);

                vuelo.HasOne(v => v.LugarLlegada)
                        .WithMany(a => a.VuelosLlegada)
                        .HasForeignKey(a => a.IdLugarLlegada)
                        .OnDelete(DeleteBehavior.NoAction);


            });

            modelBuilder.Entity<VueloPasajero>(vueloPasajero =>
            {
                vueloPasajero.ToTable("VuelosPasajeros");
                vueloPasajero.HasKey(vueloPasajero => vueloPasajero.Id);

                vueloPasajero.HasOne(vp => vp.Pasajero)
                            .WithMany(vp => vp.VuelosPasajeros);

                vueloPasajero.HasOne(vp => vp.Vuelo)
                            .WithMany(vp => vp.VuelosPasajeros);
            });


            //modelBuilder.Entity<Ticket>(ticket =>
            //{
            //    ticket.has
            //});
        }


    }
}
