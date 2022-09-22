using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Taller.App.Persistencia
{
    public class ContextDb : DbContext
    {
        public virtual DbSet<Mecanico> Mecanics { get; set; }
        public virtual DbSet<Revision> Revisions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (!optionsBuilder.IsConfigured)
                {

                    optionsBuilder.UseSqlServer("Server=tcp:server-tallertic.database.windows.net,1433;Initial Catalog=bd_tallertic;Persist Security Info=False;User ID=admintaller;Password=tallerTic2020#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Oucrrió un error en OnConfiguring");
                throw;
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Revision>()
            //     .HasOne(b => b.Mecanico)
            //     .WithOne(i => i.Revision)
            //     .HasForeignKey<Revision>(b => b.MecanicoId);
        }
    }
}