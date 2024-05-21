using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class indice_masa_corporalModel : PageModel
    {
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";
        public double imc = 0;

        public void OnPost()
        {
            double pesoDouble = Convert.ToDouble(peso);
            double alturaDouble = Convert.ToDouble(altura);

            imc = pesoDouble / (alturaDouble * alturaDouble);

            ModelState.Clear();
        }

        public void OnGet()
        {
        }
    }
}
