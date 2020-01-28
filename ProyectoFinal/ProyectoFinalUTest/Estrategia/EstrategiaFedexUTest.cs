using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoFinal.Estrategia;
using ProyectoFinal.Fabrica;

namespace ProyectoFinalUTest.Estrategia
{
    [TestClass]
    public class EstrategiaFedexUTest
    {
        [TestMethod]
        public void CrearEmpresa_EnviarFabricayMedioTransporteValido_CreaEmpresaTipoFedex()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaFedex();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            var expected = typeof(Fedex);

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT;

            // Assert
            Assert.IsInstanceOfType(act, expected);
        }

        [TestMethod]
        public void CrearEmpresa_EnviarFabricayMedioTransporteValido_CreaEmpresaTipoEstafetaSinMediosdeTransporte()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaFedex();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT;

            // Assert
            Assert.IsFalse(act.MediosTransporte.Any());
        }

        [TestMethod]
        public void CrearEmpresa_VerificarCreacionEmpresaFedex_CreaEmpresaTipoEstafetaConUnMedioDeTransporte()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaFedex();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            fabricas.Object.Add(new FabricaBarco());
            var expected = 1;

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.MediosTransporte.Count;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearEmpresa_ValidarMedioTransporteSeaBarco_CreaEmpresaTipoFedexConUnMedioDeTransporteTipoBarco()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaFedex();
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
        public void CrearEmpresa_ValidarNombreEmpresaFedex_DevuelveNombreEmpresaFedex()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaFedex();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            var expected = "Fedex";

            // Act
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.Nombre;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearEmpresa_ValidarMargenUtilidadFedex_MargenUtilidadFedex50()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaFedex();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            var expected = 50;

            // Act
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.MargenUtilidad;

            // Assert
            Assert.AreEqual(expected, act);
        }
    }
}
