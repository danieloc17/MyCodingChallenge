using System;
using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal Lado;

        public TrianguloEquilatero(decimal lado)
        {
            Lado = lado;
        }

        public string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Resources.Etiquetas.Triangulo : Resources.Etiquetas.Triangulos;
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
        }

        public decimal CalcularPerimetro()
        {
            return Lado * 3;
        }
    }
}
