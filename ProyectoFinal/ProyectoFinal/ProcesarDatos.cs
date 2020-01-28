using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class ProcesarDatos : IProcesarDatos
    {
        public double ProcesarTiempoTraslado(double distancia, double velocidad)
        {
            return distancia / velocidad;
        }
    }
}
