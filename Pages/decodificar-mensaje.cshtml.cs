using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class decodificar_mensajeModel : PageModel
    {
        [BindProperty]
        public string mensaje { get; set; } = "";
        [BindProperty]
        public string valorN { get; set; } = "";

        public string mensajeCodificado = "";

        public void OnPost()
        {
            mensajeCodificado = DecodificarMensaje(mensaje, Convert.ToInt16(valorN));
            ModelState.Clear();
        }

        private string DecodificarMensaje(string mensaje, int posicionesN)
        {
            char[] buffer = mensaje.ToUpper().ToCharArray();
            const string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVXYZ";

            for (int i = 0; i < buffer.Length; i++)
            {
                char letra = buffer[i];

                if (alfabeto.Contains(letra))
                {
                    int indiceOriginal = alfabeto.IndexOf(letra);
                    // Cambio en la dirección del desplazamiento para decodificar
                    int indiceDecifrado = (indiceOriginal - posicionesN + alfabeto.Length) % alfabeto.Length;
                    buffer[i] = alfabeto[indiceDecifrado];
                }
            }
            return new string(buffer);
        }
    }
}
