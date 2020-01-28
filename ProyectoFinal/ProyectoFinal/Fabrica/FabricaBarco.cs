using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Fabrica
{
    public class FabricaBarco : IFabricaMedioTransporte
    {
        public IMedioTransporte CrearMedioTransporte()
        {
            return new Barco();
        }
    }
}
