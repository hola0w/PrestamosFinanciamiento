using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CapaDatos
{
    public class CDCliente
    {
        private int dIdCliente;
        private string dNombre;
        private string dApellido;
        private decimal dCedula;
        private string dDireccion;
        private decimal dTelefono;
        private string dEmail;
        private bool dActivo;
        private DateTime dFechaRegistro;
        private DateTime dFechaModificacion;

        public CDCliente()
        {
        }

        public CDCliente(int pIdCliente, string pNombre, string pApellido,
                         decimal pCedula, string pDireccion, decimal pTelefono,
                         string pEmail, bool pActivo, DateTime pFechaRegistro,
                         DateTime pFechaModificacion)
        {
            dIdCliente = pIdCliente;
            dNombre = pNombre;
            dApellido = pApellido;
            dCedula = pCedula;
            dDireccion = pDireccion;
            dTelefono = pTelefono;
            dEmail = pEmail;
            dActivo = pActivo;
            dFechaRegistro = pFechaRegistro;
            dFechaModificacion = pFechaModificacion;
        }
 
        public int IdCliente
        {
            get { return dIdCliente; }
            set { dIdCliente = value; }
        }

        public string Nombre
        {
            get { return dNombre; }
            set { dNombre = value; }
        }

        public string Apellido
        {
            get { return dApellido; }
            set { dApellido = value; }
        }

        public decimal Cedula
        {
            get { return dCedula; }
            set { dCedula = value; }
        }

        public string Direccion
        {
            get { return dDireccion; }
            set { dDireccion = value; }
        }

        public decimal Telefono
        {
            get { return dTelefono; }
            set { dTelefono = value; }
        }

        public string Email
        {
            get { return dEmail; }
            set { dEmail = value; }
        }

        public bool Activo
        {
            get { return dActivo; }
            set { dActivo = value; }
        }

        public DateTime FechaRegistro
        {
            get { return dFechaRegistro; }
            set { dFechaRegistro = value; }
        }

        public DateTime FechaModificacion
        {
            get { return dFechaModificacion; }
            set { dFechaModificacion = value; }
        }


        public string Insertar(CDCliente objCliente)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;

                SqlCommand micomando = new SqlCommand("Cliente-Insertar", sqlCon);
                sqlCon.Open();

                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
                micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
                micomando.Parameters.AddWithValue("@pCedula", objCliente.Cedula);
                micomando.Parameters.AddWithValue("@pdireccion", objCliente.Direccion);
                micomando.Parameters.AddWithValue("@ptelefono", objCliente.Telefono);
                micomando.Parameters.AddWithValue("@pemail", objCliente.Email);
                micomando.Parameters.AddWithValue("@pactivo", objCliente.Activo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Inserción de datos completada correctamente!"
                    : "No se pudo insertar correctamente los nuevos datos!";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public string Actualizar(CDCliente objCliente)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("Cliente-Actualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdCliente", objCliente.IdCliente);
                micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
                micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
                micomando.Parameters.AddWithValue("@pCedula", objCliente.Cedula);
                micomando.Parameters.AddWithValue("@pdireccion", objCliente.Direccion);
                micomando.Parameters.AddWithValue("@ptelefono", objCliente.Telefono);
                micomando.Parameters.AddWithValue("@pemail", objCliente.Email);
                micomando.Parameters.AddWithValue("@pactivo", objCliente.Activo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Datos actualizados correctamente!"
                    : "No se pudo actualizar correctamente los datos!";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public DataTable ClienteConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Cliente-Seleccionar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pvalor", miparametro);

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

        public string Eliminar(int idCliente)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("Cliente-Eliminar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdCliente", idCliente);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Cliente eliminado correctamente!"
                    : "No se pudo eliminar el cliente!";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public DataTable ObtenerPorId(int idCliente)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Cliente-SeleccionarPorID";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pIdCliente", idCliente);

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

        public DataTable BuscarPorCedula(string cedula)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Cliente-BuscarPorCedula";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pCedula", cedula);

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