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
    public class EstrategiaEstafetaUTest
    {
        [TestMethod]
        public void CrearEmpresa_EnviarFabricayMedioTransporteValido_CreaEmpresaTipoEstafeta()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaEstafeta();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            var expected = typeof(Estafeta);

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
            IEstrategiaEmpresas DOC = new EstrategiaEstafeta();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT;

            // Assert
            Assert.IsFalse(act.MediosTransporte.Any());
        }

        [TestMethod]
        public void CrearEmpresa_VerificarCreacionEmpresaEstafeta_CreaEmpresaTipoEstafetaConUnMedioDeTransporte()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaDHL();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            fabricas.Object.Add(new FabricaTren());
            var expected = 1;

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.MediosTransporte.Count;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearEmpresa_ValidarMedioTransporteSeaTren_CreaEmpresaTipoEstafetaConUnMedioDeTransporteTipoTren()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaDHL();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            fabricas.Object.Add(new FabricaTren());
            var expected = typeof(Tren);

            // Act 
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.MediosTransporte[0].GetType();

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearEmpresa_ValidarNombreEmpresa_DevuelveNombreEmpresaEstafeta()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaEstafeta();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            var expected = "Estafeta";

            // Act
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.Nombre;

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CrearEmpresa_ValidarMargenUtilidadEstafeta_MargenUtilidadEstafeta20()
        {
            // Arrange
            IEstrategiaEmpresas DOC = new EstrategiaEstafeta();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var medio = new Mock<IMedioTransporte>();
            var expected = 20;

            // Act
            var SUT = DOC.CrearEmpresa(fabricas.Object, medio.Object);
            var act = SUT.MargenUtilidad;

            // Assert
            Assert.AreEqual(expected, act);
        }
    }
}
