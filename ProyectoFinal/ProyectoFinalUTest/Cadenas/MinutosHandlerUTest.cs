using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal;
using ProyectoFinal.Cadenas;
using ProyectoFinal.Fabrica;

namespace ProyectoFinalUTest.Cadenas
{
    [TestClass]
    public class MinutosHandlerUTest
    {
        [TestMethod]
        public void Handle_EnviarObjetoDiferenteATipoPedido_DevuelveNulo()
        {
            // Arrange
            var pedido = new Avion();

            // Act
            var SUT = new MinutosHandler();
            var act = SUT.Handle(pedido);

            // Assert
            Assert.IsNull(act);
        }

        [TestMethod]
        public void Handle_EnviarObjetoTipoPedidoVacio_DevuelveNulo()
        {
            // Arrange
            var pedido = new Pedido();

            // Act
            var SUT = new MinutosHandler();
            var act = SUT.Handle(pedido);

            // Assert
            Assert.IsNull(act);
        }

        [TestMethod]
        public void Handle_EnviarObjetoTipoPedidoVacioAsignando_DevuelveNulo()
        {
            // Arrange
            var pedido = new Pedido
            {
                FechaEntrega = new DateTime(2020, 01, 28, 17, 15, 00)
            };

            // Act
            var SUT = new MinutosHandler();
            var act = ((Pedido)SUT.Handle(pedido)).RangoTiempo;
            var expected = $"{Math.Abs((pedido.FechaEntrega - DateTime.Now).TotalMinutes)} Minutos";

            // Assert
            Assert.AreEqual(expected, act);
        }
    }
}
