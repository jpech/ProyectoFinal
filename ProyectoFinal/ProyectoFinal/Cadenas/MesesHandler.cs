using System;

namespace ProyectoFinal.Cadenas
{
    public class MesesHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if(((((Pedido)request).FechaEntrega - DateTime.Now).TotalDays > 30) || ((DateTime.Now - ((Pedido)request).FechaEntrega).TotalDays > 30 ))
            {
                var tiempo = (Math.Abs((((Pedido)request).FechaEntrega - DateTime.Now).TotalDays) / 30);
                ((Pedido)request).RangoTiempo = $"{tiempo} Meses";
                return ((Pedido)request);
            }
            else
                return base.Handle(request);
        }
    }
}
