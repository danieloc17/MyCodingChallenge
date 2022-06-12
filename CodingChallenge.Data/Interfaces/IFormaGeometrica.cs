namespace CodingChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        int RecuperarTipo();

        string TraducirForma(int cantidad);

        decimal CalcularArea();

        decimal CalcularPerimetro();
    }
}
