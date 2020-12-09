using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjBancoFinal
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCliente cliente = new frmCliente();
            cliente.Owner = this;
            cliente.Show();
            this.Hide();
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            frmPrestamo prestamo = new frmPrestamo();
            prestamo.Owner = this;
            prestamo.Show();
            this.Hide();
        }
    }
}
