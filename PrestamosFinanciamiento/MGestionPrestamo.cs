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
    public partial class MGestionPrestamo : Form
    {
        public MGestionPrestamo()
        {
            InitializeComponent();
        }


        private void RBCodCliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CodCliente_Click(object sender, EventArgs e)
        {

        }

        private void BSeleccionar_Click(object sender, EventArgs e)
        {

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
    }
}
