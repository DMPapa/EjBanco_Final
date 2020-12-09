using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBancoFinal_Entidades
{
    public class Operador
    {
        private List<Prestamo> _prestamos;
        private double _comision;
        private double _porcentajeComision;

        public List<Prestamo> prestamos
        {
            get { return this._prestamos; }
            set { this._prestamos = value; }
        }
        public double comision
        {
            get { return this._comision; }
            set { this._comision = value; }
        }
        public double porcentajecomision
        {
            get { return this._porcentajeComision; }
            set { this._porcentajeComision = value; }
        }
        public Operador(List<Prestamo> prestamos)
        {
            _prestamos = prestamos;
            _porcentajeComision = 0.15;
            _comision = CalcularComision();
        }

        private double CalcularComision()
        {
            double cuenta = 0;
            foreach (Prestamo prestamo in this._prestamos)
            {
                cuenta += (prestamo.monto * this._porcentajeComision);
            }
            return cuenta;
        }
    }
}
