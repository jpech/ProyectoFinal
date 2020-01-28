using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal.Fabrica;

namespace ProyectoFinalUTest.Fabrica
{
    [TestClass]
    public class FabricaAvionUTest
    {
        [TestMethod]
        public void CrearMedioTransporte_EnviarTipoDeTransporteValido_CreaInstanciaTipoAvion()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaAvion();
            var expected = typeof(Avion);

            // Act
            IMedioTransporte act = DOC.CrearMedioTransporte();

            // Assert
            Assert.IsInstanceOfType(act, expected);
        }

        [TestMethod]
        public void CrearMedioTransporte_ValidarNombreMedioTransporteAvion_NombreMedioTransporteDebeSerAvion()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaAvion();
            var expected = "Avión";

            // Act
            IMedioTransporte SUT = DOC.CrearMedioTransporte();
            var act = SUT.Nombre;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearMedioTransporte_ValidarCostoXKilometroAvion_CostoPorKilometroIgualADiez()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaAvion();
            var expected = 10;

            // Act
            IMedioTransporte SUT = DOC.CrearMedioTransporte();
            var act = SUT.CostroPorKilometro;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearMedioTransporte_ValidarVelocidadEntregaAvion_VelocidadEntregaIgualA600()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaAvion();
            var expected = 600;

            // Act
            IMedioTransporte SUT = DOC.CrearMedioTransporte();
            var act = SUT.VelocidadEntrega;

            // Assert
            Assert.AreEqual(expected, act);
        }
    }
}