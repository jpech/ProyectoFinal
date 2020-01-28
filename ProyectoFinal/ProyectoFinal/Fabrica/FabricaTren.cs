namespace ProyectoFinal.Fabrica
{
    public class FabricaTren : IFabricaMedioTransporte
    {
        public IMedioTransporte CrearMedioTransporte()
        {
            return new Tren();
        }
    }
}
