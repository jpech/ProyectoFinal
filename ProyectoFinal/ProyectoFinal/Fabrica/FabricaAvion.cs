namespace ProyectoFinal.Fabrica
{
    public class FabricaAvion : IFabricaMedioTransporte
    {
        public IMedioTransporte CrearMedioTransporte()
        {
            return new Avion();
        }
    }
}