using ProyectoFinal.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Estrategia
{
    public interface IEstrategiaEmpresas
    {
        IEmpresa CrearEmpresa(List<IFabricaMedioTransporte> fabricas, IMedioTransporte medio);
    }
}
