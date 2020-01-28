using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal.Fabrica;

namespace ProyectoFinalUTest.Fabrica
{
    [TestClass]
    public class FabricaBarcoUTest
    {
        [TestMethod]
        public void CrearMedioTransporte_EnviarTipoDeTransporteValido_CreaInstanciaTipoBarco()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaBarco();

            // Act
            IMedioTransporte act = DOC.CrearMedioTransporte();

            // Assert
            Assert.IsInstanceOfType(act, typeof(Barco));
        }

        [TestMethod]
        public void CrearMedioTransporte_ValidarNombreMedioTransporte_NombreMedioTransporteDebeSerBarco()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaBarco();
            var expected = "Barco";

            // Act
            IMedioTransporte SUT = DOC.CrearMedioTransporte();
            var act = SUT.Nombre;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearMedioTransporte_ValidarCostoXKilometroBarco_CostoPorKilometroIgualAUno()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaBarco();
            var expected = 1;

            // Act
            IMedioTransporte SUT = DOC.CrearMedioTransporte();
            var act = SUT.CostroPorKilometro;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearMedioTransporte_ValidarVelocidadEntregaBarco_VelocidadEntregaIgualA46()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaBarco();
            var expected = 46;

            // Act
            IMedioTransporte SUT = DOC.CrearMedioTransporte();
            var act = SUT.VelocidadEntrega;

            // Assert
            Assert.AreEqual(expected, act);
        }
    }
}
