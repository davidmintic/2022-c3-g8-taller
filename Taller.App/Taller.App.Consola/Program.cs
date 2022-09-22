using System;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;
namespace Taller.App.Consola
{

    class Program
    {

        private static RepositorioMecanico repoMecanico = new RepositorioMecanico(
            new Persistencia.ContextDb()
        );

        static void Main(string[] args)
        {
            AgregarMecanico();
            // ObtenerMecanicos();
            // EditarMecanico("23");
            // BuscarMecanico("23");
            // EliminarMecanico("27");
        }

        static void AgregarMecanico()
        {
            var mecanico = new Mecanico
            {
                MecanicoId = "30",
                Nombre = "Lina",
                FechaNacimiento = "31/12/2000",
                NivelEstudio = "QA",
                Telefono = "345",
                Contrasenia = "678",
                Rol = "Mecanico"
            };
            repoMecanico.AgregarMecanico(mecanico);
        }

        static void ObtenerMecanicos()
        {
            // Console.WriteLine("prueba: " + repoMecanico.ObtenerMecanicos());

            foreach (Mecanico mecanico in repoMecanico.ObtenerMecanicos())
            {
                Console.WriteLine(mecanico.MecanicoId + ", Nombre: " + mecanico.Nombre);
            }
        }

        static void BuscarMecanico(string id)
        {

            var mecanico = repoMecanico.BuscarMecanico(id);
            Console.WriteLine("---------");
            Console.WriteLine("Nombre: " + mecanico.Nombre + "\nNivel estudio: " + mecanico.NivelEstudio);
            Console.WriteLine("---------");
        }

        static void EditarMecanico(string id)
        {

            var mecanico = new Mecanico
            {
                MecanicoId = "",
                Nombre = "Fercho",
                FechaNacimiento = "20",
                NivelEstudio = "Profesional",
                Telefono = "123",
                Contrasenia = "123",
                Rol = "jefeoperaciones"
            };
            repoMecanico.EditarMecanico(mecanico, id);
        }


        static void EliminarMecanico(string id)
        {
            repoMecanico.EliminarMecanico(id);
        }

    }
}