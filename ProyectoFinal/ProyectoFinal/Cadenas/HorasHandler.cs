using System;

namespace ProyectoFinal.Cadenas
{
    public class HorasHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (((((Pedido)request).FechaEntrega - DateTime.Now).TotalHours > 0 && (((Pedido)request).FechaEntrega - DateTime.Now).TotalDays < 1) || ((DateTime.Now - ((Pedido)request).FechaEntrega).TotalHours > 0 && (DateTime.Now - ((Pedido)request).FechaEntrega).TotalHours < 24))
            {
                ((Pedido)request).RangoTiempo = $"{Math.Abs((((Pedido)request).FechaEntrega - DateTime.Now).TotalHours)} Horas";
                return ((Pedido)request);
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
