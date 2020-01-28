using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public interface IArmarMensajes
    {
        string ArmarMensajeMedioTransorteIncorrecto(Pedido pedido);

        string ArmarMensajePaqueteriaNoExistente(Pedido pedido);

        string ArmarMensajeValido(Pedido pedido);
    }
}
