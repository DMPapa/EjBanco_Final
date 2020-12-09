using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EjBancoFinal_Entidades
{

    public class PrestamoTipo
    {
        private double _tna;
        private string _linea;
        private int _id;

        public double tna
        {
            get { return this._tna; }
            set { this._tna = value; }
        }

        public string linea
        {
            get { return this._linea; }
            set { this._linea = value; }
        }

        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public override string ToString()
        {
            return string.Format("Linea: {0} - TNA: {1}", this._linea, this._tna);
        }
    }
}
