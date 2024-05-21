using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class codificar_mensajeModel : PageModel
    {
        [BindProperty]
        public string mensaje { get; set; } = "";
        [BindProperty]
        public string valorN { get; set; } = "";

        public string mensajeCodificado = "";

        public void OnPost()
        {
            mensajeCodificado = CodificarMensaje(mensaje, Convert.ToInt16(valorN));
            ModelState.Clear();
        }

        private string CodificarMensaje(string mensaje, int posicionesN)
        {
            char[] buffer = mensaje.ToUpper().ToCharArray();
            const string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVXYZ";

            for (int i = 0; i < buffer.Length; i++)
            {
                char letra = buffer[i];

                if (alfabeto.Contains(letra))
                {
                    int indiceOriginal = alfabeto.IndexOf(letra);
                    int indiceCifrado = (indiceOriginal + posicionesN) % alfabeto.Length;
                    buffer[i] = alfabeto[indiceCifrado];
                }
            }
            return new string(buffer);
        }
        public void OnGet()
        {
        }
    }
}
