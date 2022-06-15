using System;
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

                int numero_formas = 0;
                decimal area = 0m;
                decimal perimetro = 0m;
                string forma = "";

                var numeroTotal = 0;
                var areaTotal = 0m;
                var perimetroTotal = 0m;

                var tipos = formas
                              .GroupBy(p => p.GetType())
                              .Select(g => g.First())
                              .ToList();

                foreach (var tipo in tipos)
                {
                    numero_formas = (from f in formas where f.GetType().Equals(tipo.GetType()) select f).Count();
                    forma = (from f in formas where f.GetType().Equals(tipo.GetType()) select f.TraducirForma(numero_formas)).FirstOrDefault();
                    area = (from f in formas where f.GetType().Equals(tipo.GetType()) select f).Sum(x => x.CalcularArea());
                    perimetro = (from f in formas where f.GetType().Equals(tipo.GetType()) select f).Sum(x => x.CalcularPerimetro());

                    sb.Append(ObtenerLinea(numero_formas, forma, area, perimetro));

                    numeroTotal += numero_formas;
                    areaTotal += area;
                    perimetroTotal += perimetro;
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
