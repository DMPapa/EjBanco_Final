using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjBancoFinal_Entidades;
using EjBancoFinal_Negocio;

namespace EjBancoFinal
{
    public partial class frmTarjetaCredito : Form
    {
        private TarjetaCreditoServicio tjservicio;
        private ClienteServicio clienteservicio;
        private TarjetaCredito tarjeta;
        public frmTarjetaCredito()
        {
            InitializeComponent();
        }

        private void frmTarjetaCredito_Load(object sender, EventArgs e)
        {
            tjservicio = new TarjetaCreditoServicio();
            clienteservicio = new ClienteServicio();

            LlenarCMB();


        }

        private void LlenarCMB()
        {
            cmbClienteAlta.DataSource = clienteservicio.TraerClientes();
            cmbClienteAlta.SelectedIndex = -1;

            cmbClienteLista.DataSource = clienteservicio.TraerClientes();
            cmbClienteLista.SelectedIndex = -1;

            cmbTipo.DataSource = System.Enum.GetValues(typeof(TipoTarjeta));
            cmbTipo.SelectedIndex = -1;
            cmbPeriodo.DataSource = System.Enum.GetValues(typeof(PeriodoCierre));
            cmbPeriodo.SelectedIndex = -1;

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (cmbClienteLista.SelectedIndex == -1)
                DataTarjeta.DataSource = tjservicio.TraerTarjetas();
            else
            {
                DataTarjeta.DataSource = tjservicio.TraerTarjetasXCliente((((Cliente)cmbClienteLista.SelectedItem).id));
            }
        }

        private void LimpiarCampos()
        {
            cmbClienteAlta.SelectedIndex = -1;
            cmbPeriodo.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            txtLimite.Clear();
            txtNroPlastico.Clear();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(Errores))
                    throw new Exception("Ha habido un error al ingresar campos:" + "\n" + Errores);
                else if (cmbClienteAlta.SelectedIndex == -1 || cmbTipo.SelectedIndex == -1 || cmbPeriodo.SelectedIndex == -1)
                    throw new Exception("No puede haber ningún campo vacio");
                else
                    tjservicio.AgregarTarjeta(new TarjetaCredito(((cmbTipo.SelectedIndex) + 1), ((cmbPeriodo.SelectedIndex) + 1), int.Parse(txtLimite.Text), txtNroPlastico.Text, ((Cliente)(cmbClienteAlta.SelectedItem)).id));
                MessageBox.Show("Se ha cargado correctamente la tarjeta");
                LimpiarCampos();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        
            
              

        }

        private string Errores
        {
            get
            {
                return (Validacion.ValidarDouble(txtLimite.Text, "Limite") +
                       Validacion.ValidarLong(txtNroPlastico.Text, "Nro de plástico"));

            }
        }

        private void txtNroPlastico_TextChanged(object sender, EventArgs e)
        {
            LlenarDigitosFaltantes();
        }
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDigitosFaltantes();
        }

        private void LlenarDigitosFaltantes()
        {
            int nro;
            if (cmbTipo.SelectedIndex == -1)
                nro = 0;
            else if (cmbTipo.Text == "Amex")
                nro = 15;
            else
                nro = 16;

            lblDigitos.Text = "Digitos cargados: " + txtNroPlastico.Text.Length.ToString() + " / " + nro;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }


    }
}
