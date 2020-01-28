using System.Collections.Generic;
using ProyectoFinal.Fabrica;

namespace ProyectoFinal.Estrategia
{
    public class DHL : IEmpresa
    {
        public string Nombre { get => "DHL"; }

        public List<IMedioTransporte> MediosTransporte { get; set; } = new List<IMedioTransporte>();

        public int MargenUtilidad { get => 40; }
    }
}
