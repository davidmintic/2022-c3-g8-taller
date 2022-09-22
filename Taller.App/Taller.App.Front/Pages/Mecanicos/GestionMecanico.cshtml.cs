using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Taller.App.Front.Pages
{
    public class GestionMecanicoModel : PageModel
    {
        private static RepositorioMecanico repoMecanico = new RepositorioMecanico(
          new Persistencia.ContextDb()
      );

        private static RepositorioRevision repoRevision = new RepositorioRevision(
            new Persistencia.ContextDb()
        );

        public string titulo { get; set; } = "";

        public List<Mecanico> listaMecanicos = new List<Mecanico>();

        public Mecanico mecanicoActual;

        public void OnGet()
        {
            this.ObtenerMecanicos();
        }


        public void OnPostAdd(Mecanico mecanico)
        {
            try
            {
                repoMecanico.AgregarMecanico(mecanico);
                this.ObtenerMecanicos();
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public void OnPostAddRevision(Revision revision)
        {
            try
            {
                // var mecanico = repoMecanico.BuscarMecanico(revision.MecanicoId);
                // revision.Mecanico = mecanico;
                repoRevision.AgregarRevision(revision);
                this.ObtenerMecanicos();
            }
            catch (System.Exception)
            {

                throw;
            }

        }



        public void OnPostDelete(string id)
        {
            try
            {
                repoMecanico.EliminarMecanico(id);
                this.ObtenerMecanicos();
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        private void ObtenerMecanicos()
        {
            // Console.WriteLine("prueba: " + repoMecanico.ObtenerMecanicos());

            foreach (Mecanico mecanico in repoMecanico.ObtenerMecanicos())
            {
                this.listaMecanicos.Add(new Mecanico()
                {
                    MecanicoId = mecanico.MecanicoId,
                    NivelEstudio = mecanico.NivelEstudio,
                    Nombre = mecanico.Nombre,
                    Telefono = mecanico.Telefono,
                    Rol = mecanico.Rol,
                    Contrasenia = mecanico.Contrasenia,
                    FechaNacimiento = mecanico.FechaNacimiento
                });
            }
        }
    }


}
