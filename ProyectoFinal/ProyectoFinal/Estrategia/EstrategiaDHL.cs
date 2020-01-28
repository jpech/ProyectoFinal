using System;
using ProyectoFinal.Fabrica;
using System.Collections.Generic;

namespace ProyectoFinal.Estrategia
{
    public class EstrategiaDHL : IEstrategiaEmpresas
    {
        public IEmpresa CrearEmpresa(List<IFabricaMedioTransporte> fabricas, IMedioTransporte medio)
        {
            IEmpresa empresa = new DHL();

            foreach (var item in fabricas)
            {
                medio = item.CrearMedioTransporte();
                empresa.MediosTransporte.Add(medio);
            }

            return empresa;
        }
    }
}
