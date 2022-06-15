using System;
using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal Radio;

        public Circulo(decimal radio)
        {
            Radio = radio;
        }

        public string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Resources.Etiquetas.Circulo : Resources.Etiquetas.Circulos;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (Radio / 2) * (Radio / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * Radio;
        }
    }
}
