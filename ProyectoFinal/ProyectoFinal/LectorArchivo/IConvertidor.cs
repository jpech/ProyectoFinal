using System.Collections.Generic;

namespace ProyectoFinal.LectorArchivo
{
    public interface IConvertidor
    {
        List<Pedido> ConvertirDatos(List<string> datos);
    }
}
