using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal BaseMayor;
        private readonly decimal BaseMenor;
        private readonly decimal LadoIzquierdo;
        private readonly decimal LadoDerecho;
        private readonly decimal Altura;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal ladoIzquierdo, decimal ladoDerecho, decimal altura)
        {
            Tipo = 4;
            BaseMayor = baseMayor;
            BaseMenor = baseMenor;
            LadoIzquierdo = ladoIzquierdo;
            LadoDerecho = ladoDerecho;
            Altura = altura;
        }

        public int  RecuperarTipo()
        {
            return Tipo;
        }

        public string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Resources.Etiquetas.Trapecio : Resources.Etiquetas.Trapecios;
        }

        public decimal CalcularArea()
        {
            return ((BaseMayor + BaseMenor) / 2) * Altura;
        }

        public decimal CalcularPerimetro()
        {
            return BaseMayor + BaseMenor + LadoIzquierdo + LadoDerecho;
        }
    }
}
