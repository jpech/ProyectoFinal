using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.Fabrica;

namespace ProyectoFinal.Estrategia
{
    public class EstrategiaEstafeta : IEstrategiaEmpresas
    {
        public IEmpresa CrearEmpresa(List<IFabricaMedioTransporte> fabricas, IMedioTransporte medio)
        {
            IEmpresa empresa = new Estafeta();

            foreach (var item in fabricas)
            {
                medio = item.CrearMedioTransporte();
                empresa.MediosTransporte.Add(medio);
            }

            return empresa;
        }
    }
}
