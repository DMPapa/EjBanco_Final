using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjBancoFinal_Entidades;
using Newtonsoft.Json;


namespace EjBancoFinal_Datos
{
    public class PrestamoTipoMapper
    {
        private List<PrestamoTipo> MapList (string json)
        {
            return JsonConvert.DeserializeObject<List<PrestamoTipo>>(json);
        }

        public List<PrestamoTipo> TraerTipos()
        {
            string json = WebHelper.Get("/api/v1/prestamotipo/");
            List<PrestamoTipo> resultado = MapList(json);
            return resultado;
        }
    }
}
