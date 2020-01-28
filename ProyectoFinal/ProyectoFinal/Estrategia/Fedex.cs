using System.Collections.Generic;
using ProyectoFinal.Fabrica;

namespace ProyectoFinal.Estrategia
{
    public class Fedex : IEmpresa
    {
        public string Nombre { get => "Fedex"; }
        public List<IMedioTransporte> MediosTransporte { get; set; } = new List<IMedioTransporte>();
        public int MargenUtilidad { get => 50; }
    }
}
