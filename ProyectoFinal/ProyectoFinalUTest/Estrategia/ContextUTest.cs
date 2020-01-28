using System;
using System.Collections.Generic;
using System.Linq;
using Comun.MSTest.Extensiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoFinal.Estrategia;
using ProyectoFinal.Fabrica;

namespace ProyectoFinalUTest.Estrategia
{
    [TestClass]
    public class ContextUTest
    {
        [TestMethod]
        public void AsignarEstrategia_EnviarIEstrategiaEmpresasNulo_ArgumentNullException()
        {
            // Act
            var DOC = new Context();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => DOC.AsignarEstrategia(null));
        }

        [TestMethod]
        public void AsignarEstrategia_EnviarIEstrategiaEmpresasValido_AsignaEstrategiaDeManeraCorrecta()
        {
            //Arrange
            var DOC = new Context();
            var empresaStrategy = new Mock<IEstrategiaEmpresas>().Object;

            // Act
            Action act = () => DOC.AsignarEstrategia(empresaStrategy);

            // Assert
            Assert.IsTrue(act.ValidateException<Exception>("Mi error", false));
        }

        [TestMethod]
        public void EjecutarEstrategia_EnviarDependenciaFabricaNula_LanzaExcepcion()
        {
            // Arrange
            var DOC = new Context();
            var iMedioTransporte = new Mock<IMedioTransporte>().Object;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => DOC.EjecutarEstrategia(null, iMedioTransporte));
        }

        [TestMethod]
        public void EjecutarEstrategia_EnviarDependenciaMedioTransporteNula_LanzaExcepcion()
        {
            // Arrange
            var DOC = new Context();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>().Object.ToList();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => DOC.EjecutarEstrategia(fabricas, null));
        }

        [TestMethod]
        public void EjecutarEstrategia_EnviarDependenciasValidas_CreaEmpresaSgunTipoEnviado()
        {
            // Arrange
            var DOC = new Context();
            var fabricas = new Mock<List<IFabricaMedioTransporte>>();
            var iMedioTransporte = new Mock<IMedioTransporte>();
            var iEstrategia = new EstrategiaEstafeta();
            var expected = typeof(Estafeta);

            // Act
            DOC.AsignarEstrategia(iEstrategia);
            var act = DOC.EjecutarEstrategia(fabricas.Object.ToList(), iMedioTransporte.Object);

            // Assert
            Assert.IsInstanceOfType(act, expected);
        }
    }
}
