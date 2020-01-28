using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal.Fabrica;

namespace ProyectoFinalUTest.Fabrica
{
    /// <summary>
    /// Descripción resumida de FabricaTrenUTest
    /// </summary>
    [TestClass]
    public class FabricaTrenUTest
    {
        [TestMethod]
        public void CrearMedioTransporte_EnviarTipoDeTransporteValido_CreaInstanciaTipoTren()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaTren();
            var expected = typeof(Tren);

            // Act
            IMedioTransporte act = DOC.CrearMedioTransporte();

            // Assert
            Assert.IsInstanceOfType(act, expected);
        }

        [TestMethod]
        public void CrearMedioTransporte_ValidarNombreMedioTransporteTren_NombreMedioTransporteDebeSerTren()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaTren();
            var expected = "Tren";

            // Act
            IMedioTransporte SUT = DOC.CrearMedioTransporte();
            var act = SUT.Nombre;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearMedioTransporte_ValidarCostoXKilometroTren_CostoPorKilometroIgualACinco()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaTren();
            var expected = 5;

            // Act
            IMedioTransporte SUT = DOC.CrearMedioTransporte();
            var act = SUT.CostroPorKilometro;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearMedioTransporte_ValidarVelocidadEntregaTren_VelocidadEntregaIgualA80()
        {
            // Arrange
            IFabricaMedioTransporte DOC = new FabricaTren();
            var expected = 80;

            // Act
            IMedioTransporte SUT = DOC.CrearMedioTransporte();
            var act = SUT.VelocidadEntrega;

            // Assert
            Assert.AreEqual(expected, act);
        }
    }
}
