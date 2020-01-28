using ProyectoFinal.Cadenas;
using ProyectoFinal.Estrategia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal
{
    public class ValidadorService
    {
        private IProcesarDatos _procesarDatos { get; set; }
        private IArmarMensajes _armarMensajes { get; set; }
        private IPresentador _presentador { get; set; }

        public ValidadorService(IProcesarDatos procesarDatos, IArmarMensajes armarMensajes, IPresentador presentador)
        {
            _procesarDatos = procesarDatos;
            _armarMensajes = armarMensajes;
            _presentador = presentador;
        }

        public void Validar(List<IEmpresa> empresas, List<Pedido> pedidos)
        {
            var countQuery = new Dictionary<string, string>();
            var mensaje = string.Empty;

            foreach (var pedido in pedidos)
            {
                var lEmpresa = empresas.Where(s => s.Nombre == pedido.Empresa).Any();
                var lMedio = empresas.Where(w => w.Nombre == pedido.Empresa).SelectMany(s1 => s1.MediosTransporte.Where(w1 => w1.Nombre == pedido.Medio)).Any();

                if (!lEmpresa)
                {
                    mensaje = _armarMensajes.ArmarMensajePaqueteriaNoExistente(pedido);
                    _presentador.ImprimirDatos(mensaje, "Red");
                }

                if (lEmpresa && !lMedio)
                {
                    mensaje = _armarMensajes.ArmarMensajeMedioTransorteIncorrecto(pedido);
                    _presentador.ImprimirDatos(mensaje, "Red");
                }

                if (lEmpresa && lMedio)
                {
                    var empresa = empresas.Where(s => s.Nombre == pedido.Empresa).FirstOrDefault();
                    var tiempoTraslado = _procesarDatos.ProcesarTiempoTraslado(pedido.Distancia, empresa.MediosTransporte.Where(w => w.Nombre == pedido.Medio).Select(s => s.VelocidadEntrega).FirstOrDefault());
                    var costoXKm = empresa.MediosTransporte.Where(w => w.Nombre == pedido.Medio).Select(s => s.CostroPorKilometro).FirstOrDefault();
                    var margenUtilidad = empresa.MargenUtilidad;
                    var fechaEntrega = pedido.FechaHoraPedido.AddHours(tiempoTraslado);
                    var costoEnvio = (costoXKm * pedido.Distancia) * (1 + margenUtilidad / 100);

                    pedido.TiempoTraslado = tiempoTraslado;
                    pedido.FechaEntrega = fechaEntrega;
                    pedido.CostoEnvio = costoEnvio;

                    var minutos = new MinutosHandler();
                    var horas = new HorasHandler();
                    var dias = new DiasHandler();
                    var meses = new MesesHandler();
                    minutos.SetNext(horas).SetNext(dias).SetNext(meses);
                    Cliente.ClientCodeRangoTiempo(minutos, pedido);

                    if (pedido.FechaEntrega < DateTime.Now)
                    {
                        mensaje = _armarMensajes.ArmarMensajeValido(pedido);
                        _presentador.ImprimirDatos(mensaje, "Green");
                    }
                    else
                    {
                        mensaje = _armarMensajes.ArmarMensajeValido(pedido);
                        _presentador.ImprimirDatos(mensaje, "Yellow");
                    }
                }
            }
        }
    }
}
