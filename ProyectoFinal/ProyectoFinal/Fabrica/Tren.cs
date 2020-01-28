using System;

namespace ProyectoFinal.Fabrica
{
    public class Tren : IMedioTransporte
    {
        public string Nombre { get => "Tren"; }

        public double CostroPorKilometro => 5;

        public double VelocidadEntrega => 80;

        public double TiempoTraslado { get; set; } = 0;
    }
}
