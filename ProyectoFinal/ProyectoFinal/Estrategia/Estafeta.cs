using System.Collections.Generic;
using ProyectoFinal.Fabrica;

namespace ProyectoFinal.Estrategia
{
    public class Estafeta : IEmpresa
    {
        public string Nombre { get => "Estafeta"; }

        public List<IMedioTransporte> MediosTransporte { get; set; } = new List<IMedioTransporte>();

        public int MargenUtilidad { get => 20; }
    }
}
