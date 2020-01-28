using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Fabrica
{
    public class Barco : IMedioTransporte
    {
        public string Nombre => "Barco";

        public double CostroPorKilometro => 1;

        public double VelocidadEntrega => 46;

        public double TiempoTraslado { get; set; } = 0;
    }
}
