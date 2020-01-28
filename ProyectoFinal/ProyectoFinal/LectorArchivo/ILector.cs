using System.Collections.Generic;

namespace ProyectoFinal.LectorArchivo
{
    public interface ILector
    {
        List<string> LeerDatos(string ruta);
    }
}
