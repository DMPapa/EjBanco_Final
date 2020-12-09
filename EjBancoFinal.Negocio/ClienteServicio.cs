using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjBancoFinal_Datos;
using EjBancoFinal_Entidades;

namespace EjBancoFinal_Negocio
{
    public class ClienteServicio
    {
        private ClienteMapper mapper;

        public ClienteServicio()
        {
            mapper = new ClienteMapper();
        }

        public List<Cliente> TraerClientes()
        {
            return mapper.TraerClientes();
        }

        public int AgregarCliente(Cliente cliente)
        {

            if (mapper.TraerClientes().SingleOrDefault(x => x.dni == cliente.dni) != null)
                throw new Exception("El cliente ya existe");
            else
            {
                TransactionResult transaccion = mapper.Insert(cliente);

            if (transaccion.IsOk == true)
                return transaccion.Id;
            else throw new Exception("Ha habido un error al crear el cliente" + transaccion.Error);
            }

        }
        public int ProximoID()
        {
            return ((mapper.TraerClientes()).Max(x => x.id)) + 1;
        }
    }
}
