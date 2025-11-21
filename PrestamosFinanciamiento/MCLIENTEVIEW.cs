using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PrestamosFinanciamiento
{
    public partial class MCLIENTEVIEW : Form
    {

        public int IdClienteSeleccionado { get; private set; }
        public string NombreCliente { get; private set; }
        public string ApellidoCliente { get; private set; }
        public string CedulaCliente { get; private set; }
        public string TelefonoCliente { get; private set; }

      

        public MCLIENTEVIEW()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            textBox1.TextChanged += TextBox1_TextChanged;

            BCacelar.Click += BCancelar_Click;

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void MCLIENTEVIEW_Load(object sender, EventArgs e)
        {
            try
            {
                this.clienteTableAdapter.Fill(this.dBPrestamosDataSet.Cliente);

                ConfigurarColumnasDataGridView();

                textBox1.Focus();

                ActualizarContadorRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarColumnasDataGridView()
        {
            if (dataGridView1.Columns["idClienteDataGridViewTextBoxColumn"] != null)
            {
                dataGridView1.Columns["idClienteDataGridViewTextBoxColumn"].HeaderText = "ID";
                dataGridView1.Columns["idClienteDataGridViewTextBoxColumn"].Width = 60;
            }

            if (dataGridView1.Columns["nombreDataGridViewTextBoxColumn"] != null)
            {
                dataGridView1.Columns["nombreDataGridViewTextBoxColumn"].HeaderText = "Nombre";
                dataGridView1.Columns["nombreDataGridViewTextBoxColumn"].Width = 120;
            }

            if (dataGridView1.Columns["apellidoDataGridViewTextBoxColumn"] != null)
            {
                dataGridView1.Columns["apellidoDataGridViewTextBoxColumn"].HeaderText = "Apellido";
                dataGridView1.Columns["apellidoDataGridViewTextBoxColumn"].Width = 120;
            }

            if (dataGridView1.Columns["cedulaDataGridViewTextBoxColumn"] != null)
            {
                dataGridView1.Columns["cedulaDataGridViewTextBoxColumn"].HeaderText = "Cédula";
                dataGridView1.Columns["cedulaDataGridViewTextBoxColumn"].Width = 110;
            }

            if (dataGridView1.Columns["telefonoDataGridViewTextBoxColumn"] != null)
            {
                dataGridView1.Columns["telefonoDataGridViewTextBoxColumn"].HeaderText = "Teléfono";
                dataGridView1.Columns["telefonoDataGridViewTextBoxColumn"].Width = 100;
            }

            if (dataGridView1.Columns["direccionDataGridViewTextBoxColumn"] != null)
            {
                dataGridView1.Columns["direccionDataGridViewTextBoxColumn"].HeaderText = "Dirección";
                dataGridView1.Columns["direccionDataGridViewTextBoxColumn"].Width = 150;
            }

            if (dataGridView1.Columns["emailDataGridViewTextBoxColumn"] != null)
            {
                dataGridView1.Columns["emailDataGridViewTextBoxColumn"].HeaderText = "Email";
                dataGridView1.Columns["emailDataGridViewTextBoxColumn"].Width = 150;
            }
        }


        private void BSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarCliente();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea salir sin seleccionar un cliente?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void SeleccionarCliente()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente de la lista.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow filaSeleccionada = dataGridView1.CurrentRow;

                if (filaSeleccionada.Cells["idClienteDataGridViewTextBoxColumn"].Value == null)
                {
                    MessageBox.Show("La fila seleccionada no contiene datos válidos.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                IdClienteSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["idClienteDataGridViewTextBoxColumn"].Value);
                NombreCliente = filaSeleccionada.Cells["nombreDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                ApellidoCliente = filaSeleccionada.Cells["apellidoDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                CedulaCliente = filaSeleccionada.Cells["cedulaDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                TelefonoCliente = filaSeleccionada.Cells["telefonoDataGridViewTextBoxColumn"].Value?.ToString() ?? "";

                DialogResult confirmar = MessageBox.Show(
                    $"¿Desea seleccionar al cliente?\n\n" +
                    $"Nombre: {NombreCliente} {ApellidoCliente}\n" +
                    $"Cédula: {CedulaCliente}\n" +
                    $"Teléfono: {TelefonoCliente}",
                    "Confirmar Selección",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmar == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar cliente: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SeleccionarCliente();
            }
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textoBusqueda = textBox1.Text.Trim();

                if (string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    clienteBindingSource.RemoveFilter();
                }
                else
                {
                    string filtro = string.Format(
                        "Nombre LIKE '%{0}%' OR " +
                        "Apellido LIKE '%{0}%' OR " +
                        "Cedula LIKE '%{0}%' OR " +
                        "telefono LIKE '%{0}%' OR " +
                        "email LIKE '%{0}%'",
                        textoBusqueda.Replace("'", "''") 
                    );

                    clienteBindingSource.Filter = filtro;
                }

                ActualizarContadorRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarContadorRegistros()
        {
            try
            {
                int totalRegistros = clienteBindingSource.Count;
                this.Text = $"Selección de Cliente - {totalRegistros} registro(s)";
            }
            catch
            {
                this.Text = "Selección de Cliente";
            }
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && dataGridView1.Focused)
            {
                SeleccionarCliente();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return true;
            }

            if (keyData == Keys.Down || keyData == Keys.Up)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            if (char.IsLetterOrDigit((char)keyData) && !textBox1.Focused)
            {
                textBox1.Focus();
                return base.ProcessCmdKey(ref msg, keyData);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void PreseleccionarCliente(int idCliente)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells["idClienteDataGridViewTextBoxColumn"].Value) == idCliente)
                    {
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al preseleccionar cliente: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MostrarSoloClientesActivos()
        {
            try
            {
                if (dBPrestamosDataSet.Cliente.Columns.Contains("activo"))
                {
                    clienteBindingSource.Filter = "activo = 1";
                    ActualizarContadorRegistros();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar clientes activos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}