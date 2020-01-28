using System;

namespace ProyectoFinal.Cadenas
{
    public class MinutosHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is Pedido)
            {

                if (((((Pedido) request).FechaEntrega - DateTime.Now).TotalMinutes > 0 &&
                     (((Pedido) request).FechaEntrega - DateTime.Now).TotalHours < 1) ||
                    ((DateTime.Now - ((Pedido) request).FechaEntrega).TotalMinutes > 0 &&
                     (DateTime.Now - ((Pedido) request).FechaEntrega).TotalHours < 1))
                {
                    ((Pedido) request).RangoTiempo =
                        $"{Math.Abs((((Pedido) request).FechaEntrega - DateTime.Now).TotalMinutes)} Minutos";
                    return ((Pedido) request);
                }
                else
                {
                    return base.Handle(request);
                }
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
