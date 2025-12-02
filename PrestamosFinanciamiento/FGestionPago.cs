using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;

namespace PrestamosFinanciamiento
{
    public partial class FGestionPago : Form
    {
        private CNCuentasCobrar objCuentaCobrar = new CNCuentasCobrar();
        private CNCliente objCliente = new CNCliente();
        private int idPrestamoActual = 0;
        private int idCuentaActual = 0;
        private int idClienteActual = 0;
        private string numeroPrestamo = string.Empty;

        public FGestionPago()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            ConfigurarControlesReadOnly();
            ConfigurarMetodosPago();
            AsignarEventos();
            LimpiarFormulario();
        }

        private void ConfigurarControlesReadOnly()
        {
            TBNombreCliente.ReadOnly = true;
            TBCedulaCliente.ReadOnly = true;
            TBTelefonoCliente.ReadOnly = true;
            TBDireccionCliente.ReadOnly = true;
            TBDeudaActual.ReadOnly = true;
            TBCuotas.ReadOnly = true;
            TBCuotasPendiente.ReadOnly = true;
            TBRestante.ReadOnly = true;
        }

        private void ConfigurarMetodosPago()
        {
            CBMetodoPago.Items.Clear();
            CBMetodoPago.Items.AddRange(new string[] {
                "Efectivo",
                "Transferencia",
                "Cheque",
                "Tarjeta"
            });
        }

        private void AsignarEventos()
        {
            BTBuscarCodPrestamo.Click += BTBuscarCodPrestamo_Click;
            BGuardar.Click += BGuardar_Click;
            BCacelar.Click += BCacelar_Click;
            BSalir.Click += BSalir_Click;
            TBPago.TextChanged += TBPago_TextChanged;
            TBCodPrestamo.KeyPress += TBCodPrestamo_KeyPress;
            TBPago.KeyPress += ValidarNumeroDecimal;
        }

        private void TBCodPrestamo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BTBuscarCodPrestamo_Click(sender, e);
                e.Handled = true;
            }
        }

        private void ValidarNumeroDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void BTBuscarCodPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TBCodPrestamo.Text))
                {
                    MessageBox.Show("Debe ingresar un código de préstamo.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBCodPrestamo.Focus();
                    return;
                }

                BuscarYCargarPrestamo(TBCodPrestamo.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar préstamo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarYCargarPrestamo(string codigoPrestamo)
        {
            DataTable dtPrestamo = CNPrestamos.ObtenerPrestamoPorNumero(codigoPrestamo);

            if (dtPrestamo == null || dtPrestamo.Rows.Count == 0)
            {
                DialogResult resultado = MessageBox.Show(
                    "No se encontró ningún préstamo con ese código.\n\n¿Desea buscar en la lista de préstamos?",
                    "Préstamo no encontrado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    AbrirVentanaSeleccionPrestamos();
                }
                else
                {
                    LimpiarDatosCliente();
                }
                return;
            }

            DataRow rowPrestamo = dtPrestamo.Rows[0];

            if (!ValidarColumnasPrestamo(dtPrestamo))
            {
                MessageBox.Show("Error: La estructura de datos del préstamo es incorrecta.",
                    "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            idPrestamoActual = ObtenerValorEntero(rowPrestamo, "id_prestamo");
            idClienteActual = ObtenerValorEntero(rowPrestamo, "idcliente");
            numeroPrestamo = ObtenerValorString(rowPrestamo, "numero_prestamo");

            string estadoPrestamo = ObtenerValorString(rowPrestamo, "estado");
            if (!ValidarEstadoPrestamo(estadoPrestamo))
            {
                LimpiarDatosCliente();
                return;
            }

            CargarDatosCliente(idClienteActual);
            CargarDatosPrestamo(rowPrestamo);
            BuscarCuentaPorCobrar(idPrestamoActual);

            TBPago.Focus();
        }

        private bool ValidarColumnasPrestamo(DataTable dt)
        {
            string[] columnasRequeridas = {
                "id_prestamo", "numero_prestamo", "idcliente", "estado",
                "monto_prestamo", "plazo_meses", "tasa_interes"
            };

            foreach (string columna in columnasRequeridas)
            {
                if (!dt.Columns.Contains(columna))
                {
                    MessageBox.Show($"Falta la columna requerida: {columna}",
                        "Error de Estructura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private bool ValidarEstadoPrestamo(string estadoPrestamo)
        {
            string estadoUpper = estadoPrestamo.ToUpper();

            if (estadoUpper == "CANCELADO" || estadoUpper == "RECHAZADO")
            {
                MessageBox.Show($"Este préstamo está en estado '{estadoPrestamo}' y no puede recibir pagos.",
                    "Estado Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (estadoUpper == "PAGADO" || estadoUpper == "COMPLETADO")
            {
                MessageBox.Show("Este préstamo ya ha sido pagado completamente.",
                    "Estado Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void AbrirVentanaSeleccionPrestamos()
        {
            try
            {
                using (MPrestamos formPrestamos = new MPrestamos())
                {
                    if (formPrestamos.ShowDialog() == DialogResult.OK)
                    {
                        TBCodPrestamo.Text = formPrestamos.PrestamoSeleccionado;
                        idPrestamoActual = formPrestamos.IdPrestamoSeleccionado;
                        numeroPrestamo = formPrestamos.PrestamoSeleccionado;

                        DataTable dtPrestamo = CNPrestamos.ObtenerPrestamosPorID(idPrestamoActual);
                        if (dtPrestamo != null && dtPrestamo.Rows.Count > 0)
                        {
                            DataRow rowPrestamo = dtPrestamo.Rows[0];
                            idClienteActual = ObtenerValorEntero(rowPrestamo, "idcliente");

                            CargarDatosCliente(idClienteActual);
                            CargarDatosPrestamo(rowPrestamo);
                            BuscarCuentaPorCobrar(idPrestamoActual);

                            TBPago.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir ventana de selección: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosCliente(int idCliente)
        {
            try
            {
                if (idCliente <= 0)
                {
                    MessageBox.Show("ID de cliente inválido.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dtCliente = objCliente.ObtenerClientePorId(idCliente);

                if (dtCliente != null && dtCliente.Rows.Count > 0)
                {
                    DataRow row = dtCliente.Rows[0];

                    string nombre = ObtenerValorString(row, "nombre");
                    string apellido = ObtenerValorString(row, "apellido");

                    TBNombreCliente.Text = $"{nombre} {apellido}".Trim();
                    TBCedulaCliente.Text = ObtenerValorString(row, "cedula");
                    TBTelefonoCliente.Text = ObtenerValorString(row, "telefono");
                    TBDireccionCliente.Text = ObtenerValorString(row, "direccion");
                }
                else
                {
                    MessageBox.Show("No se pudo cargar la información del cliente.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarDatosCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del cliente: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosPrestamo(DataRow rowPrestamo)
        {
            try
            {
                decimal montoPrestamo = ObtenerValorDecimal(rowPrestamo, "monto_prestamo");
                int plazoMeses = ObtenerValorEntero(rowPrestamo, "plazo_meses");
                decimal tasaInteres = ObtenerValorDecimal(rowPrestamo, "tasa_interes");
                decimal montoTotal = montoPrestamo + (montoPrestamo * tasaInteres / 100);
                decimal saldoPendiente;

                if (rowPrestamo.Table.Columns.Contains("saldo_pendiente") &&
                    rowPrestamo["saldo_pendiente"] != DBNull.Value)
                {
                    saldoPendiente = ObtenerValorDecimal(rowPrestamo, "saldo_pendiente");
                }
                else
                {
                    saldoPendiente = montoTotal;
                }

                decimal cuotaMensual = plazoMeses > 0 ? montoTotal / plazoMeses : 0;
                decimal montoPagado = montoTotal - saldoPendiente;
                int cuotasPagadas = cuotaMensual > 0 ? (int)Math.Floor(montoPagado / cuotaMensual) : 0;
                int cuotasPendientes = plazoMeses - cuotasPagadas;

                TBDeudaActual.Text = "$" + saldoPendiente.ToString("N2");
                TBCuotas.Text = "$" + cuotaMensual.ToString("N2");
                TBCuotasPendiente.Text = cuotasPendientes.ToString();
                TBRestante.Text = "$" + saldoPendiente.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del préstamo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarCuentaPorCobrar(int idPrestamo)
        {
            try
            {
                if (idPrestamo <= 0) return;

                DataTable dtCuenta = objCuentaCobrar.ObtenerCuentasPorPrestamo(idPrestamo);

                if (dtCuenta != null && dtCuenta.Rows.Count > 0)
                {
                    foreach (DataRow row in dtCuenta.Rows)
                    {
                        bool activo = ObtenerValorBooleano(row, "activo");
                        decimal saldo = ObtenerValorDecimal(row, "saldo_pendiente");

                        if (activo && saldo > 0)
                        {
                            idCuentaActual = ObtenerValorEntero(row, "id_cuenta");
                            TBDeudaActual.Text = "$" + saldo.ToString("N2");
                            TBRestante.Text = "$" + saldo.ToString("N2");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Advertencia al buscar cuenta por cobrar: {ex.Message}");
            }
        }

        private void TBPago_TextChanged(object sender, EventArgs e)
        {
            CalcularRestante();
        }

        private void CalcularRestante()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TBDeudaActual.Text))
                {
                    TBRestante.Text = "$0.00";
                    TBRestante.BackColor = Color.White;
                    return;
                }

                if (string.IsNullOrWhiteSpace(TBPago.Text))
                {
                    TBRestante.Text = TBDeudaActual.Text;
                    TBRestante.BackColor = Color.White;
                    return;
                }

                string deudaTexto = TBDeudaActual.Text.Replace("$", "").Replace(",", "");
                string pagoTexto = TBPago.Text.Replace("$", "").Replace(",", "");

                if (decimal.TryParse(deudaTexto, out decimal deudaActual) &&
                    decimal.TryParse(pagoTexto, out decimal montoPago))
                {
                    decimal restante = deudaActual - montoPago;
                    TBRestante.Text = "$" + (restante >= 0 ? restante.ToString("N2") : "0.00");

                    if (restante < 0)
                    {
                        TBRestante.BackColor = Color.LightCoral;
                    }
                    else if (restante == 0)
                    {
                        TBRestante.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        TBRestante.BackColor = Color.LightYellow;
                    }
                }
                else
                {
                    TBRestante.Text = TBDeudaActual.Text;
                    TBRestante.BackColor = Color.White;
                }
            }
            catch
            {
                TBRestante.Text = "$0.00";
                TBRestante.BackColor = Color.White;
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos())
                    return;

                decimal montoPago = Convert.ToDecimal(TBPago.Text.Replace("$", "").Replace(",", ""));
                decimal deudaActual = Convert.ToDecimal(TBDeudaActual.Text.Replace("$", "").Replace(",", ""));

                if (montoPago > deudaActual)
                {
                    if (MessageBox.Show($"El monto del pago (${montoPago:N2}) es mayor a la deuda actual (${deudaActual:N2}).\n\n" +
                        "¿Desea registrar el pago por el monto de la deuda?",
                        "Monto Mayor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        montoPago = deudaActual;
                        TBPago.Text = montoPago.ToString("N2");
                    }
                    else
                    {
                        TBPago.Focus();
                        return;
                    }
                }

                if (!ConfirmarPago(montoPago))
                    return;

                RegistrarPago(montoPago, deudaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el pago:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ConfirmarPago(decimal montoPago)
        {
            string mensaje = $"¿Está seguro de registrar este pago?\n\n" +
                            $"Préstamo: {TBCodPrestamo.Text}\n" +
                            $"Cliente: {TBNombreCliente.Text}\n" +
                            $"Monto a pagar: ${montoPago:N2}\n" +
                            $"Método: {CBMetodoPago.Text}";

            return MessageBox.Show(mensaje, "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void RegistrarPago(decimal montoPago, decimal deudaActual)
        {
            string resultado = CNPagos.Insertar(
                idPrestamoActual,
                idClienteActual,
                montoPago,
                DateTime.Now,
                CBMetodoPago.Text,
                string.IsNullOrWhiteSpace(TBComentario.Text) ? "Pago registrado" : TBComentario.Text,
                true
            );

            if (!resultado.ToLower().Contains("correctamente") &&
                !resultado.ToLower().Contains("exitosamente") &&
                !string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show($"Error al registrar el pago:\n{resultado}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (idCuentaActual > 0)
            {
                string resultadoCuenta = objCuentaCobrar.RegistrarAbonoCuenta(idCuentaActual, montoPago);
                if (!string.IsNullOrEmpty(resultadoCuenta) &&
                    !resultadoCuenta.ToLower().Contains("correctamente"))
                {
                    Console.WriteLine($"Advertencia al actualizar cuenta: {resultadoCuenta}");
                }
            }

            ActualizarPrestamo(montoPago, deudaActual);
        }

        private void ActualizarPrestamo(decimal montoPago, decimal deudaActual)
        {
            try
            {
                decimal nuevoSaldo = deudaActual - montoPago;

                DataTable dtPrestamo = CNPrestamos.ObtenerPrestamosPorID(idPrestamoActual);
                if (dtPrestamo != null && dtPrestamo.Rows.Count > 0)
                {
                    DataRow row = dtPrestamo.Rows[0];

                    string estadoActual = ObtenerValorString(row, "estado");
                    string nuevoEstado = nuevoSaldo == 0 ? "Pagado" : estadoActual;

                    string resultadoActualizacion = CNPrestamos.Actualizar(
                        idPrestamoActual,
                        ObtenerValorString(row, "numero_prestamo"),
                        ObtenerValorEntero(row, "idcliente"),
                        ObtenerValorDecimal(row, "monto_prestamo"),
                        ObtenerValorDecimal(row, "tasa_interes"),
                        ObtenerValorEntero(row, "plazo_meses"),
                        ObtenerValorFecha(row, "fecha_prestamo"),
                        ObtenerValorFecha(row, "fecha_vencimiento"),
                        nuevoEstado,
                        nuevoSaldo,
                        ObtenerValorBooleano(row, "activo")
                    );

                    MostrarMensajeExito(montoPago, nuevoSaldo);

                    LimpiarFormulario();
                    TBCodPrestamo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el préstamo:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarMensajeExito(decimal montoPago, decimal nuevoSaldo)
        {
            string mensajeExito = "¡Pago registrado exitosamente!\n\n" +
                                 $"Monto pagado: ${montoPago:N2}\n" +
                                 $"Saldo restante: ${nuevoSaldo:N2}";

            if (nuevoSaldo == 0)
            {
                mensajeExito += "\n\n¡El préstamo ha sido pagado completamente!";
            }

            MessageBox.Show(mensajeExito, "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidarDatos()
        {
            if (idPrestamoActual == 0)
            {
                MessageBox.Show("Debe buscar un préstamo válido primero.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBCodPrestamo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBPago.Text))
            {
                MessageBox.Show("Debe ingresar el monto del pago.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBPago.Focus();
                return false;
            }

            string pagoTexto = TBPago.Text.Replace("$", "").Replace(",", "");
            if (!decimal.TryParse(pagoTexto, out decimal montoPago) || montoPago <= 0)
            {
                MessageBox.Show("El monto del pago debe ser un valor numérico mayor a cero.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBPago.Select(0, TBPago.Text.Length);
                TBPago.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(CBMetodoPago.Text))
            {
                MessageBox.Show("Debe seleccionar un método de pago.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBMetodoPago.Focus();
                return false;
            }

            string deudaTexto = TBDeudaActual.Text.Replace("$", "").Replace(",", "");
            if (string.IsNullOrWhiteSpace(deudaTexto) ||
                !decimal.TryParse(deudaTexto, out decimal deuda) ||
                deuda <= 0)
            {
                MessageBox.Show("No hay deuda pendiente para este préstamo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private int ObtenerValorEntero(DataRow row, string columna)
        {
            if (row == null || !row.Table.Columns.Contains(columna) || row[columna] == DBNull.Value)
                return 0;

            return Convert.ToInt32(row[columna]);
        }

        private string ObtenerValorString(DataRow row, string columna)
        {
            if (row == null || !row.Table.Columns.Contains(columna) || row[columna] == DBNull.Value)
                return string.Empty;

            return row[columna].ToString().Trim();
        }

        private decimal ObtenerValorDecimal(DataRow row, string columna)
        {
            if (row == null || !row.Table.Columns.Contains(columna) || row[columna] == DBNull.Value)
                return 0m;

            return Convert.ToDecimal(row[columna]);
        }

        private bool ObtenerValorBooleano(DataRow row, string columna)
        {
            if (row == null || !row.Table.Columns.Contains(columna) || row[columna] == DBNull.Value)
                return false;

            return Convert.ToBoolean(row[columna]);
        }

        private DateTime ObtenerValorFecha(DataRow row, string columna)
        {
            if (row == null || !row.Table.Columns.Contains(columna) || row[columna] == DBNull.Value)
                return DateTime.Now;

            return Convert.ToDateTime(row[columna]);
        }

        private void BCacelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBCodPrestamo.Text) &&
                string.IsNullOrWhiteSpace(TBPago.Text))
            {
                LimpiarFormulario();
                return;
            }

            if (MessageBox.Show("¿Está seguro de cancelar? Se perderán los datos ingresados.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarFormulario();
                TBCodPrestamo.Focus();
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de salir del módulo de gestión de pagos?",
                "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LimpiarFormulario()
        {
            TBCodPrestamo.Clear();
            LimpiarDatosCliente();
            TBPago.Clear();
            TBRestante.Clear();
            TBComentario.Clear();
            CBMetodoPago.SelectedIndex = -1;

            idPrestamoActual = 0;
            idCuentaActual = 0;
            idClienteActual = 0;
            numeroPrestamo = string.Empty;

            TBRestante.BackColor = Color.White;
            TBPago.BackColor = Color.White;
        }

        private void LimpiarDatosCliente()
        {
            TBNombreCliente.Clear();
            TBCedulaCliente.Clear();
            TBTelefonoCliente.Clear();
            TBDireccionCliente.Clear();
            TBDeudaActual.Clear();
            TBCuotas.Clear();
            TBCuotasPendiente.Clear();
            TBRestante.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}