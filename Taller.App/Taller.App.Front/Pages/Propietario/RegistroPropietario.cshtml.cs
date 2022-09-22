using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Taller.App.Front.Pages
{
    public class RegistroPropietarioModel : PageModel
    {

        public List<String> ciudades = new List<String>(){
            "Bogotá", "Medellín", "Manizales", "Barranquilla"
        };

        public void OnGet()
        {
        }
    }
}
