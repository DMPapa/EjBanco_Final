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
    public partial class frmPrestamo : Form
    {
        private ClienteServicio clienteservicio;
        private PrestamoServicio prestamoservicio;
        private Operador operador;

        public frmPrestamo()
        {
            InitializeComponent();
        }

        private void frmPrestamo_Load(object sender, EventArgs e)
        {
            prestamoservicio = new PrestamoServicio();
            clienteservicio = new ClienteServicio();

            lstTipos.DataSource = null;
            lstTipos.DataSource = prestamoservicio.TraerTipos();
            txtLinea.Clear();
            txtTNA.Clear();

            cmbCliente.DataSource = clienteservicio.TraerClientes();
            cmbCliente.SelectedIndex = -1;


            LlenarOperador();

        }

        private void LlenarOperador()
        {
            operador = prestamoservicio.GenerarOperador();
            lstPrestamos.DataSource = null;
            lstPrestamos.DataSource = operador.prestamos;
            txtComisionTotal.Text = operador.comision.ToString();
        }

        private void lstTipos_SelectedIndexChanged(object sender, EventArgs e)
        {

                txtLinea.Text = ((PrestamoTipo)lstTipos.SelectedItem).linea.ToString();
                txtTNA.Text = ((PrestamoTipo)lstTipos.SelectedItem).tna.ToString();

        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            txtMonto.ReadOnly = true;
            txtPlazo.ReadOnly = true;
            lstTipos.Enabled = false;
            cmbCliente.Enabled = false;

            try
            {
                if (!string.IsNullOrEmpty(Errores))
                    throw new Exception("Ingreso erroneo en:" + "\n" + this.Errores);
                else if (cmbCliente.SelectedIndex == -1)
                    throw new Exception("El cliente no puede ser nulo");
                else
                {
                    Prestamo p = new Prestamo(prestamoservicio.ProximoID(), int.Parse(txtPlazo.Text), ((Cliente)cmbCliente.SelectedItem).id, double.Parse(txtTNA.Text), txtLinea.Text, ((PrestamoTipo)lstTipos.SelectedItem).id, double.Parse(txtMonto.Text));
                    txtCuotaC.Text = Math.Round(p.CalcularCuotaCapital(), 2).ToString();
                    txtCuotaI.Text = Math.Round(p.CalcularCuotaInteres(), 2).ToString();
                    txtCuotaT.Text = Math.Round(p.CalcularCuotaTotal(), 2).ToString();

                }
            } 
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
                LimpiarSimulacion();
            }
        }


        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCuotaT.Text == "")
                    throw new Exception("Primero debe haber simulado el préstamo");
                else
                {

                    Prestamo p = new Prestamo(prestamoservicio.ProximoID(), int.Parse(txtPlazo.Text), ((Cliente)cmbCliente.SelectedItem).id, double.Parse(txtTNA.Text), txtLinea.Text, ((PrestamoTipo)lstTipos.SelectedItem).id, double.Parse(txtMonto.Text));
                    prestamoservicio.AgregarPrestamo(p);
                    MessageBox.Show("Se ha agregado correctamente el prestamo");
                    LlenarOperador();
                    LimpiarSimulacion();
                }
            } catch (Exception ex2) 
                    {
                        MessageBox.Show(ex2.Message);
                        LimpiarSimulacion();
                    }
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
        private void LimpiarSimulacion()
        {
            lstTipos.Enabled = true;
            cmbCliente.SelectedIndex = -1;
            cmbCliente.Enabled = true;
            txtMonto.Clear();
            txtMonto.ReadOnly = false;
            txtPlazo.Clear();
            txtPlazo.ReadOnly = false;
            txtCuotaC.Clear();
            txtCuotaI.Clear();
            txtCuotaT.Clear();
            txtLinea.Clear();
            txtTNA.Clear();

        }
        private string Errores
        {
            get
            {
                return (Validacion.ValidarNumero(txtPlazo.Text, "plazo") +
                        Validacion.ValidarDouble(txtMonto.Text, "monto"));
            }
        }
        

    }
}
