using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjBancoFinal_Datos;
using EjBancoFinal_Entidades;

namespace EjBancoFinal_Negocio
{
    public class PrestamoServicio
    {
        private PrestamoMapper mapper;
        private PrestamoTipoMapper mappertipo;

        public PrestamoServicio()
        {
            mapper = new PrestamoMapper();
            mappertipo = new PrestamoTipoMapper();
        }

        public List<Prestamo> TraerPrestamos()
        {
            return mapper.TraerPrestamos();
        }

        public List<Prestamo> TraerPrestamosXCliente(int idcliente)
        {
            return mapper.TraerPrestamosXCliente(idcliente);
        }

        public List<PrestamoTipo> TraerTipos()
        {
            return mappertipo.TraerTipos();
        }
        public Operador GenerarOperador()
        {
            Operador operador = new Operador(mapper.TraerPrestamos());

            return operador;
        }

        public int ProximoID()
        {
            if(mapper.TraerPrestamos().Count == 0)
                return 1;
            else
            return ((mapper.TraerPrestamos()).Max(x => x.id) + 1);
        }

        public int AgregarPrestamo (Prestamo p)
        {
            if (p.plazo > 60)
                throw new Exception("El plazo no puede ser mayor a 5 años");
            else if (p.monto > 1000000)
                throw new Exception("El monto no puede ser mayor a $1.000.000");
            else
            {
                TransactionResult resultado = mapper.AgregarPrestamo(p);
                if (resultado.IsOk == true)
                    return resultado.Id;
                else
                    throw new Exception("Ha habido un error al crear el préstamo" + resultado.Error);
            }
        }
                
    }
}
