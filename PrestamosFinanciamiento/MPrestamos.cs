using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Negocios;
using System.Globalization;

namespace PrestamosFinanciamiento
{
    public partial class MPrestamos : Form
    {

        public string PrestamoSeleccionado { get; private set; }
        public int IdPrestamoSeleccionado { get; private set; }
        public string NombreCliente { get; private set; }
        public string CedulaCliente { get; private set; }
        public decimal MontoSeleccionado { get; private set; }
        public decimal SaldoPendiente { get; private set; }

        private DataTable dtPrestamos;
        private DataView dvPrestamos;
        private const string ESTADO_PAGADO = "Pagado";
        private const string ESTADO_CANCELADO = "Cancelado";

        public MPrestamos()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            ConfigurarDataGridView();
            ConfigurarEstilosVisuales();
            AsignarEventos();

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            CrearColumnasDataGridView();
        }

        private void ConfigurarEstilosVisuales()
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void AsignarEventos()
        {
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            TBBuscarPrestamo.TextChanged += TBBuscarPrestamo_TextChanged;
            BSeleccionar.Click += BSeleccionar_Click;
            BCacelar.Click += BCancelar_Click;
            this.Load += MPrestamos_Load;
        }

        private void CrearColumnasDataGridView()
        {
            CultureInfo usdCulture = new CultureInfo("en-US");

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_prestamo",
                DataPropertyName = "id_prestamo",
                HeaderText = "ID",
                Visible = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "numero_prestamo",
                DataPropertyName = "numero_prestamo",
                HeaderText = "Nº Préstamo",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_cliente",
                DataPropertyName = "nombre_cliente",
                HeaderText = "Cliente",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cedula",
                DataPropertyName = "cedula",
                HeaderText = "Cédula",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "telefono",
                DataPropertyName = "telefono",
                HeaderText = "Teléfono",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "monto_prestamo",
                DataPropertyName = "monto_prestamo",
                HeaderText = "Monto",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "$#,##0.00",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estado",
                DataPropertyName = "estado",
                HeaderText = "Estado",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "saldo_pendiente",
                DataPropertyName = "saldo_pendiente",
                HeaderText = "Saldo Pendiente",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "$#,##0.00",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idcliente",
                DataPropertyName = "idcliente",
                HeaderText = "ID Cliente",
                Visible = false
            });
        }

        private void MPrestamos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarPrestamos();
                TBBuscarPrestamo.Focus();
                ActualizarContadorRegistros();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar los préstamos: {ex.Message}");
            }
        }

        private void CargarPrestamos()
        {
            try
            {
                dtPrestamos = CNPrestamos.ObtenerTodosActivos(true);

                if (dtPrestamos != null && dtPrestamos.Rows.Count > 0)
                {
                    dvPrestamos = new DataView(dtPrestamos);
                    AplicarFiltroEstadosActivos();
                    dataGridView1.DataSource = dvPrestamos;
                }
                else
                {
                    dataGridView1.DataSource = null;
                }

                ActualizarContadorRegistros();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar datos: {ex.Message}");
                dataGridView1.DataSource = null;
            }
        }

        private void AplicarFiltroEstadosActivos()
        {
            if (dvPrestamos != null)
            {
                dvPrestamos.RowFilter = $"estado <> '{ESTADO_PAGADO}' AND estado <> '{ESTADO_CANCELADO}'";
            }
        }

        private void TBBuscarPrestamo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dvPrestamos == null) return;

                string textoBusqueda = TBBuscarPrestamo.Text.Trim();

                if (string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    AplicarFiltroEstadosActivos();
                }
                else
                {
                    AplicarFiltroBusqueda(textoBusqueda);
                }

                ActualizarContadorRegistros();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al filtrar: {ex.Message}");
            }
        }

        private void AplicarFiltroBusqueda(string textoBusqueda)
        {
            string busquedaSegura = textoBusqueda.Replace("'", "''");

            string filtroEstado = $"estado <> '{ESTADO_PAGADO}' AND estado <> '{ESTADO_CANCELADO}'";

            string filtroBusqueda = $"(CONVERT(numero_prestamo, 'System.String') LIKE '*{busquedaSegura}*' OR " +
                                   $"nombre_cliente LIKE '*{busquedaSegura}*' OR " +
                                   $"CONVERT(cedula, 'System.String') LIKE '*{busquedaSegura}*' OR " +
                                   $"estado LIKE '*{busquedaSegura}*')";

            dvPrestamos.RowFilter = $"{filtroEstado} AND {filtroBusqueda}";
        }

        public void FiltrarPorEstado(string estado)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(estado)) return;

                if (dvPrestamos != null)
                {
                    string estadoSeguro = estado.Replace("'", "''");
                    dvPrestamos.RowFilter = $"estado = '{estadoSeguro}'";
                    ActualizarContadorRegistros();
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al filtrar por estado: {ex.Message}");
            }
        }

        public void FiltrarPorCliente(int idCliente)
        {
            try
            {
                if (idCliente <= 0)
                {
                    MostrarAdvertencia("ID de cliente no válido");
                    return;
                }

                DataTable dtPrestamoCliente = CNPrestamos.ObtenerPrestamosPorCliente(idCliente);

                if (dtPrestamoCliente != null && dtPrestamoCliente.Rows.Count > 0)
                {
                    dtPrestamos = dtPrestamoCliente;
                    dvPrestamos = new DataView(dtPrestamos);
                    AplicarFiltroEstadosActivos();
                    dataGridView1.DataSource = dvPrestamos;
                    ActualizarContadorRegistros();
                }
                else
                {
                    MostrarAdvertencia("No se encontraron préstamos para este cliente");
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al filtrar por cliente: {ex.Message}");
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SeleccionarPrestamo();
            }
        }

        private void BSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarPrestamo();
        }

        private void SeleccionarPrestamo()
        {
            try
            {
                if (!ValidarSeleccion()) return;

                DataGridViewRow fila = dataGridView1.CurrentRow;
                DataRowView rowView = fila.DataBoundItem as DataRowView;

                if (rowView == null)
                {
                    MostrarError("Error al obtener los datos de la fila seleccionada.");
                    return;
                }

                if (!ExtraerDatosPrestamo(rowView)) return;

                if (!ValidarSaldoPendiente()) return;

                if (ConfirmarSeleccion())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al seleccionar préstamo: {ex.Message}");
            }
        }

        private bool ValidarSeleccion()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MostrarAdvertencia("Debe seleccionar un préstamo de la lista.");
                return false;
            }
            return true;
        }

        private bool ExtraerDatosPrestamo(DataRowView rowView)
        {
            try
            {
                IdPrestamoSeleccionado = ObtenerValorEntero(rowView, "id_prestamo");
                PrestamoSeleccionado = ObtenerValorString(rowView, "numero_prestamo");
                NombreCliente = ObtenerValorString(rowView, "nombre_cliente");
                CedulaCliente = ObtenerValorString(rowView, "cedula");
                MontoSeleccionado = ObtenerValorDecimal(rowView, "monto_prestamo");
                SaldoPendiente = ObtenerValorDecimal(rowView, "saldo_pendiente");

                return true;
            }
            catch (Exception ex)
            {
                MostrarError($"Error al extraer datos del préstamo: {ex.Message}");
                return false;
            }
        }

        private bool ValidarSaldoPendiente()
        {
            if (SaldoPendiente <= 0)
            {
                MostrarAdvertencia("Este préstamo no tiene saldo pendiente.");
                return false;
            }
            return true;
        }

        private bool ConfirmarSeleccion()
        {
            DialogResult resultado = MessageBox.Show(
                $"¿Desea seleccionar este préstamo?\n\n" +
                $"Nº Préstamo: {PrestamoSeleccionado}\n" +
                $"Cliente: {NombreCliente}\n" +
                $"Cédula: {CedulaCliente}\n" +
                $"Monto: ${MontoSeleccionado:N2}\n" +
                $"Saldo Pendiente: ${SaldoPendiente:N2}",
                "Confirmar Selección",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        private int ObtenerValorEntero(DataRowView row, string columna)
        {
            return row[columna] != DBNull.Value ? Convert.ToInt32(row[columna]) : 0;
        }

        private string ObtenerValorString(DataRowView row, string columna)
        {
            return row[columna]?.ToString() ?? string.Empty;
        }

        private decimal ObtenerValorDecimal(DataRowView row, string columna)
        {
            return row[columna] != DBNull.Value ? Convert.ToDecimal(row[columna]) : 0m;
        }

        private void ActualizarContadorRegistros()
        {
            try
            {
                int totalRegistros = dataGridView1.Rows.Count;
                label2.Text = $"Vista de Préstamos - {totalRegistros} registro(s)";
            }
            catch
            {
                label2.Text = "Vista de Préstamos";
            }
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MostrarInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PreseleccionarPrestamo(int idPrestamo)
        {
            try
            {
                if (idPrestamo <= 0) return;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataRowView rowView = row.DataBoundItem as DataRowView;
                    if (rowView != null &&
                        rowView["id_prestamo"] != DBNull.Value &&
                        Convert.ToInt32(rowView["id_prestamo"]) == idPrestamo)
                    {
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al preseleccionar préstamo: {ex.Message}");
            }
        }

        public void Refrescar()
        {
            CargarPrestamos();
            TBBuscarPrestamo.Clear();
            TBBuscarPrestamo.Focus();
        }

        public void CargarPrestamoPorNumero(string numeroPrestamo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroPrestamo)) return;

                DataTable dtPrestamo = CNPrestamos.ObtenerPrestamoPorNumero(numeroPrestamo);

                if (dtPrestamo != null && dtPrestamo.Rows.Count > 0)
                {
                    dtPrestamos = dtPrestamo;
                    dvPrestamos = new DataView(dtPrestamos);
                    dataGridView1.DataSource = dvPrestamos;
                    ActualizarContadorRegistros();

                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[0].Selected = true;
                    }
                }
                else
                {
                    MostrarAdvertencia($"No se encontró el préstamo con número: {numeroPrestamo}");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar préstamo por número: {ex.Message}");
            }
        }

        public void CargarPrestamoPorId(int idPrestamo)
        {
            try
            {
                if (idPrestamo <= 0) return;

                DataTable dtPrestamo = CNPrestamos.ObtenerPrestamosPorID(idPrestamo);

                if (dtPrestamo != null && dtPrestamo.Rows.Count > 0)
                {
                    dtPrestamos = dtPrestamo;
                    dvPrestamos = new DataView(dtPrestamos);
                    dataGridView1.DataSource = dvPrestamos;
                    ActualizarContadorRegistros();

                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[0].Selected = true;
                    }
                }
                else
                {
                    MostrarAdvertencia($"No se encontró el préstamo con ID: {idPrestamo}");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar préstamo por ID: {ex.Message}");
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter when dataGridView1.Focused:
                    SeleccionarPrestamo();
                    return true;

                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return true;

                case Keys.F5:
                    Refrescar();
                    return true;

                case Keys.Down:
                case Keys.Up:
                    return base.ProcessCmdKey(ref msg, keyData);

                default:
                    if (char.IsLetterOrDigit((char)keyData) && !TBBuscarPrestamo.Focused)
                    {
                        TBBuscarPrestamo.Focus();
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (dvPrestamos != null)
            {
                dvPrestamos.Dispose();
                dvPrestamos = null;
            }

            if (dtPrestamos != null)
            {
                dtPrestamos.Dispose();
                dtPrestamos = null;
            }

            base.OnFormClosing(e);
        }

    }
}