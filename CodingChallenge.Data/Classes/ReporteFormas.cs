using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Classes
{
    public class ReporteFormas
    {
        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Portugues = 3;

        #endregion

        public static string ObtenerLinea(int cantidad, string forma, decimal area, decimal perimetro)
        {
            return $"{cantidad} {forma} | {Resources.Etiquetas.Area} {area:#.##} | {Resources.Etiquetas.Perimetro} {perimetro:#.##} <br/>";
        }

        public static string Imprimir(List<IFormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            switch (idioma)
            {
                case Ingles:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                case Portugues:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    break;
            }

            if (!formas.Any())
            {
                sb.Append("<h1>" + Resources.Etiquetas.ListaVacia + "</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append("<h1>" + Resources.Etiquetas.TituloReporte + "</h1>");

                int tipo;
                int[] numero_formas = new int[6];
                decimal[] area = new decimal[6];
                decimal[] perimetro = new decimal[6];
                string[] forma = new string[6];

                for (int i = 0; i < formas.Count; i++)
                {
                    tipo = formas[i].RecuperarTipo();

                    numero_formas[tipo] += 1;
                    area[tipo] += formas[i].CalcularArea();
                    perimetro[tipo] += formas[i].CalcularPerimetro();

                    if (numero_formas[tipo] < 3)
                    {
                        forma[tipo] = formas[i].TraducirForma(numero_formas[tipo]);
                    }
                }

                var numeroTotal = 0;
                var areaTotal = 0m;
                var perimetroTotal = 0m;

                for (int i = 1; i < numero_formas.Length; i++)
                {
                    if (numero_formas[i] > 0)
                    {
                        sb.Append(ObtenerLinea(numero_formas[i], forma[i], area[i], perimetro[i]));

                        numeroTotal += numero_formas[i];
                        areaTotal += area[i];
                        perimetroTotal += perimetro[i];
                    }
                }

                // FOOTER
                sb.Append(Resources.Etiquetas.Total + "<br/>");
                sb.Append(numeroTotal + " " + Resources.Etiquetas.Formas + " ");
                sb.Append(Resources.Etiquetas.Perimetro + " " + perimetroTotal.ToString("#.##") + " ");
                sb.Append(Resources.Etiquetas.Area + " " + areaTotal.ToString("#.##"));
            }

            return sb.ToString();
        }
    }
}
