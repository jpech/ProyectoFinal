using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal;
using ProyectoFinal.LectorArchivo;

namespace ProyectoFinalTests.LectorArchivo
{
    [TestClass]
    public class ConvertidorObjetosUTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "No se encontraron datos para convertir.")]
        public void ConvertirDatos_ListaAConvertirVacia_EnviaExcepcion()
        {
            // Arrange
            IConvertidor DOC = new ConvertidorObjetos();

            // ACT
            List<string> datos = new List<string>();
            List<Pedido> ACT = DOC.ConvertirDatos(datos);

            // Assert
            Assert.ThrowsException<Exception>(() => ACT);
        }

        [TestMethod]
        public void ConvertirDatos_ListaAConvertirConDatos_DevuelveListaNoVacia()
        {
            // Arrange
            IConvertidor DOC = new ConvertidorObjetos();
            var datos = CrearDatos();

            // ACT
            List<Pedido> ACT = DOC.ConvertirDatos(datos);

            // Assert
            Assert.IsTrue(ACT.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ConvertirDatos_ListaAConvertirConFormatoNoValido_EnviaExcepcion()
        {
            // Arrange
            IConvertidor DOC = new ConvertidorObjetos();
            var fixture = new Fixture { RepeatCount = 3 };
            var datos = fixture.Repeat(fixture.Create<string>).ToList();

            // ACT
            List<Pedido> ACT = DOC.ConvertirDatos(datos);

            // Assert
            Assert.ThrowsException<Exception>(() => ACT);
        }


        private List<string> CrearDatos()
        {
            List<string> datos = new List<string>();
            datos.Add("China,Cancún,446400,DHL,Avión,23-01-2020 08:00:00");
            datos.Add("Mérida,Cozumel,400,DHL,Avión,23-01-2020 13:50:00");
            datos.Add("Cozumel,Playa del Carmen,1104,DHL,Barco,21-01-2020");
            datos.Add("Cozumel,Playa del Carmen,1104,DHL,Tren,21-01-2020");
            datos.Add("Cozumel,Playa del Carmen,1104,Paquetería Patito,Tren,21-01-2020");
            return datos;
        }
    }
}
