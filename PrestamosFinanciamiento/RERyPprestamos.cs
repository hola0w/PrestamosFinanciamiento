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
    public partial class RERyPprestamos : Form
    {
        public RERyPprestamos()
        {
            InitializeComponent();
        }

        private void RERyPprestamos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.Cliente' Puede moverla o quitarla según sea necesario.
            this.ClienteTableAdapter.Fill(this.DataSet1.Cliente);
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.Prestamos' Puede moverla o quitarla según sea necesario.
            this.PrestamosTableAdapter.Fill(this.DataSet1.Prestamos);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
           
        }
    }
}
