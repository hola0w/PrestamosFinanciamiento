using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Usuarios
    {
        private int dId_Usuario;
        private string dUsername;
        private string dPassword;
        private string dNombre_Completo;
        private string dRol;
        private string dEstado;
        private bool dActivo;
        private DateTime dFechaActualizacion;

        public Usuarios()
        {
        }

        public Usuarios(int pId_Usuario,
                       string pUsername,
                       string pPassword,
                       string pNombre_Completo,
                       string pRol,
                       string pEstado,
                       bool pActivo,
                       DateTime pFechaActualizacion)
        {
            dId_Usuario = pId_Usuario;
            dUsername = pUsername;
            dPassword = pPassword;
            dNombre_Completo = pNombre_Completo;
            dRol = pRol;
            dEstado = pEstado;
            dActivo = pActivo;
            dFechaActualizacion = pFechaActualizacion;
        }

        public int Id_Usuario
        {
            get { return dId_Usuario; }
            set { dId_Usuario = value; }
        }

        public string Username
        {
            get { return dUsername; }
            set { dUsername = value; }
        }

        public string Password
        {
            get { return dPassword; }
            set { dPassword = value; }
        }

        public string Nombre_Completo
        {
            get { return dNombre_Completo; }
            set { dNombre_Completo = value; }
        }

        public string Rol
        {
            get { return dRol; }
            set { dRol = value; }
        }

        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        public bool Activo
        {
            get { return dActivo; }
            set { dActivo = value; }
        }

        public DateTime FechaActualizacion
        {
            get { return dFechaActualizacion; }
            set { dFechaActualizacion = value; }
        }

        public string Insertar(Usuarios objUsuario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("sp_CrearUsuario", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@username", objUsuario.Username);
                micomando.Parameters.AddWithValue("@password", objUsuario.Password);
                micomando.Parameters.AddWithValue("@nombre_completo", objUsuario.Nombre_Completo);
                micomando.Parameters.AddWithValue("@rol", objUsuario.Rol);
                micomando.Parameters.AddWithValue("@estado",
                    string.IsNullOrEmpty(objUsuario.Estado) ? "Activo" : objUsuario.Estado);
                micomando.Parameters.AddWithValue("@activo", objUsuario.Activo);

                SqlDataReader reader = micomando.ExecuteReader();
                if (reader.Read())
                {
                    mensaje = reader["mensaje"].ToString();
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public string Actualizar(Usuarios objUsuario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("sp_ActualizarUsuario", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@id_usuario", objUsuario.Id_Usuario);
                micomando.Parameters.AddWithValue("@username",
                    string.IsNullOrEmpty(objUsuario.Username) ? (object)DBNull.Value : objUsuario.Username);
                micomando.Parameters.AddWithValue("@nombre_completo",
                    string.IsNullOrEmpty(objUsuario.Nombre_Completo) ? (object)DBNull.Value : objUsuario.Nombre_Completo);
                micomando.Parameters.AddWithValue("@rol",
                    string.IsNullOrEmpty(objUsuario.Rol) ? (object)DBNull.Value : objUsuario.Rol);
                micomando.Parameters.AddWithValue("@estado",
                    string.IsNullOrEmpty(objUsuario.Estado) ? (object)DBNull.Value : objUsuario.Estado);
                micomando.Parameters.AddWithValue("@activo", objUsuario.Activo);

                SqlDataReader reader = micomando.ExecuteReader();
                if (reader.Read())
                {
                    mensaje = reader["mensaje"].ToString();
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public string CambiarPassword(int idUsuario, string passwordNuevo)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("sp_CambiarPassword", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@id_usuario", idUsuario);
                micomando.Parameters.AddWithValue("@password_hash", passwordNuevo);

                SqlDataReader reader = micomando.ExecuteReader();
                if (reader.Read())
                {
                    mensaje = reader["mensaje"].ToString();
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        // MÉTODO AJUSTADO PARA TU BASE DE DATOS (columnas en minúsculas)
        public DataTable ValidarCredenciales(string username, string password)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "sp_ValidarCredenciales";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@username", username);
                sqlCmd.Parameters.AddWithValue("@password", password);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable ObtenerPorId(int idUsuario)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "sp_ObtenerUsuarioPorId";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable ObtenerPorUsername(string username)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "sp_ObtenerUsuarioPorUsername";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@username", username);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable ListarUsuarios(string rol = null, string estado = null, bool? activo = null)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "sp_ListarUsuarios";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@rol",
                    string.IsNullOrEmpty(rol) ? (object)DBNull.Value : rol);
                sqlCmd.Parameters.AddWithValue("@estado",
                    string.IsNullOrEmpty(estado) ? (object)DBNull.Value : estado);
                sqlCmd.Parameters.AddWithValue("@activo",
                    activo.HasValue ? (object)activo.Value : DBNull.Value);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }

        public string CambiarEstado(int idUsuario, bool activo)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("sp_CambiarEstadoUsuario", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@id_usuario", idUsuario);
                micomando.Parameters.AddWithValue("@activo", activo);

                SqlDataReader reader = micomando.ExecuteReader();
                if (reader.Read())
                {
                    mensaje = reader["mensaje"].ToString();
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public string Eliminar(int idUsuario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("sp_EliminarUsuario", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@id_usuario", idUsuario);

                SqlDataReader reader = micomando.ExecuteReader();
                if (reader.Read())
                {
                    mensaje = reader["mensaje"].ToString();
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public DataTable BuscarUsuarios(string criterio)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "sp_BuscarUsuarios";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@criterio", criterio);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable ContarUsuariosPorRol()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "sp_ContarUsuariosPorRol";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable VerificarUsername(string username)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "sp_VerificarUsername";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@username", username);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }
    }
}