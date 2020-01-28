using ProyectoFinal.Estrategia;
using ProyectoFinal.Fabrica;
using ProyectoFinal.LectorArchivo;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            ILector lector = new LectorCSV();
            IConvertidor convertidor = new ConvertidorObjetos();
            string ruta = Path.GetFullPath("Pedidos.xlsx");
            var datos = lector.LeerDatos(ruta);
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = convertidor.ConvertirDatos(datos);

            Context context = new Context();
            List<IEmpresa> empresas = new List<IEmpresa>();

            //Fedex
            context.AsignarEstrategia(new EstrategiaFedex());
            List<IFabricaMedioTransporte> fabricas = new List<IFabricaMedioTransporte>();
            fabricas.Add(new FabricaBarco());
            var fedex = context.EjecutarEstrategia(fabricas, new Barco());
            empresas.Add(fedex);

            //DHL
            context.AsignarEstrategia(new EstrategiaDHL());
            List<IFabricaMedioTransporte> fabricas2 = new List<IFabricaMedioTransporte>();
            fabricas2.Add(new FabricaAvion());
            fabricas2.Add(new FabricaBarco());
            var dhl = context.EjecutarEstrategia(fabricas2, new Avion());
            empresas.Add(dhl);

            //Estafeta
            context.AsignarEstrategia(new EstrategiaEstafeta());
            List<IFabricaMedioTransporte> fabricas3 = new List<IFabricaMedioTransporte>();
            fabricas3.Add(new FabricaTren());
            var estafeta = context.EjecutarEstrategia(fabricas3, new Tren());
            empresas.Add(estafeta);

            IProcesarDatos procesarDatos = new ProcesarDatos();
            IArmarMensajes armarMensajes = new ArmarMensajes();
            IPresentador presentador = new Presentador();
            ValidadorService validador = new ValidadorService(procesarDatos, armarMensajes, presentador);
            Dictionary<string, string> mensajes = new Dictionary<string, string>();

            validador.Validar(empresas, pedidos);

            Console.ReadLine();
        }
    }
}
