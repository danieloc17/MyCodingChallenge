using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;
using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ReporteFormas.Imprimir(new List<IFormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ReporteFormas.Imprimir(new List<IFormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnPortugues()
        {
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                ReporteFormas.Imprimir(new List<IFormaGeometrica>(), 3));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> {new Cuadrado(5)};

            var resumen = ReporteFormas.Imprimir(cuadrados, ReporteFormas.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Area 25", resumen);
        }
        
        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = ReporteFormas.Imprimir(cuadrados, ReporteFormas.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = ReporteFormas.Imprimir(formas, ReporteFormas.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = ReporteFormas.Imprimir(formas, ReporteFormas.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 13,01 | Perímetro 18,06 <br/>3 Triángulos | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnPortugues()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = ReporteFormas.Imprimir(formas, ReporteFormas.Portugues);

            Assert.AreEqual(
                "<h1>Relatório de formas</h1>2 Quadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 13,01 | Perímetro 18,06 <br/>3 Triângulos | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var rectangulos = new List<IFormaGeometrica> { new Rectangulo(5, 10) };

            var resumen = ReporteFormas.Imprimir(rectangulos, ReporteFormas.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectángulo | Area 50 | Perímetro 30 <br/>TOTAL:<br/>1 formas Perímetro 30 Area 50", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var trapecios = new List<IFormaGeometrica> { new Trapecio(10, 8, 5, 5, 4) };

            var resumen = ReporteFormas.Imprimir(trapecios, ReporteFormas.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>1 Trapezium | Area 36 | Perimeter 28 <br/>TOTAL:<br/>1 shapes Perimeter 28 Area 36", resumen);
        }
    }
}
