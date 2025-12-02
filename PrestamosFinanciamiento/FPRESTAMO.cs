   using System;
using System.Data;
using System.Windows.Forms;
using Negocios;

namespace PrestamosFinanciamiento
{
    public partial class FPRESTAMO : Form
    {
        private bool esNuevo = true;
        private int idPrestamoActual = 0;
        private int idClienteSeleccionado = 0;

        public FPRESTAMO()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            DTInicio.Format = DateTimePickerFormat.Short;
            DTFin.Format = DateTimePickerFormat.Short;
            DTInicio.Value = DateTime.Now;
            DTInicio.ValueChanged += DTInicio_ValueChanged;
            TBtiempo.TextChanged += TBtiempo_TextChanged;
            RDMes.Checked = true;
            RDDias.CheckedChanged += RadioButton_CheckedChanged;
            RDMes.CheckedChanged += RadioButton_CheckedChanged;
            RDAno.CheckedChanged += RadioButton_CheckedChanged;
            TBNombreC.ReadOnly = true;
            TBApeClient.ReadOnly = true;
            TBCedCliente.ReadOnly = true;
            TBTelCliente.ReadOnly = true;
            textBox1.ReadOnly = true;
            TBMontoSolicitado.KeyPress += DecimalTextBox_KeyPress;
            TBTasa.KeyPress += DecimalTextBox_KeyPress;
            TBtiempo.KeyPress += NumericTextBox_KeyPress;
            BGuardar.Click += BGuardar_Click;
            BCacelar.Click += BCancelar_Click;
            BTCalcularCuotasa.Click += BCalcularCuotas_Click;

            LimpiarCampos();
        }


        private void BBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                MCLIENTEVIEW miMCLIENTEVIEW = new MCLIENTEVIEW();

                if (miMCLIENTEVIEW.ShowDialog() == DialogResult.OK)
                {
                    idClienteSeleccionado = miMCLIENTEVIEW.IdClienteSeleccionado;
                    textBox1.Text = miMCLIENTEVIEW.IdClienteSeleccionado.ToString();
                    TBNombreC.Text = miMCLIENTEVIEW.NombreCliente;
                    TBApeClient.Text = miMCLIENTEVIEW.ApellidoCliente;
                    TBCedCliente.Text = miMCLIENTEVIEW.CedulaCliente;
                    TBTelCliente.Text = miMCLIENTEVIEW.TelefonoCliente;

                    HabilitarCamposPrestamo(true);
                    TBMontoSolicitado.Focus();

                    esNuevo = true;
                    idPrestamoActual = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar cliente: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idClienteSeleccionado == 0 || string.IsNullOrWhiteSpace(TBNombreC.Text))
                {
                    MessageBox.Show("Debe buscar y seleccionar un cliente antes de guardar el préstamo.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BBuscar.Focus();
                    return;
                }

                if (!ValidarCampos())
                    return;

                decimal monto = decimal.Parse(TBMontoSolicitado.Text);
                decimal tasa = decimal.Parse(TBTasa.Text);
                int plazo = int.Parse(TBtiempo.Text);
                int plazoMeses = ConvertirPlazoAMeses(plazo);
                decimal cuotaMensual = CalcularCuotaMensual();
                string unidadTiempo = ObtenerUnidadTiempoSeleccionada();

                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de {(esNuevo ? "registrar" : "actualizar")} este préstamo?\n\n" +
                    $"Cliente: {TBNombreC.Text} {TBApeClient.Text}\n" +
                    $"Cédula: {TBCedCliente.Text}\n" +
                    $"Monto: RD$ {monto:N2}\n" +
                    $"Tasa: {tasa}% anual\n" +
                    $"Plazo: {plazo} {unidadTiempo} ({plazoMeses} meses)\n" +
                    $"Cuota Mensual: RD$ {cuotaMensual:N2}\n" +
                    $"Fecha Inicio: {DTInicio.Value:dd/MM/yyyy}\n" +
                    $"Fecha Vencimiento: {DTFin.Value:dd/MM/yyyy}",
                    "Confirmar Préstamo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                    return;

                DateTime fechaInicio = DTInicio.Value.Date;
                DateTime fechaVencimiento = DTFin.Value.Date;

                string mensaje;

                if (esNuevo)
                {
                    string numeroPrestamo = GenerarNumeroPrestamo();

                    mensaje = CNPrestamos.Insertar(
                        numeroPrestamo,
                        idClienteSeleccionado,
                        monto,
                        tasa,
                        plazoMeses, 
                        fechaInicio,
                        fechaVencimiento,
                        "Vigente",
                        monto, 
                        true
                    );
                }
                else
                {
                    mensaje = CNPrestamos.Actualizar(
                        idPrestamoActual,
                        "PR-" + idPrestamoActual.ToString("D8"),
                        idClienteSeleccionado,
                        monto,
                        tasa,
                        plazoMeses,
                        fechaInicio,
                        fechaVencimiento,
                        "Vigente",
                        monto,
                        true
                    );
                }

                if (mensaje.Contains("correctamente"))
                {
                    MessageBox.Show(mensaje, "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    BBuscar.Focus();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el préstamo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de cancelar la operación?\nSe perderán todos los datos no guardados.",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                LimpiarCampos();
                BBuscar.Focus();
            }
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

        private void BCalcularCuotas_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TBMontoSolicitado.Text) ||
                    string.IsNullOrWhiteSpace(TBTasa.Text) ||
                    string.IsNullOrWhiteSpace(TBtiempo.Text))
                {
                    MessageBox.Show("Debe ingresar el monto, la tasa de interés y el plazo para calcular las cuotas.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal monto, tasa;
                int plazo;

                if (!decimal.TryParse(TBMontoSolicitado.Text, out monto) || monto <= 0)
                {
                    MessageBox.Show("El monto debe ser un valor válido mayor a cero.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBMontoSolicitado.Focus();
                    return;
                }

                if (!decimal.TryParse(TBTasa.Text, out tasa) || tasa < 0)
                {
                    MessageBox.Show("La tasa debe ser un valor válido mayor o igual a cero.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBTasa.Focus();
                    return;
                }

                if (!int.TryParse(TBtiempo.Text, out plazo) || plazo <= 0)
                {
                    MessageBox.Show("El plazo debe ser un número válido mayor a cero.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBtiempo.Focus();
                    return;
                }

                decimal cuotaMensual = CalcularCuotaMensual();
                int plazoMeses = ConvertirPlazoAMeses(plazo);
                decimal totalAPagar = cuotaMensual * plazoMeses;
                decimal totalIntereses = totalAPagar - monto;

                string unidadTiempo = ObtenerUnidadTiempoSeleccionada();

                MessageBox.Show(
                    $"DETALLE DEL PRÉSTAMO\n\n" +
                    $"Monto del Préstamo: RD$ {monto:N2}\n" +
                    $"Tasa de Interés: {tasa}% anual\n" +
                    $"Plazo: {plazo} {unidadTiempo} ({plazoMeses} meses)\n\n" +
                    $"Cuota Mensual: RD$ {cuotaMensual:N2}\n" +
                    $"Total de Intereses: RD$ {totalIntereses:N2}\n" +
                    $"Total a Pagar: RD$ {totalAPagar:N2}",
                    "Cálculo de Cuotas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular cuotas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TBMontoSolicitado.Text))
            {
                MessageBox.Show("Ingrese el monto solicitado.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMontoSolicitado.Focus();
                return false;
            }

            decimal monto;
            if (!decimal.TryParse(TBMontoSolicitado.Text, out monto) || monto <= 0)
            {
                MessageBox.Show("El monto solicitado debe ser un valor numérico mayor a cero.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMontoSolicitado.Focus();
                TBMontoSolicitado.SelectAll();
                return false;
            }

            if (monto > 10000000) 
            {
                MessageBox.Show("El monto solicitado no puede exceder RD$ 10,000,000.00",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMontoSolicitado.Focus();
                TBMontoSolicitado.SelectAll();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBTasa.Text))
            {
                MessageBox.Show("Ingrese la tasa de interés anual.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBTasa.Focus();
                return false;
            }

            decimal tasa;
            if (!decimal.TryParse(TBTasa.Text, out tasa) || tasa < 0)
            {
                MessageBox.Show("La tasa de interés debe ser un valor numérico mayor o igual a cero.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBTasa.Focus();
                TBTasa.SelectAll();
                return false;
            }

            if (tasa > 99.99m)
            {
                MessageBox.Show("La tasa de interés no puede exceder el 99.99%",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBTasa.Focus();
                TBTasa.SelectAll();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBtiempo.Text))
            {
                MessageBox.Show("Ingrese el plazo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBtiempo.Focus();
                return false;
            }

            int plazo;
            if (!int.TryParse(TBtiempo.Text, out plazo) || plazo <= 0)
            {
                MessageBox.Show("El plazo debe ser un número entero mayor a cero.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBtiempo.Focus();
                TBtiempo.SelectAll();
                return false;
            }

            if (!ValidarPlazoSegunUnidad(plazo))
                return false;

            if (DTInicio.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser anterior a la fecha actual.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DTInicio.Focus();
                return false;
            }

            if (DTFin.Value.Date <= DTInicio.Value.Date)
            {
                MessageBox.Show("La fecha de vencimiento debe ser posterior a la fecha de inicio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DTFin.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarPlazoSegunUnidad(int plazo)
        {
            if (RDDias.Checked)
            {
                if (plazo < 1 || plazo > 10950) 
                {
                    MessageBox.Show("El plazo en días debe estar entre 1 y 10,950 (30 años).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBtiempo.Focus();
                    TBtiempo.SelectAll();
                    return false;
                }
            }
            else if (RDMes.Checked)
            {
                if (plazo < 1 || plazo > 360) 
                {
                    MessageBox.Show("El plazo en meses debe estar entre 1 y 360 (30 años).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBtiempo.Focus();
                    TBtiempo.SelectAll();
                    return false;
                }
            }
            else if (RDAno.Checked)
            {
                if (plazo < 1 || plazo > 30)
                {
                    MessageBox.Show("El plazo en años debe estar entre 1 y 30.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBtiempo.Focus();
                    TBtiempo.SelectAll();
                    return false;
                }
            }

            return true;
        }


        private void LimpiarCampos()
        {
            textBox1.Clear();
            TBNombreC.Clear();
            TBApeClient.Clear();
            TBCedCliente.Clear();
            TBTelCliente.Clear();
            TBMontoSolicitado.Clear();
            TBTasa.Clear();
            TBtiempo.Clear();
            DTInicio.Value = DateTime.Now;
            DTFin.Value = DateTime.Now.AddMonths(1);
            RDMes.Checked = true;
            esNuevo = true;
            idPrestamoActual = 0;
            idClienteSeleccionado = 0;

            HabilitarCamposPrestamo(false);
        }

        private void HabilitarCamposPrestamo(bool habilitar)
        {
            TBMontoSolicitado.Enabled = habilitar;
            TBTasa.Enabled = habilitar;
            TBtiempo.Enabled = habilitar;
            DTInicio.Enabled = habilitar;
           // DTFin.Enabled = habilitar;
            RDDias.Enabled = habilitar;
            RDMes.Enabled = habilitar;
            RDAno.Enabled = habilitar;
            BGuardar.Enabled = habilitar;
            BTCalcularCuotasa.Enabled = habilitar; 
        }

        private string GenerarNumeroPrestamo()
        {
            return "PR-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
        }

        private void CalcularFechaVencimiento()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(TBtiempo.Text))
                {
                    int plazo;
                    if (int.TryParse(TBtiempo.Text, out plazo) && plazo > 0)
                    {
                        int mesesEquivalentes = ConvertirPlazoAMeses(plazo);

                        if (mesesEquivalentes > 0 && mesesEquivalentes <= 360)
                        {
                            DTFin.Value = DTInicio.Value.AddMonths(mesesEquivalentes);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private int ConvertirPlazoAMeses(int plazo)
        {
            if (RDDias.Checked)
            {
                return (int)Math.Ceiling(plazo / 30.0);
            }
            else if (RDMes.Checked)
            {
                return plazo;
            }
            else if (RDAno.Checked)
            {
                return plazo * 12;
            }

            return plazo; 
        }

        private string ObtenerUnidadTiempoSeleccionada()
        {
            if (RDDias.Checked)
                return "días";
            else if (RDMes.Checked)
                return "meses";
            else if (RDAno.Checked)
                return "años";

            return "meses";
        }

        private decimal CalcularCuotaMensual()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TBMontoSolicitado.Text) ||
                    string.IsNullOrWhiteSpace(TBTasa.Text) ||
                    string.IsNullOrWhiteSpace(TBtiempo.Text))
                    return 0;

                decimal monto = decimal.Parse(TBMontoSolicitado.Text);
                decimal tasaAnual = decimal.Parse(TBTasa.Text);
                int plazo = int.Parse(TBtiempo.Text);

                int plazoMeses = ConvertirPlazoAMeses(plazo);

                if (plazoMeses <= 0) return 0;

                if (tasaAnual == 0)
                {
                    return Math.Round(monto / plazoMeses, 2);
                }

                decimal tasaMensual = (tasaAnual / 100) / 12;

                // Fórmula de cuota : M = P * [i(1+i)^n] / [(1+i)^n - 1]
                double i = (double)tasaMensual;
                double p = (double)monto;
                int n = plazoMeses;

                double factorPotencia = Math.Pow(1 + i, n);
                double cuota = p * (i * factorPotencia) / (factorPotencia - 1);

                return Math.Round((decimal)cuota, 2);
            }
            catch
            {
                return 0;
            }
        }

        private void CargarDatosPrestamo(DataRow row)
        {
            try
            {
                idPrestamoActual = Convert.ToInt32(row["id_prestamo"]);
                idClienteSeleccionado = Convert.ToInt32(row["idcliente"]);

                textBox1.Text = idClienteSeleccionado.ToString();
                TBMontoSolicitado.Text = Convert.ToDecimal(row["monto_prestamo"]).ToString("F2");
                TBTasa.Text = Convert.ToDecimal(row["tasa_interes"]).ToString("F2");
                TBtiempo.Text = row["plazo_meses"].ToString();
                DTInicio.Value = Convert.ToDateTime(row["fecha_prestamo"]);
                DTFin.Value = Convert.ToDateTime(row["fecha_vencimiento"]);

                RDMes.Checked = true;

                esNuevo = false;
                HabilitarCamposPrestamo(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del préstamo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && tb.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void DTInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaVencimiento();
        }

        private void TBtiempo_TextChanged(object sender, EventArgs e)
        {
            CalcularFechaVencimiento();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CalcularFechaVencimiento();
        }

        private void CoClient_Click(object sender, EventArgs e)
        {
        }


        public void CargarPrestamoExistente(int idPrestamo)
        {
            try
            {
                DataTable dt = CNPrestamos.ObtenerPrestamosPorID(idPrestamo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    CargarDatosPrestamo(dt.Rows[0]);

                    MCLIENTEVIEW clienteView = new MCLIENTEVIEW();
             
                }
                else
                {
                    MessageBox.Show("No se encontró el préstamo especificado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el préstamo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BGuardar_Click_1(object sender, EventArgs e)
        {
    
        }
    }
}