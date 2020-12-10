using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjBancoFinal_Datos;
using EjBancoFinal_Entidades;

namespace EjBancoFinal_Negocio
{
    public class TarjetaCreditoServicio
    {
        private TarjetaCreditoMapper mapper;

        public TarjetaCreditoServicio()
        {
            mapper = new TarjetaCreditoMapper();
        }

        public List<TarjetaCredito> TraerTarjetas()
        {
            return mapper.TraerTarjetas();
        }
        public List<TarjetaCredito> TraerTarjetasXCliente(int idcliente)
        {
            return mapper.TraerTarjetasXCliente(idcliente);
        }
        public int AgregarTarjeta(TarjetaCredito tarjeta)
        {
            if (tarjeta.limiteCompra < 500000)
                throw new Exception("El límite no puede ser mayor a $500.000");
            else if (tarjeta.tipo == 3 && tarjeta.nroPlastico.Length != 15)
                throw new Exception("El nro de plastico de una tarjeta Amex debe contener 15 dígitos");
            else if (tarjeta.tipo != 3 && tarjeta.nroPlastico.Length != 16)
                throw new Exception("El nro de plastico de una tarjeta Master o Visa debe contener 16 dígitos");
            else
            {
                TransactionResult resultado = mapper.TarjetaPost(tarjeta);

                if (resultado.IsOk)
                    return resultado.Id;
                else
                    throw new Exception("Ha habito un error al crear la tarjeta" + resultado.Error);

            }
        }

    }
}
