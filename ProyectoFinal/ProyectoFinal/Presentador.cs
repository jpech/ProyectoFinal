using System;

namespace ProyectoFinal
{
    public class Presentador : IPresentador
    {
        public void ImprimirDatos(string mensaje, string color)
        {
            if(color == "Green")
                Console.ForegroundColor = ConsoleColor.Green;
            if(color == "Red")
                Console.ForegroundColor = ConsoleColor.Red;
            if (color == "Yellow")
                Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(mensaje + "\n");
        }
    }
}
