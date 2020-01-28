using System;

namespace ProyectoFinal.Cadenas
{
    public class DiasHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if(((((Pedido)request).FechaEntrega - DateTime.Now).TotalDays > 0 && (((Pedido)request).FechaEntrega - DateTime.Now).TotalDays <= 30) || ((DateTime.Now - ((Pedido)request).FechaEntrega).TotalHours >= 24 && (DateTime.Now - ((Pedido)request).FechaEntrega).TotalDays <= 30))
            {
                ((Pedido)request).RangoTiempo = $"{Math.Abs((((Pedido)request).FechaEntrega - DateTime.Now).TotalDays)} Días";
                return ((Pedido)request);
            }
            else
                return base.Handle(request);
        }
    }
}
