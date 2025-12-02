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
            CargarInformacionUsuario();
        }


        private void CargarInformacionUsuario()
        {
            dateTimePicker1.Enabled = false;
            label2.Text = SesionUsuario.NombreCompleto;
            // labelUsuario.Text = "Usuario: " + SesionUsuario.Username;
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
            FGestionPago miFGestionPago = new FGestionPago();
            miFGestionPago.ShowDialog();
        }

        private void BTInfo_Click(object sender, EventArgs e)
        {
            INFO miINFO = new INFO();
            miINFO.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            REmpleado miREmpleado = new REmpleado();
            miREmpleado.ShowDialog();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
