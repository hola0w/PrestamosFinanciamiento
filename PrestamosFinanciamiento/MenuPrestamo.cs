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
    public partial class MenuPrestamo : Form
    {
        public MenuPrestamo()
        {
            InitializeComponent();
        }

        private void BTRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            FPRESTAMO miFPRESTAMO = new FPRESTAMO();
            miFPRESTAMO.ShowDialog();
        }

        private void BTReporteConsulta_Click(object sender, EventArgs e)
        {
            MGestionPrestamo miMGestionPrestamo = new MGestionPrestamo();
            miMGestionPrestamo.ShowDialog();
        }

        private void BTGestionarPrestamo_Click(object sender, EventArgs e)
        {
            MPrestamos miMPrestamos = new MPrestamos();
            miMPrestamos.ShowDialog();
        }
    }
}
