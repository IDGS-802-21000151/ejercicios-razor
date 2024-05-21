using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EjerciciosRazorPages.Pages
{
    public class formulaModel : PageModel
    {
        public double? Resultado { get; private set; }
        public List<double> Resultados { get; private set; } = new List<double>();

        [BindProperty]
        public double ValorA { get; set; }

        [BindProperty]
        public double ValorB { get; set; }

        [BindProperty]
        public double ValorX { get; set; }

        [BindProperty]
        public double ValorY { get; set; }

        [BindProperty]
        public int NumeroN { get; set; }

        // Método recursivo
        private double CalculoFactorial(int num)
        {
            if (num == 0)
                return 1;

            return num * CalculoFactorial(num - 1);
        }

        public void OnPost()
        {
            Resultado = igualarValores(ValorA, ValorB, ValorX, ValorY, NumeroN);
        }

        private double igualarValores(double a, double b, double x, double y, int n)
        {
            double sumaFinal = 0;

            for (int k = 0; k <= n; k++)
            {
                double binomial = CalculoFactorial(n) / (CalculoFactorial(k) * CalculoFactorial(n - k));
                double termino = binomial * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
                sumaFinal += termino;
                Resultados.Add(termino);
            }

            return sumaFinal;
        }
    }
}
