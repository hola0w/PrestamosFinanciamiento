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
    public partial class FREGCLIENTE : Form
    {
        private CNCliente objCliente;
        private int idClienteSeleccionado = 0;
        private bool modoEdicion = false;

        public FREGCLIENTE()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            objCliente = new CNCliente();

            this.BNuevo.Click += new System.EventHandler(this.BNuevo_Click);
            this.BEditar.Click += new System.EventHandler(this.BEditar_Click);
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            this.BCacelar.Click += new System.EventHandler(this.BCacelar_Click);
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            this.TBCedCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            this.TBTelCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FREGCLIENTE_KeyDown);

            EstadoInicial();
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
            LimpiarCampos();
            idClienteSeleccionado = 0;
            modoEdicion = false;

            BNuevo.Enabled = false;
            BEditar.Enabled = false;
            BEliminar.Enabled = false;
            BGuardar.Enabled = true;
            BCacelar.Enabled = true;
            BBuscar.Enabled = false;
            textBox1.Enabled = false;

            TBNombreC.Focus();
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Debe buscar y seleccionar un cliente para editar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HabilitarControles(true);
            modoEdicion = true;

            BNuevo.Enabled = false;
            BEditar.Enabled = false;
            BEliminar.Enabled = false;
            BGuardar.Enabled = true;
            BCacelar.Enabled = true;
            BBuscar.Enabled = false;
            textBox1.Enabled = false;

            TBNombreC.Focus();
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idClienteSeleccionado == 0)
                {
                    MessageBox.Show("Debe buscar y seleccionar un cliente para eliminar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este cliente?\n\n" +
                    "Nombre: " + TBNombreC.Text + " " + TBApeClient.Text + "\n" +
                    "Cédula: " + TBCedCliente.Text,
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    string resultado = objCliente.EliminarCliente(idClienteSeleccionado);

                    if (string.IsNullOrEmpty(resultado))
                    {
                        MessageBox.Show("Cliente eliminado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EstadoInicial();
                    }
                    else
                    {
                        MessageBox.Show(resultado, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos del formulario
                if (!ValidarCampos())
                {
                    return;
                }

                // Crear objeto cliente con los datos del formulario
                CNCliente cliente = new CNCliente();
                cliente.Nombre = TBNombreC.Text.Trim();
                cliente.Apellido = TBApeClient.Text.Trim();
                cliente.Cedula = Convert.ToDecimal(TBCedCliente.Text.Trim());
                cliente.Telefono = Convert.ToDecimal(TBTelCliente.Text.Trim());
                cliente.Direccion = TBDirCliente.Text.Trim();
                cliente.Email = TBEmcliente.Text.Trim();
                cliente.Activo = true;

                // Validar datos del cliente en la capa de negocio
                if (!objCliente.ValidarDatosCliente(cliente))
                {
                    MessageBox.Show(objCliente.MensajeError, "Error de Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string resultado = string.Empty;

                // Modo edición
                if (modoEdicion)
                {
                    cliente.IdCliente = idClienteSeleccionado;

                    // Validar que la cédula no esté duplicada (excepto para el mismo cliente)
                    if (!objCliente.ValidarCedulaUnicaActualizar(cliente.Cedula, idClienteSeleccionado))
                    {
                        MessageBox.Show(objCliente.MensajeError, "Cédula Duplicada",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Actualizar cliente
                    resultado = objCliente.ActualizarCliente(cliente);

                    if (string.IsNullOrEmpty(resultado))
                    {
                        MessageBox.Show("Cliente actualizado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EstadoInicial();
                    }
                    else
                    {
                        MessageBox.Show(resultado, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Modo nuevo registro
                else
                {
                    // Validar que la cédula no esté duplicada
                    if (!objCliente.ValidarCedulaUnica(cliente.Cedula))
                    {
                        MessageBox.Show(objCliente.MensajeError, "Cédula Duplicada",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insertar nuevo cliente
                    resultado = objCliente.InsertarCliente(cliente);

                    if (string.IsNullOrEmpty(resultado))
                    {
                        MessageBox.Show("Cliente registrado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EstadoInicial();
                    }
                    else
                    {
                        MessageBox.Show(resultado, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en el formato de los datos. Verifique que la cédula y teléfono sean números válidos.",
                    "Error de Formato",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCacelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            BuscarCliente();
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

        private void BuscarCliente()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Debe ingresar un código o cédula para buscar.", "Campo Requerido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                string codigo = textBox1.Text.Trim();
                DataTable dt = null;

                int idBuscar;
                if (int.TryParse(codigo, out idBuscar))
                {
                    dt = objCliente.ObtenerClientePorId(idBuscar);
                }

                if (dt == null || dt.Rows.Count == 0)
                {
                    dt = objCliente.BuscarClientePorCedula(codigo);
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    CargarDatosCliente(row);

                    BNuevo.Enabled = true;
                    BEditar.Enabled = true;
                    BEliminar.Enabled = true;
                    BGuardar.Enabled = false;
                    BCacelar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún cliente con ese código o cédula.", "No Encontrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosCliente(DataRow row)
        {
            try
            {
                idClienteSeleccionado = Convert.ToInt32(row["IdCliente"]);
                TBNombreC.Text = row["nombre"].ToString();
                TBApeClient.Text = row["apellido"].ToString();
                TBCedCliente.Text = row["cedula"].ToString();
                TBTelCliente.Text = row["telefono"].ToString();
                TBDirCliente.Text = row["direccion"].ToString();
                TBEmcliente.Text = row["email"].ToString();

                HabilitarControles(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del cliente: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TBNombreC.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Campo Requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNombreC.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBApeClient.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Campo Requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBApeClient.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBCedCliente.Text))
            {
                MessageBox.Show("La cédula es obligatoria.", "Campo Requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBCedCliente.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBTelCliente.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.", "Campo Requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBTelCliente.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBDirCliente.Text))
            {
                MessageBox.Show("La dirección es obligatoria.", "Campo Requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDirCliente.Focus();
                return false;
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
            TBDirCliente.Clear();
            TBEmcliente.Clear();
            idClienteSeleccionado = 0;
        }

        private void EstadoInicial()
        {
            LimpiarCampos();
            HabilitarControles(false);
            modoEdicion = false;

            BNuevo.Enabled = true;
            BEditar.Enabled = false;
            BEliminar.Enabled = false;
            BGuardar.Enabled = false;
            BCacelar.Enabled = false;
            BBuscar.Enabled = true;
            textBox1.Enabled = true;

            textBox1.Focus();
        }

        private void HabilitarControles(bool habilitar)
        {
            TBNombreC.Enabled = habilitar;
            TBApeClient.Enabled = habilitar;
            TBCedCliente.Enabled = habilitar;
            TBTelCliente.Enabled = habilitar;
            TBDirCliente.Enabled = habilitar;
            TBEmcliente.Enabled = habilitar;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCliente();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void FREGCLIENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (BCacelar.Enabled)
                {
                    BCacelar_Click(sender, e);
                }
                else
                {
                    BSalir_Click(sender, e);
                }
            }
            else if (e.KeyCode == Keys.F2 && BNuevo.Enabled)
            {
                BNuevo_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3 && BEditar.Enabled)
            {
                BEditar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4 && BEliminar.Enabled)
            {
                BEliminar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5 && BGuardar.Enabled)
            {
                BGuardar_Click(sender, e);
            }
        }

        public void CargarClientePorId(int idCliente)
        {
            try
            {
                DataTable dt = objCliente.ObtenerClientePorId(idCliente);

                if (dt != null && dt.Rows.Count > 0)
                {
                    textBox1.Text = idCliente.ToString();
                    BuscarCliente();
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente especificado.", "No Encontrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cliente: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarClientePorCedula(string cedula)
        {
            try
            {
                textBox1.Text = cedula;
                BuscarCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cliente: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void BBuscar_Click_1(object sender, EventArgs e)
        {

        }

        private void BSalir_Click_1(object sender, EventArgs e)
        {

        }
    }
}