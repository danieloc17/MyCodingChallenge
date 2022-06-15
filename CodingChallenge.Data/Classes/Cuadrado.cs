using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal Lado;

        public Cuadrado(decimal lado)
        {
            Lado = lado;
        }

        public string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Resources.Etiquetas.Cuadrado : Resources.Etiquetas.Cuadrados;
        }

        public decimal CalcularArea()
        {
            return Lado * Lado;
        }

        public decimal CalcularPerimetro()
        {
            return Lado * 4;
        }
    }
}
