using ProyectoFinal.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Estrategia
{
    public interface IEmpresa
    {
        string Nombre { get; }

        List<IMedioTransporte> MediosTransporte { get; set; }

        int MargenUtilidad { get; }
    }
}
