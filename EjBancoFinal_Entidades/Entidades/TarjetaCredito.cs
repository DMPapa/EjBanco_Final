using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBancoFinal_Entidades
{
    public class TarjetaCredito
    {
        private int _tipo;
        private int _periodoVencimiento;
        private double _limiteCompra;
        private string _nroPlastico;
        private int _idCliente;

        public int tipo
        {
            get { return this._tipo; }
            set { this._tipo = value; }
        }
        public int periodoVencimiento
        {
            get { return this._periodoVencimiento; }
            set { this._periodoVencimiento = value; }
        }
        public double limiteCompra
        {
            get { return this._limiteCompra; }
            set { this._limiteCompra = value; }
        }
        public string nroPlastico
        {
            get { return this._nroPlastico; }
            set { this._nroPlastico = value; }
        }
        public int idCliente
        {
            get { return this._idCliente; }
            set { this._idCliente = value; }
        }

        public TarjetaCredito(int Tipo, int Periodo, double Limite, string Nro, int Idcliente)
        {
            _tipo = Tipo;
            _periodoVencimiento = Periodo;
            _limiteCompra = Limite;
            _nroPlastico = Nro;
            _idCliente = Idcliente;
        }

        public override string ToString()
        {
            return string.Format("Plastico {0} - tipo {1} - periodo {2} - limite {3}", this._nroPlastico, this._tipo, this._periodoVencimiento, this._limiteCompra);
        }
    }
}
