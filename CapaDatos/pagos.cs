using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Pagos
    {
        private int dIdPago;
        private string dNumeroRecibo;
        private int dIdPrestamo;
        private int dIdCliente;
        private DateTime dFechaPago;
        private decimal dMontoPago;
        private string dMetodoPago;
        private string dObservaciones;
        private bool dActivo;
        private DateTime dFechaActualizacion;

        public Pagos()
        {
        }

        public Pagos(int pIdPago, string pNumeroRecibo, int pIdPrestamo, int pIdCliente,
                     DateTime pFechaPago, decimal pMontoPago, string pMetodoPago,
                     string pObservaciones, bool pActivo, DateTime pFechaActualizacion)
        {
            dIdPago = pIdPago;
            dNumeroRecibo = pNumeroRecibo;
            dIdPrestamo = pIdPrestamo;
            dIdCliente = pIdCliente;
            dFechaPago = pFechaPago;
            dMontoPago = pMontoPago;
            dMetodoPago = pMetodoPago;
            dObservaciones = pObservaciones;
            dActivo = pActivo;
            dFechaActualizacion = pFechaActualizacion;
        }

        public int IdPago
        {
            get { return dIdPago; }
            set { dIdPago = value; }
        }

        public string NumeroRecibo
        {
            get { return dNumeroRecibo; }
            set { dNumeroRecibo = value; }
        }

        public int IdPrestamo
        {
            get { return dIdPrestamo; }
            set { dIdPrestamo = value; }
        }

        public int IdCliente
        {
            get { return dIdCliente; }
            set { dIdCliente = value; }
        }

        public DateTime FechaPago
        {
            get { return dFechaPago; }
            set { dFechaPago = value; }
        }

        public decimal MontoPago
        {
            get { return dMontoPago; }
            set { dMontoPago = value; }
        }

        public string MetodoPago
        {
            get { return dMetodoPago; }
            set { dMetodoPago = value; }
        }

        public string Observaciones
        {
            get { return dObservaciones; }
            set { dObservaciones = value; }
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

        public string MontoPagoFormateado
        {
            get { return "$" + dMontoPago.ToString("N2"); }
        }

        public string Insertar(Pagos objPago)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("PagosInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pnumero_recibo", objPago.NumeroRecibo);
                micomando.Parameters.AddWithValue("@pid_prestamo", objPago.IdPrestamo);
                micomando.Parameters.AddWithValue("@pidcliente", objPago.IdCliente);
                micomando.Parameters.AddWithValue("@pfecha_pago", objPago.FechaPago);
                micomando.Parameters.AddWithValue("@pmonto_pago", objPago.MontoPago);
                micomando.Parameters.AddWithValue("@pmetodo_pago", objPago.MetodoPago);
                micomando.Parameters.AddWithValue("@pobservaciones",
                    string.IsNullOrEmpty(objPago.Observaciones) ? (object)DBNull.Value : objPago.Observaciones);

                SqlParameter paramIdPago = new SqlParameter("@pid_pago", SqlDbType.Int);
                paramIdPago.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramIdPago);

                micomando.ExecuteNonQuery();

                if (paramIdPago.Value != DBNull.Value)
                {
                    objPago.IdPago = Convert.ToInt32(paramIdPago.Value);
                    mensaje = $"¡Pago registrado correctamente! ID: {objPago.IdPago} | Monto: ${objPago.MontoPago:N2}";
                }
                else
                {
                    mensaje = "No se pudo registrar el pago!";
                }
            }
            catch (SqlException ex)
            {
                mensaje = $"Error SQL: {ex.Message}";
            }
            catch (Exception ex)
            {
                mensaje = $"Error: {ex.Message}";
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public string Actualizar(Pagos objPago)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("Pagos_Actualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_pago", objPago.IdPago);
                micomando.Parameters.AddWithValue("@pnumero_recibo", objPago.NumeroRecibo);
                micomando.Parameters.AddWithValue("@pid_prestamo", objPago.IdPrestamo);
                micomando.Parameters.AddWithValue("@pidcliente", objPago.IdCliente);
                micomando.Parameters.AddWithValue("@pfecha_pago", objPago.FechaPago);
                micomando.Parameters.AddWithValue("@pmonto_pago", objPago.MontoPago);
                micomando.Parameters.AddWithValue("@pmetodo_pago", objPago.MetodoPago);
                micomando.Parameters.AddWithValue("@pobservaciones",
                    string.IsNullOrEmpty(objPago.Observaciones) ? (object)DBNull.Value : objPago.Observaciones);
                micomando.Parameters.AddWithValue("@pactivo", objPago.Activo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? $"¡Pago actualizado correctamente! Monto: ${objPago.MontoPago:N2}"
                    : "No se pudo actualizar el pago!";
            }
            catch (SqlException ex)
            {
                mensaje = $"Error SQL: {ex.Message}";
            }
            catch (Exception ex)
            {
                mensaje = $"Error: {ex.Message}";
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public DataTable PagosConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            SqlConnection sqlCon = null;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCon = sqlCmd.Connection;
                sqlCon.Open();
                sqlCmd.CommandText = "Pagos_Consultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pvalor", miparametro);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                leerDatos.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return dt;
        }

        public string Eliminar(int idPago)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("Pagos_Eliminar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_pago", idPago);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? $"¡Pago #{idPago} eliminado correctamente!"
                    : "No se pudo eliminar el pago!";
            }
            catch (SqlException ex)
            {
                mensaje = $"Error SQL: {ex.Message}";
            }
            catch (Exception ex)
            {
                mensaje = $"Error: {ex.Message}";
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public DataTable ObtenerPorId(int idPago)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            SqlConnection sqlCon = null;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCon = sqlCmd.Connection;
                sqlCon.Open();
                sqlCmd.CommandText = "Pagos_SeleccionarPorID";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_pago", idPago);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                leerDatos.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return dt;
        }

        public DataTable ObtenerPorCliente(int idCliente)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            SqlConnection sqlCon = null;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCon = sqlCmd.Connection;
                sqlCon.Open();
                sqlCmd.CommandText = "Pagos_PorCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pidcliente", idCliente);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                leerDatos.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return dt;
        }

        public DataTable ObtenerPorPrestamo(int idPrestamo)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            SqlConnection sqlCon = null;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCon = sqlCmd.Connection;
                sqlCon.Open();
                sqlCmd.CommandText = "Pagos_PorPrestamo";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_prestamo", idPrestamo);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                leerDatos.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return dt;
        }

        public DataTable ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            SqlConnection sqlCon = null;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCon = sqlCmd.Connection;
                sqlCon.Open();
                sqlCmd.CommandText = "Pagos_PorFecha";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pfecha_inicio", fechaInicio);
                sqlCmd.Parameters.AddWithValue("@pfecha_fin", fechaFin);

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                leerDatos.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return dt;
        }

        public DataTable ResumenGeneral()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            SqlConnection sqlCon = null;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCon = sqlCmd.Connection;
                sqlCon.Open();
                sqlCmd.CommandText = "Pagos_ResumenGeneral";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                leerDatos.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return dt;
        }

        public string GenerarNumeroRecibo()
        {
            string prefijo = "REC";
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            Random random = new Random();
            string numeroAleatorio = random.Next(1000, 9999).ToString();

            return $"{prefijo}-{fecha}-{numeroAleatorio}";
        }

        public static string FormatearMonto(decimal monto)
        {
            return "$" + monto.ToString("N2");
        }

        public static string CalcularTotalPagos(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return "$0.00";

            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["monto_pago"] != DBNull.Value)
                    total += Convert.ToDecimal(row["monto_pago"]);
            }

            return FormatearMonto(total);
        }
    }
}