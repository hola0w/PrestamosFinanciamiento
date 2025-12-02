using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace PrestamosFinanciamiento
{
    public partial class REmpleado : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public REmpleado()
        {
            InitializeComponent();
            this.Load += new EventHandler(REmpleado_Load);

            this.BNuevo.Click += new EventHandler(BNuevo_Click);
            this.BGuardar.Click += new EventHandler(BGuardar_Click);
            this.BEditar.Click += new EventHandler(BEditar_Click);
            this.BEliminar.Click += new EventHandler(BEliminar_Click);
            this.BCacelar.Click += new EventHandler(BCancelar_Click);
            this.BSalir.Click += new EventHandler(BSalir_Click);
            this.button1.Click += new EventHandler(BBuscar_Click);
            this.textBox2.Leave += new EventHandler(textBox2_Leave);

            ConfigurarControles();
        }

        private void REmpleado_Load(object sender, EventArgs e)
        {
            MostrarHabilitarControles(false);
            CargarRoles();
            LimpiarCampos();
        }

        private void ConfigurarControles()
        {
            textBox3.UseSystemPasswordChar = true;
            radioButton1.Checked = true;
            textBox4.Name = "txtIdUsuario";
            textBox1.Name = "txtNombreCompleto";
            textBox2.Name = "txtUsername";
            textBox3.Name = "txtPassword";
            comboBox1.Name = "cboRol";
            radioButton1.Name = "rbActivo";
            radioButton2.Name = "rbInactivo";
            button1.Name = "btnBuscar";
        }

        private void CargarRoles()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Usuario");
            comboBox1.SelectedIndex = 1; 
        }


        private void BNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            MostrarHabilitarControles(true);
            LimpiarCampos();
            textBox1.Focus();
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string mensaje = "";

            try
            {
                if (IsNuevo)
                {
                    mensaje = NUsuarios.Insertar(
                        textBox2.Text.Trim(),          
                        textBox3.Text,                   
                        textBox1.Text.Trim(),           
                        comboBox1.Text,                
                        radioButton1.Checked ? "Activo" : "Inactivo"  
                    );
                }
                else if (IsEditar)
                {
                    int idUsuario = Convert.ToInt32(textBox4.Text);
                    mensaje = NUsuarios.Actualizar(
                        idUsuario,
                        textBox2.Text.Trim(),        
                        textBox1.Text.Trim(),           
                        comboBox1.Text,                
                        radioButton1.Checked ? "Activo" : "Inactivo",  
                        radioButton1.Checked           
                    );
                }

                MessageBox.Show(mensaje, "Sistema",
                    MessageBoxButtons.OK,
                    mensaje.Contains("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);

                if (!mensaje.Contains("Error"))
                {
                    MostrarHabilitarControles(false);
                    LimpiarCampos();
                    IsNuevo = false;
                    IsEditar = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Debe buscar un usuario primero", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IsEditar = true;
            IsNuevo = false;
            MostrarHabilitarControles(true);
            textBox2.Enabled = false; 
            textBox3.Enabled = false; 
            textBox1.Focus();
        }


        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Debe buscar un usuario primero", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar este usuario?\n" +
                "Usuario: " + textBox2.Text + "\n" +
                "Nombre: " + textBox1.Text,
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int idUsuario = Convert.ToInt32(textBox4.Text);
                    string mensaje = NUsuarios.Eliminar(idUsuario);

                    MessageBox.Show(mensaje, "Sistema",
                        MessageBoxButtons.OK,
                        mensaje.Contains("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);

                    if (!mensaje.Contains("Error"))
                    {
                        LimpiarCampos();
                        MostrarHabilitarControles(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de cancelar la operación?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                LimpiarCampos();
                MostrarHabilitarControles(false);
                IsNuevo = false;
                IsEditar = false;
            }
        }


        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Ingrese un ID de usuario para buscar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            try
            {
                int idUsuario = Convert.ToInt32(textBox4.Text);
                DataTable dt = NUsuarios.ObtenerPorId(idUsuario);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    textBox1.Text = row["nombre_completo"].ToString();
                    textBox2.Text = row["username"].ToString();
                    textBox3.Text = "********"; 
                    comboBox1.Text = row["rol"].ToString();
                    bool activo = Convert.ToBoolean(row["activo"]);
                    radioButton1.Checked = activo;
                    radioButton2.Checked = !activo;
                    BEditar.Enabled = true;
                    BEliminar.Enabled = true;

                    MessageBox.Show("Usuario encontrado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El ID debe ser un número válido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de salir?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (IsNuevo && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                bool disponible = NUsuarios.VerificarDisponibilidadUsername(textBox2.Text.Trim());

                if (!disponible)
                {
                    MessageBox.Show("El nombre de usuario ya está en uso", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.BackColor = Color.LightCoral;
                    textBox2.Focus();
                }
                else
                {
                    textBox2.BackColor = Color.LightGreen;
                }
            }
        }

        private void MostrarHabilitarControles(bool estado)
        {
            textBox1.Enabled = estado;
            textBox2.Enabled = estado;
            textBox3.Enabled = estado;
            comboBox1.Enabled = estado;
            radioButton1.Enabled = estado;
            radioButton2.Enabled = estado;
            BNuevo.Enabled = !estado;
            BGuardar.Enabled = estado;
            BCacelar.Enabled = estado;
            BEditar.Enabled = !estado && !string.IsNullOrEmpty(textBox4.Text);
            BEliminar.Enabled = !estado && !string.IsNullOrEmpty(textBox4.Text);

            textBox4.Enabled = !estado;
            button1.Enabled = !estado;
        }

        private void LimpiarCampos()
        {
            textBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = 1;
            radioButton1.Checked = true;

            textBox2.BackColor = SystemColors.Window;

            BEditar.Enabled = false;
            BEliminar.Enabled = false;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El nombre completo es requerido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("El nombre de usuario es requerido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }

            if (textBox2.Text.Length < 3)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 3 caracteres",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }

            if (IsNuevo)
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("La contraseña es requerida", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return false;
                }

                if (textBox3.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar un rol", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return false;
            }

            return true;
        }
    }
}