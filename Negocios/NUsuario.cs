using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NUsuarios
    {
        public static string Insertar(
            string username,
            string password,
            string nombreCompleto,
            string rol,
            string estado = "Activo")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    return "El nombre de usuario es requerido";

                if (string.IsNullOrWhiteSpace(password))
                    return "La contraseña es requerida";

                if (string.IsNullOrWhiteSpace(nombreCompleto))
                    return "El nombre completo es requerido";

                if (string.IsNullOrWhiteSpace(rol))
                    return "El rol es requerido";

                if (username.Length < 3 || username.Length > 50)
                    return "El nombre de usuario debe tener entre 3 y 50 caracteres";

                if (password.Length < 6)
                    return "La contraseña debe tener al menos 6 caracteres";

                Usuarios objUsuario = new Usuarios
                {
                    Username = username.Trim(),
                    Password = password, // Sin encriptar
                    Nombre_Completo = nombreCompleto.Trim(),
                    Rol = rol,
                    Estado = estado,
                    Activo = true
                };

                return new Usuarios().Insertar(objUsuario);
            }
            catch (Exception ex)
            {
                return "Error en capa de negocio: " + ex.Message;
            }
        }

        public static string Actualizar(int idUsuario, string username, string nombreCompleto,
                                       string rol, string estado, bool activo)
        {
            try
            {
                if (idUsuario <= 0)
                    return "ID de usuario inválido";

                Usuarios objUsuario = new Usuarios
                {
                    Id_Usuario = idUsuario,
                    Username = string.IsNullOrWhiteSpace(username) ? null : username.Trim(),
                    Nombre_Completo = string.IsNullOrWhiteSpace(nombreCompleto) ? null : nombreCompleto.Trim(),
                    Rol = string.IsNullOrWhiteSpace(rol) ? null : rol,
                    Estado = string.IsNullOrWhiteSpace(estado) ? null : estado,
                    Activo = activo
                };

                return new Usuarios().Actualizar(objUsuario);
            }
            catch (Exception ex)
            {
                return "Error en capa de negocio: " + ex.Message;
            }
        }

        public static string CambiarPassword(int idUsuario, string passwordActual, string passwordNuevo)
        {
            try
            {
                if (idUsuario <= 0)
                    return "ID de usuario inválido";

                if (string.IsNullOrWhiteSpace(passwordNuevo))
                    return "La nueva contraseña es requerida";

                if (passwordNuevo.Length < 6)
                    return "La nueva contraseña debe tener al menos 6 caracteres";

                if (!string.IsNullOrWhiteSpace(passwordActual))
                {
                    DataTable dtUsuario = new Usuarios().ObtenerPorId(idUsuario);
                    if (dtUsuario != null && dtUsuario.Rows.Count > 0)
                    {
                        // Aquí podrías validar la contraseña actual si lo necesitas
                    }
                }

                return new Usuarios().CambiarPassword(idUsuario, passwordNuevo);
            }
            catch (Exception ex)
            {
                return "Error en capa de negocio: " + ex.Message;
            }
        }

        // MÉTODO AJUSTADO: Sin encriptación de contraseña
        public static DataTable ValidarCredenciales(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    return null;

                // Se envía la contraseña sin encriptar
                return new Usuarios().ValidarCredenciales(username.Trim(), password);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataTable ObtenerPorId(int idUsuario)
        {
            try
            {
                if (idUsuario <= 0)
                    return null;

                return new Usuarios().ObtenerPorId(idUsuario);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataTable ObtenerPorUsername(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    return null;

                return new Usuarios().ObtenerPorUsername(username.Trim());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataTable ListarUsuarios(string rol = null, string estado = null, bool? activo = null)
        {
            try
            {
                return new Usuarios().ListarUsuarios(rol, estado, activo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string CambiarEstado(int idUsuario, bool activo)
        {
            try
            {
                if (idUsuario <= 0)
                    return "ID de usuario inválido";

                return new Usuarios().CambiarEstado(idUsuario, activo);
            }
            catch (Exception ex)
            {
                return "Error en capa de negocio: " + ex.Message;
            }
        }

        public static string Eliminar(int idUsuario)
        {
            try
            {
                if (idUsuario <= 0)
                    return "ID de usuario inválido";

                return new Usuarios().Eliminar(idUsuario);
            }
            catch (Exception ex)
            {
                return "Error en capa de negocio: " + ex.Message;
            }
        }

        public static DataTable BuscarUsuarios(string criterio)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(criterio))
                    return ListarUsuarios();

                return new Usuarios().BuscarUsuarios(criterio.Trim());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataTable ContarUsuariosPorRol()
        {
            try
            {
                return new Usuarios().ContarUsuariosPorRol();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool VerificarDisponibilidadUsername(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    return false;

                DataTable dt = new Usuarios().VerificarUsername(username.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    int disponible = Convert.ToInt32(dt.Rows[0]["disponible"]);
                    return disponible == 1;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static string GenerarUsername(string nombreCompleto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreCompleto))
                    return null;

                string[] partes = nombreCompleto.Trim().Split(' ');
                string username = "";

                if (partes.Length >= 2)
                {
                    username = partes[0].Substring(0, 1).ToLower() +
                               partes[partes.Length - 1].ToLower();
                }
                else
                {
                    username = nombreCompleto.ToLower().Replace(" ", "");
                }

                username = System.Text.RegularExpressions.Regex.Replace(username, @"[^a-zA-Z0-9]", "");

                return username;
            }
            catch
            {
                return null;
            }
        }
    }
}