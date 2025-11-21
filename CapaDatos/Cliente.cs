using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDCliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Cedula { get; set; }
        public string Direccion { get; set; }
        public decimal Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string ErrorDetalle { get; set; }

        public CDCliente() { }

        public CDCliente(int pIdCliente, string pNombre, string pApellido,
                         decimal pCedula, string pDireccion, decimal pTelefono,
                         string pEmail, bool pActivo, DateTime pFechaRegistro,
                         DateTime pFechaModificacion)
        {
            IdCliente = pIdCliente;
            Nombre = pNombre;
            Apellido = pApellido;
            Cedula = pCedula;
            Direccion = pDireccion;
            Telefono = pTelefono;
            Email = pEmail;
            Activo = pActivo;
            FechaRegistro = pFechaRegistro;
            FechaModificacion = pFechaModificacion;
        }

        public bool Insertar(CDCliente objCliente)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.ConexionMY))
            {
                try
                {
                    using (SqlCommand micomando = new SqlCommand("Cliente-Insertar", sqlCon))
                    {
                        sqlCon.Open();
                        micomando.CommandType = CommandType.StoredProcedure;

                        micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
                        micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
                        micomando.Parameters.AddWithValue("@pCedula", objCliente.Cedula);
                        micomando.Parameters.AddWithValue("@pdireccion", objCliente.Direccion);
                        micomando.Parameters.AddWithValue("@ptelefono", objCliente.Telefono);
                        micomando.Parameters.AddWithValue("@pemail", objCliente.Email ?? (object)DBNull.Value);
                        micomando.Parameters.AddWithValue("@pactivo", objCliente.Activo);

                        int filasAfectadas = micomando.ExecuteNonQuery();

                        System.Diagnostics.Debug.WriteLine($"Filas afectadas: {filasAfectadas}");

                        if (filasAfectadas > 0)
                        {
                            return true;
                        }
                        else
                        {
                            ErrorDetalle = "El procedimiento almacenado no insertó ningún registro. Verifique los datos y restricciones.";
                            return false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    ErrorDetalle = "Error de base de datos: " + ex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    ErrorDetalle = "Error inesperado: " + ex.Message;
                    return false;
                }
            }
        }

        public bool Actualizar(CDCliente objCliente)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.ConexionMY))
            {
                try
                {
                    using (SqlCommand micomando = new SqlCommand("Cliente-Actualizar", sqlCon))
                    {
                        sqlCon.Open();
                        micomando.CommandType = CommandType.StoredProcedure;

                        micomando.Parameters.AddWithValue("@pIdCliente", objCliente.IdCliente);
                        micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
                        micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
                        micomando.Parameters.AddWithValue("@pCedula", objCliente.Cedula);
                        micomando.Parameters.AddWithValue("@pdireccion", objCliente.Direccion);
                        micomando.Parameters.AddWithValue("@ptelefono", objCliente.Telefono);
                        micomando.Parameters.AddWithValue("@pemail", objCliente.Email ?? (object)DBNull.Value);
                        micomando.Parameters.AddWithValue("@pactivo", objCliente.Activo);

                        int filasAfectadas = micomando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (SqlException ex)
                {
                    ErrorDetalle = "Error de base de datos: " + ex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    ErrorDetalle = "Error inesperado: " + ex.Message;
                    return false;
                }
            }
        }

        public bool Eliminar(int idCliente)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.ConexionMY))
            {
                try
                {
                    using (SqlCommand micomando = new SqlCommand("Cliente-Eliminar", sqlCon))
                    {
                        sqlCon.Open();
                        micomando.CommandType = CommandType.StoredProcedure;
                        micomando.Parameters.AddWithValue("@pIdCliente", idCliente);

                        int filasAfectadas = micomando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (SqlException ex)
                {
                    ErrorDetalle = "Error de base de datos: " + ex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    ErrorDetalle = "Error inesperado: " + ex.Message;
                    return false;
                }
            }
        }

        public DataTable ClienteConsultar(string parametro)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.ConexionMY))
            {
                try
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Cliente-Buscar", sqlCon))
                    {
                        sqlCon.Open();
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pvalor", parametro ?? string.Empty);

                        using (SqlDataReader leerDatos = sqlCmd.ExecuteReader())
                        {
                            dt.Load(leerDatos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorDetalle = "Error al consultar clientes: " + ex.Message;
                    dt = null;
                }
            }

            return dt;
        }

        public DataTable ObtenerPorId(int idCliente)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.ConexionMY))
            {
                try
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Cliente-ObtenerPorID", sqlCon))
                    {
                        sqlCon.Open();
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pIdCliente", idCliente);

                        using (SqlDataReader leerDatos = sqlCmd.ExecuteReader())
                        {
                            dt.Load(leerDatos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorDetalle = "Error al obtener cliente: " + ex.Message;
                    dt = null;
                }
            }

            return dt;
        }

        public DataTable BuscarPorCedula(string cedula)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.ConexionMY))
            {
                try
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Cliente-ObtenerPorCedula", sqlCon))
                    {
                        sqlCon.Open();
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pCedula", cedula);

                        using (SqlDataReader leerDatos = sqlCmd.ExecuteReader())
                        {
                            dt.Load(leerDatos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorDetalle = "Error al buscar cliente por cédula: " + ex.Message;
                    dt = null;
                }
            }

            return dt;
        }

        public DataTable BuscarClienteUnificado(string criterio)
        {
            if (int.TryParse(criterio, out int id))
            {
                DataTable dtPorId = ObtenerPorId(id);
                if (dtPorId != null && dtPorId.Rows.Count > 0)
                {
                    return dtPorId;
                }
            }

            return BuscarPorCedula(criterio);
        }
    }
}