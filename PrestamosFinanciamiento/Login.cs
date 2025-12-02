using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace PrestamosFinanciamiento
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarControles();
        }

        private void ConfigurarEventos()
        {
            // Eventos de los botones
            BTIngresar.Click += BTIngresar_Click;
            BTCancelar.Click += BTCancelar_Click;

            // Eventos de teclado para los TextBox
            TBUsuario.KeyPress += TBUsuario_KeyPress;
            TBPass.KeyPress += TBPass_KeyPress;

            // Evento de carga del formulario
            this.Load += Login_Load;
        }

        private void ConfigurarControles()
        {
            // Configurar TextBox de contraseña
            TBPass.UseSystemPasswordChar = true;

            // Establecer el TabIndex
            TBUsuario.TabIndex = 0;
            TBPass.TabIndex = 1;
            BTIngresar.TabIndex = 2;
            BTCancelar.TabIndex = 3;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Enfocar el TextBox de usuario al cargar el formulario
            TBUsuario.Focus();
        }

        private void BTIngresar_Click(object sender, EventArgs e)
        {
            ValidarLogin();
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            // Confirmar antes de cerrar
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea salir de la aplicación?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void TBUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Presionar Enter para pasar al siguiente campo
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                TBPass.Focus();
            }
        }

        private void TBPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Presionar Enter para intentar login
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ValidarLogin();
            }
        }

        private void ValidarLogin()
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(TBUsuario.Text))
                {
                    MessageBox.Show(
                        "Por favor, ingrese su nombre de usuario",
                        "Campo Requerido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    TBUsuario.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(TBPass.Text))
                {
                    MessageBox.Show(
                        "Por favor, ingrese su contraseña",
                        "Campo Requerido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    TBPass.Focus();
                    return;
                }

                // Deshabilitar botón para evitar múltiples clicks
                BTIngresar.Enabled = false;
                BTIngresar.Text = "Validando...";
                this.Cursor = Cursors.WaitCursor;

                // Validar credenciales usando la capa de negocio
                DataTable dtUsuario = NUsuarios.ValidarCredenciales(
                    TBUsuario.Text.Trim(),
                    TBPass.Text
                );

                // Restaurar estado del botón
                BTIngresar.Enabled = true;
                BTIngresar.Text = "Ingresar";
                this.Cursor = Cursors.Default;

                if (dtUsuario != null && dtUsuario.Rows.Count > 0)
                {
                    DataRow usuario = dtUsuario.Rows[0];

                    // Verificar que el usuario esté activo
                    bool activo = Convert.ToBoolean(usuario["activo"]);
                    if (!activo)
                    {
                        MessageBox.Show(
                            "Su cuenta de usuario está desactivada. Contacte al administrador.",
                            "Usuario Inactivo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        LimpiarCampos();
                        return;
                    }

                    // Guardar información del usuario en una clase estática (sesión)
                    SesionUsuario.IdUsuario = Convert.ToInt32(usuario["id_usuario"]);
                    SesionUsuario.Username = usuario["username"].ToString();
                    SesionUsuario.NombreCompleto = usuario["nombre_completo"].ToString();
                    SesionUsuario.Rol = usuario["rol"].ToString();
                    SesionUsuario.FechaLogin = DateTime.Now;

                    // Mostrar mensaje de bienvenida
                    MessageBox.Show(
                        $"¡Bienvenido, {SesionUsuario.NombreCompleto}!",
                        "Acceso Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Hide();

                    Form1 formPrincipal = new Form1();
                    formPrincipal.FormClosed += FormPrincipal_FormClosed;
                    formPrincipal.Show();
                }
                else
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos. Por favor, intente nuevamente.",
                        "Error de Autenticación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    LimpiarCampos();
                    TBUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                BTIngresar.Enabled = true;
                BTIngresar.Text = "Ingresar";
                this.Cursor = Cursors.Default;

                MessageBox.Show(
                    "Error al validar las credenciales: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LimpiarCampos()
        {
            TBUsuario.Clear();
            TBPass.Clear();
            TBUsuario.Focus();
        }
    }

    public static class SesionUsuario
    {
        public static int IdUsuario { get; set; }
        public static string Username { get; set; }
        public static string NombreCompleto { get; set; }
        public static string Rol { get; set; }
        public static DateTime FechaLogin { get; set; }

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            Username = string.Empty;
            NombreCompleto = string.Empty;
            Rol = string.Empty;
            FechaLogin = DateTime.MinValue;
        }
    }
}