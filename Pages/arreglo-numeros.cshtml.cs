using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class arreglo_numerosModel : PageModel
    {
        public List<int> NumerosAleatorios { get; set; } = new List<int>();
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; } = new List<int>();
        public int Mediana { get; set; }
        public List<int> numerosAleatoriosOrdenados { get; set; }

        public void OnGet()
        {
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                NumerosAleatorios.Add(random.Next(0, 101));
            }

            Suma = NumerosAleatorios.Sum();
            Promedio = NumerosAleatorios.Average();

            var grupoNumeros = NumerosAleatorios.GroupBy(n => n);
            int maxRepeticiones = grupoNumeros.Max(g => g.Count());
            Moda = grupoNumeros.Where(g => g.Count() == maxRepeticiones).Select(g => g.Key).ToList();

            Mediana = NumerosAleatorios[NumerosAleatorios.Count / 2];
        }
    }
}
