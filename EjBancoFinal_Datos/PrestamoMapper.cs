using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjBancoFinal_Entidades;
using Newtonsoft.Json;

namespace EjBancoFinal_Datos
{
    public class PrestamoMapper
    {
        private List<Prestamo> MapList (string json)
        {
            return JsonConvert.DeserializeObject<List<Prestamo>>(json);
        }
        private TransactionResult MapResultado (string json)
        {
            return JsonConvert.DeserializeObject<TransactionResult>(json);
        }

        private NameValueCollection ReverseMap (Prestamo prestamo)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("id", prestamo.id.ToString());
            n.Add("tna", prestamo.tna.ToString());
            n.Add("linea", prestamo.linea);
            n.Add("plazo", prestamo.plazo.ToString());
            n.Add("idCliente", prestamo.idCliente.ToString());
            n.Add("idTipo", prestamo.idTipo.ToString());
            n.Add("monto", prestamo.monto.ToString());
            n.Add("Cuota", prestamo.cuota.ToString());
            n.Add("usuario", ConfigurationManager.AppSettings["Legajo"]);


            return n;
        }

        public List<Prestamo> TraerPrestamos()
        {
            string json = WebHelper.Get("/Api/v1/Prestamo/" + ConfigurationManager.AppSettings["Legajo"]);
            List<Prestamo> listado = MapList(json);
            return listado;
        }

        public List<Prestamo> TraerPrestamosXCliente(int idcliente)
        {
            string json = WebHelper.Get("/Api/v1/Prestamo/" + ConfigurationManager.AppSettings["Legajo"] + "/" + idcliente.ToString());
            List<Prestamo> listado = MapList(json);
            return listado;
        }
        public TransactionResult AgregarPrestamo(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);
            string resultado = WebHelper.Post("api/v1/prestamo/",obj);
            TransactionResult result = MapResultado(resultado);
            return result;
        }

    }
}
