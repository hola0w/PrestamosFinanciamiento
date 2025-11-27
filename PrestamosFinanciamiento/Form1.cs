using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestamosFinanciamiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTGCliente_Click(object sender, EventArgs e)
        {
            FREGCLIENTE miFREGCLIENTE = new FREGCLIENTE();
            miFREGCLIENTE.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FPRESTAMO miFPRESTAMO = new FPRESTAMO();
            miFPRESTAMO.ShowDialog();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
               "¿Está seguro de que desea salir?",
               "Confirmar Salida",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BTPrestamo_Click(object sender, EventArgs e)
        {
            MenuPrestamo miMenuPrestamo = new MenuPrestamo();
            miMenuPrestamo.ShowDialog();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RERyPprestamos miRERyPprestamos = new RERyPprestamos();
            miRERyPprestamos.ShowDialog();
        }
    }
}
