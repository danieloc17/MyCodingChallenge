namespace CodingChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        string TraducirForma(int cantidad);

        decimal CalcularArea();

        decimal CalcularPerimetro();
    }
}
