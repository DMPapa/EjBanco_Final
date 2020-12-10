using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EjBancoFinal_Entidades
{

    public class Cliente
    {
        private int _dni;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _email;
        private string _telefono;
        private DateTime _fechaNacimiento;
        private DateTime _fechaAlta;
        private bool _activo;
        private int _id;

        public int dni
        {
            get { return this._dni; }
            set { this._dni = value; }
        }
        public string nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public string apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }
        public string direccion
        {
            get { return this._direccion; }
            set { this._direccion = value; }
        }
        public string email
        {
            get { return this._email; }
            set { this._email = value; }
        }
        public string telefono
        {
            get { return this._telefono; }
            set { this._telefono = value; }
        }
        public DateTime fechaNacimiento
        {
            get { return this._fechaNacimiento; }
            set { this._fechaNacimiento = value; }
        }
        public DateTime fechaAlta
        {
            get { return this._fechaAlta; }
            set { this._fechaAlta = value; }
        }
        public bool activo
        {
            get { return this._activo; }
            set { this._activo = value ; }
        }
        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public Cliente() { }
        public Cliente(int DNI, string nombre, string apellido, string direccion, string mail, string telefono, DateTime nacimiento, int ID)
        {
            this._dni = DNI;
            this._nombre = nombre;
            this._apellido = apellido;
            this._direccion = direccion;
            this._email = mail;
            this._telefono = telefono;
            this._fechaNacimiento = nacimiento;
            this.fechaAlta = DateTime.Today;
            this._activo = true;
            this._id = ID;
        }

        public override string ToString()
        {
            return string.Format("Nombre: {0} {1} - DNI: {2}", this._nombre, this._apellido, this._dni);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is Cliente))
                return false;
            else
                return (((Cliente)obj).dni == this.dni);
        }

    }
}
