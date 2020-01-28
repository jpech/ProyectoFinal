using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Fabrica
{
    public interface IFabricaMedioTransporte
    {
        IMedioTransporte CrearMedioTransporte();
    }
}
