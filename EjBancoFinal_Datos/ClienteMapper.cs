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
    public class ClienteMapper
    {
        private List<Cliente> MapList (string json)
        {
            return JsonConvert.DeserializeObject<List<Cliente>>(json);
        }
        private TransactionResult MapResultado (string json)
        {
            return JsonConvert.DeserializeObject<TransactionResult>(json);
        }
        private NameValueCollection ReverseMap (Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("dni", cliente.dni.ToString());
            n.Add("nombre", cliente.nombre);
            n.Add("apellido", cliente.apellido);
            n.Add("direccion", cliente.direccion);
            n.Add("email", cliente.email);
            n.Add("telefono", cliente.telefono);
            n.Add("fechaNacimiento", cliente.fechaNacimiento.ToString());
            n.Add("fechaAlta", cliente.fechaAlta.ToString());
            n.Add("activo", cliente.activo.ToString());
            n.Add("usuario", ConfigurationManager.AppSettings["Legajo"]);
            n.Add("id", cliente.id.ToString());

            return n;
        }

        public TransactionResult Insert (Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);
            string result = WebHelper.Post("/api/v1/cliente/", obj);
            TransactionResult resultado = MapResultado(result);
            return resultado;
        }
        public List<Cliente> TraerClientes()
        {
            string json2 = WebHelper.Get("/api/v1/cliente/" + ConfigurationManager.AppSettings["Legajo"]);
            List<Cliente> listado = MapList(json2);
            return listado;
        }

    }
}
