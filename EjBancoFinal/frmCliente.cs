using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjBancoFinal_Negocio;
using EjBancoFinal_Entidades;

namespace EjBancoFinal
{
    public partial class frmCliente : Form
    {

        private ClienteServicio clienteservicio;
        public frmCliente()
        {
            InitializeComponent();
        }
        private void frmCliente_Load(object sender, EventArgs e)
        {
            clienteservicio = new ClienteServicio();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnlistar_Click(object sender, EventArgs e)
        {
            List<Cliente> listado = new List<Cliente>();
            listado = clienteservicio.TraerClientes();
            dataGridView1.DataSource = listado;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Errores))
                    throw new Exception("Error en los campos" + "\n" + this.Errores);
                else
                {
                    Cliente cliente = new Cliente(int.Parse(txtDNI.Text), txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text, dtpNacimiento.Value, clienteservicio.ProximoID());
                    clienteservicio.AgregarCliente(cliente);
                    MessageBox.Show("El cliente se ha agregado correctamente");
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message); }

                    
        }
        private string Errores
        {
            get
            {
                return (Validacion.ValidarNumero(txtDNI.Text, "DNI") +
                        Validacion.ValidarString(txtNombre.Text, "Nombre") +
                        Validacion.ValidarString(txtApellido.Text, "Apellido") +
                        Validacion.ValidarString(txtDireccion.Text, "Direccion") +
                        Validacion.ValidarString(txtEmail.Text, "Email") +
                        Validacion.ValidarNumero(txtTelefono.Text, "Telefono"));
                        
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtDireccion.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            dtpNacimiento.Value = DateTime.Today;
        }
    }
}
