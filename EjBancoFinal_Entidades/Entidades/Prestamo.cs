using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EjBancoFinal_Entidades
{
    //[DataContract]
    public class Prestamo
    {
        private int _id;
        private double _tna;
        private string _linea;
        private int _plazo;
        private int _idCliente;
        private int _idTipo;
        private double _monto;
        private double _cuota;

        //[DataMember]
        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        //[DataMember(Name = "TNA")]
        public double tna
        {
            get { return this._tna; }
            set { this._tna = value; }
        }
        //[DataMember(Name = "Linea")]
        public string linea
        {
            get { return this._linea; }
            set { this._linea = value; }
        }
        //[DataMember(Name = "Plazo")]
        public int plazo
        {
            get { return this._plazo; }
            set { this._plazo = value; }
        }
        
        public int idCliente
        {
            get { return this._idCliente; }
            set { this._idCliente = value; }
        }

        public int idTipo
        {
            get { return this._idTipo; }
            set { this._idTipo = value; }
        }
        //[DataMember(Name = "Monto")]
        public double monto
        {
            get { return this._monto; }
            set { this._monto = value; }
        }
        //[DataMember(Name = "Cuota")]
        public double cuota
        {
            get { return this._cuota; }
            set { this._cuota = value; }
        }


        public Prestamo(int id, int plazo, int idcliente, double tna, string linea, int idtipo, double monto)
        {
            _id = id;
            _tna = tna;
            _linea = linea;
            _plazo = plazo;
            _idCliente = idcliente;
            _idTipo = idtipo;
            _monto = monto;
            _cuota = CalcularCuotaTotal();
            

        }
        public double CalcularCuotaCapital()
        {
            return (this._monto / this._plazo);
        }

        public double CalcularCuotaInteres()
        {
            return (this.CalcularCuotaCapital() * (this._tna / 12 / 100));
        }
        public double CalcularCuotaTotal()
        {
            return (this.CalcularCuotaCapital() + this.CalcularCuotaInteres());
        }

        public override string ToString()
        {
            return string.Format("ID: {0} - Cliente: {1} - Linea: {2} - Plazo: {3} - Cuota: {4}", this._id, this._idCliente, this._linea, this._plazo, this._cuota);
        }
    }
}
