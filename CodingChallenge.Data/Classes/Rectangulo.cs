using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal Base;
        private readonly decimal Altura;

        public Rectangulo(decimal @base, decimal altura)
        {
            Tipo = 5;
            Base = @base;
            Altura = altura;
        }

        public int RecuperarTipo()
        {
            return Tipo;
        }

        public string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Resources.Etiquetas.Rectangulo : Resources.Etiquetas.Rectangulos;
        }

        public decimal CalcularArea()
        {
            return Base * Altura;
        }

        public decimal CalcularPerimetro()
        {
            return (Base * 2) + (Altura * 2);
        }
    }
}
