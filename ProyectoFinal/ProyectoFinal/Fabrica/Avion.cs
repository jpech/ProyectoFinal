using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Fabrica
{
    public class Avion : IMedioTransporte
    {
        public string Nombre { get => "Avión"; }

        public double CostroPorKilometro => 10;

        public double VelocidadEntrega => 600;

        public double TiempoTraslado { get; set; } = 0;
    }
}
