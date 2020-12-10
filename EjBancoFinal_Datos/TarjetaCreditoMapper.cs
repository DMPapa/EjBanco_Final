using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EjBancoFinal_Entidades;
using System.Collections.Specialized;
using System.Configuration;

namespace EjBancoFinal_Datos
{
    public class TarjetaCreditoMapper
    {
        private List<TarjetaCredito> MapList (string json)
        {
            return JsonConvert.DeserializeObject<List<TarjetaCredito>>(json);
        }

        private TransactionResult MapResultado (string json)
        {
            return JsonConvert.DeserializeObject<TransactionResult>(json);
        }

        private NameValueCollection MapReverse(TarjetaCredito tarjeta)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("tipo", tarjeta.tipo.ToString());
            n.Add("periodoVencimiento", tarjeta.periodoVencimiento.ToString());
            n.Add("limiteCompra", tarjeta.limiteCompra.ToString());
            n.Add("nroPlastico", tarjeta.nroPlastico.ToString());
            n.Add("usuario", ConfigurationManager.AppSettings["Legajo"]);
            n.Add("idCliente", tarjeta.idCliente.ToString());

            return n;
        }

        public List<TarjetaCredito> TraerTarjetas()
            {
                string json2 = WebHelper.Get("/api/v1/tarjetacredito/" + ConfigurationManager.AppSettings["Legajo"]);
                List<TarjetaCredito> listado = MapList(json2);
                return listado;
            }
        public List<TarjetaCredito> TraerTarjetasXCliente(int idcliente)
        {
            string json2 = WebHelper.Get("/api/v1/tarjetacredito/" + ConfigurationManager.AppSettings["Legajo"] + "/" + idcliente.ToString());
            List<TarjetaCredito> listado = MapList(json2);
            return listado;
        }
        public TransactionResult TarjetaPost (TarjetaCredito tarjeta)
        {
            NameValueCollection n = MapReverse(tarjeta);
            string resultado = WebHelper.Post("/api/v1/tarjetacredito/", n);
            TransactionResult result = MapResultado(resultado);
            return result;
        }


    }
}
