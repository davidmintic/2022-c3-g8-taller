using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio.Entidades;

namespace Taller.App.Persistencia
{
    public class RepositorioMecanico
    {

        private readonly ContextDb dbContext;


        public RepositorioMecanico(ContextDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public Mecanico AgregarMecanico(Mecanico m)
        {
            Console.WriteLine("test" + m.MecanicoId);
            var mecanicoNuevo = this.dbContext.Mecanics.Add(m);
            this.dbContext.SaveChanges();
            return mecanicoNuevo.Entity;
        }

        public IEnumerable<Mecanico> ObtenerMecanicos()
        {
            return this.dbContext.Mecanics;
        }

        public Mecanico BuscarMecanico(string idMecanico)
        {
            return this.dbContext.Mecanics.FirstOrDefault(m => m.MecanicoId == idMecanico);
        }

        public void EditarMecanico(Mecanico mecanicoNuevo, string id)
        {
            var mecanicoActual = this.dbContext.Mecanics.FirstOrDefault(m => m.MecanicoId == id);
            if (mecanicoActual != null)
            {
                mecanicoActual.Nombre = mecanicoNuevo.Nombre;
                mecanicoActual.FechaNacimiento = mecanicoNuevo.FechaNacimiento;
                mecanicoActual.Telefono = mecanicoNuevo.Telefono;
                mecanicoActual.Contrasenia = mecanicoNuevo.Contrasenia;
                mecanicoActual.Rol = mecanicoNuevo.Rol;
                mecanicoActual.NivelEstudio = mecanicoNuevo.NivelEstudio;
                this.dbContext.SaveChanges();
            }
        }

        public void EliminarMecanico(string idMecanico)
        {
            var mecanicoEncontrado = this.dbContext.Mecanics.FirstOrDefault(m => m.MecanicoId == idMecanico);

            if (mecanicoEncontrado != null)
            {
                this.dbContext.Mecanics.Remove(mecanicoEncontrado);
                this.dbContext.SaveChanges();

            }
        }


    }
}