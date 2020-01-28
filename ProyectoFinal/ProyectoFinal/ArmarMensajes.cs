using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class ArmarMensajes : IArmarMensajes
    {
        public string ArmarMensajeMedioTransorteIncorrecto(Pedido pedido)
        {
            return $"{pedido.Empresa} no ofrece el servicio de transporte {pedido.Medio}, te recomendamos cotizar en otra empresa";
        }

        public string ArmarMensajePaqueteriaNoExistente(Pedido pedido)
        {
            return $"Lapaquetería: {pedido.Empresa} no se encuentra registrada en nuestra red de distribución";
        }

        public string ArmarMensajeValido(Pedido pedido)
        {
            var msj = string.Empty;
            if (pedido.FechaEntrega < DateTime.Now)
                msj = $"Tu paquete salió de { pedido.Origen} y llegó a {pedido.Destino} hace {pedido.RangoTiempo} y tuvo un costo de {pedido.CostoEnvio}. (Cualquier reclamación con {pedido.Empresa})";

            if (pedido.FechaEntrega > DateTime.Now)
                msj = $"Tu paquete ha salido de { pedido.Origen} y llegará a {pedido.Destino} dentro de {pedido.RangoTiempo} y tendrá un costo de {pedido.CostoEnvio}. (Cualquier reclamación con {pedido.Empresa})";
            return msj;
        }
    }
}
