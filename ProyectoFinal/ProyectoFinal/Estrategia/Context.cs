using System;
using ProyectoFinal.Fabrica;
using System.Collections.Generic;

namespace ProyectoFinal.Estrategia
{
    public class Context
    {
        private IEstrategiaEmpresas _estrategy;

        public void AsignarEstrategia(IEstrategiaEmpresas estrategy)
        {
            this._estrategy = estrategy ?? throw new ArgumentNullException(nameof(estrategy));
        }

        public IEmpresa EjecutarEstrategia(List<IFabricaMedioTransporte> fabricas, IMedioTransporte medio)
        {
            if (fabricas == null)
                throw new ArgumentNullException(nameof(fabricas));

            if (medio == null)
                throw new ArgumentNullException(nameof(medio));

            return _estrategy.CrearEmpresa(fabricas, medio);
        }

    }
}
