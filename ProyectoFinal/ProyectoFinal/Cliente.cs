using ProyectoFinal.Cadenas;
using ProyectoFinal.Fabrica;
using System;

namespace ProyectoFinal
{
    public class Cliente
    {
        public IMedioTransporte ClientCodeMedioTransporte(Pedido pedido)
        {
            IFabricaMedioTransporte fabrica;
            IMedioTransporte medio = null;

            switch (pedido.Medio)
            {
                case "Barco":
                    fabrica = new FabricaBarco();
                    break;
                case "Tren":
                    fabrica = new FabricaTren();
                    break;
                case "Avion":
                    fabrica = new FabricaAvion();
                    break;
                default:
                    fabrica = null;
                    break;
            }

            if (fabrica != null)
            {
                medio = fabrica.CrearMedioTransporte();
            }

            return medio;
        }

        public static void ClientCodeRangoTiempo(AbstractHandler handler, Pedido pedido)
        {
            if (pedido == null)
                throw new Exception("El pedido no puede ser nulo");

            var result = handler.Handle(pedido);

            if (result != null)
            {
                
            }
            else
            {
                Console.WriteLine($"El pedido {pedido.Origen } no se pudo resolver.");
            }

        }
    }
}
