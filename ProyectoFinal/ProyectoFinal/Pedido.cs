using System;
using System.Collections.Generic;

namespace ProyectoFinal
{
    public class Pedido
    {
        public Pedido()
        {
            Expresiones = new List<string>();
        }

        public string Origen { get; set; }

        public string Destino { get; set; }

        public string Medio { get; set; }

        public string Empresa { get; set; }

        public double TiempoTraslado { get; set; }

        public double Distancia { get; set; }

        public DateTime FechaHoraPedido { get; set; }

        public DateTime FechaEntrega { get; set; }

        public double CostoEnvio { get; set; }

        public string RangoTiempo { get; set; }

        public List<string> Expresiones { get; set; }
    }
}
