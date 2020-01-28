using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.LectorArchivo
{
    public class ConvertidorObjetos : IConvertidor
    {
        public List<Pedido> ConvertirDatos(List<string> datos)
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();
                if (!datos.Any())
                    throw new Exception("No se encontraron datos para convertir.");

                foreach (var dato in datos)
                {
                    Pedido pedido = new Pedido();
                    pedido.Origen = dato.Split(',')[0].ToString();
                    pedido.Destino = dato.Split(',')[1].ToString();
                    pedido.Distancia = Convert.ToInt32(dato.Split(',')[2].ToString());
                    pedido.Empresa = dato.Split(',')[3].ToString();
                    pedido.Medio = dato.Split(',')[4].ToString();
                    pedido.FechaHoraPedido = Convert.ToDateTime(dato.Split(',')[5].ToString());

                    pedidos.Add(pedido);
                }
                return pedidos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
