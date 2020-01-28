using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal.LectorArchivo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.LectorArchivo.UTest
{
    [TestClass()]
    public class LectorCSV_UTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LeerDatos_ArchivoNoExistente_LanzaExcepcion()
        {
            // Arrange
            ILector DOC = new LectorCSV();
            string ruta = "C:\\pruebas.txt";

            // ACT
            var ACT = DOC.LeerDatos(ruta);

            // Assert
            Assert.ThrowsException<FileNotFoundException>(() => ACT);
        }

        [TestMethod]
        public void LeerDatos_ArchivoExistenteConDatos_DeveulveListaConDatos()
        {
            // Arrange
            ILector DOC = new LectorCSV();
            string ruta = "C:\\Pedidos.xlsx";

            // ACT
            var ACT = DOC.LeerDatos(ruta);

            // Assert
            Assert.IsTrue(ACT.Any());
        }

        [TestMethod]
        public void LeerArchivo_ArchivoExistenteConSinDatos_DeveulveListaVacia()
        {
            // Arrange
            ILector DOC = new LectorCSV();
            string ruta = "C:\\PedidosVacio.xlsx";

            // ACT
            var ACT = DOC.LeerDatos(ruta);

            // Assert
            Assert.IsFalse(ACT.Any());
        }

        [TestMethod]
        public void LeerArchivo_ArchivoExistenteConEspaciosEnBlanco_DeveulveListaVacia()
        {
            // Arrange
            ILector DOC = new LectorCSV();
            string ruta = "C:\\PedidosEspaciosEnBlanco.xlsx";

            // ACT
            var ACT = DOC.LeerDatos(ruta);

            // Assert
            Assert.IsFalse(ACT.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LeerArchivo_EnviarNombreArchivoVacio_LanzaExcepcion()
        {
            // Arrange
            ILector DOC = new LectorCSV();
            string ruta = "";

            // ACT
            var ACT = DOC.LeerDatos(ruta);

            // Assert
            Assert.ThrowsException<FileNotFoundException>(() => ACT);
        }
    }
}