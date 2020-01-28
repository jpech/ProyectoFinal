using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal.Fabrica;
using Moq;
using ProyectoFinal.Estrategia;

namespace ProyectoFinalUTest.Estrategia
{
    /// <summary>
    /// Descripción resumida de EstrategiaDHLUTest
    /// </summary>
    [TestClass]
    public class EstrategiaDHLUTest
    {
        [TestMethod]
        public void CrearEmpresa_EnviarFabricayMedioTransporteValido_CreaEmpresaTipoDHL()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaDHL();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            var expected = typeof(DHL);

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT;

            // Assert
            Assert.IsInstanceOfType(act, expected);
        }

        [TestMethod]
        public void CrearEmpresa_EnviarFabricayMedioTransporteValido_CreaEmpresaTipoDHLSinMediosdeTransporte()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaDHL();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT;

            // Assert
            Assert.IsFalse(act.MediosTransporte.Any());
        }

        [TestMethod]
        public void CrearEmpresa_EnviarFabricayMedioTransporteValido_CreaEmpresaTipoDHLConDosMedioDeTransporte()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaDHL();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            fabricas.Object.Add(new FabricaAvion());
            fabricas.Object.Add(new FabricaBarco());
            var expected = 2;

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.MediosTransporte.Count;
            
            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearEmpresa_ValidarMedioTransporteAvion_CreaEmpresaTipoDHLConUnMedioDeTransporteTipoAvion()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaDHL();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            fabricas.Object.Add(new FabricaAvion());
            var expected = typeof(Avion);

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.MediosTransporte[0].GetType();

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearEmpresa_ValidarMedioTransporteBarco_CreaEmpresaTipoDHLConUnMedioDeTransporteTipoBarco()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaDHL();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            fabricas.Object.Add(new FabricaBarco());
            var expected = typeof(Barco);

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.MediosTransporte[0].GetType();

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearEmpresa_ValidarNombreEmpresaDHL_NombreEmpresaDHL()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaDHL();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            var expected = "DHL";

            // Act
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.Nombre;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearEmpresa_ValidarMargenUtilidadDHL_MargenUtilidadDHL40()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaDHL();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            var expected = 40;

            // Act
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.MargenUtilidad;

            // Assert
            Assert.AreEqual(expected, act);
        }
    }
}
