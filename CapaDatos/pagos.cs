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
    public class CDPagos
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

        public CDPagos()
        {
        }

        public CDPagos(int pIdPago, string pNumeroRecibo, int pIdPrestamo, int pIdCliente,
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

        public string Insertar(CDPagos objPago)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;

                SqlCommand micomando = new SqlCommand("Pagos-Insertar", sqlCon);
                sqlCon.Open();

                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pnumero_recibo", objPago.NumeroRecibo);
                micomando.Parameters.AddWithValue("@pid_prestamo", objPago.IdPrestamo);
                micomando.Parameters.AddWithValue("@pidcliente", objPago.IdCliente);
                micomando.Parameters.AddWithValue("@pfecha_pago", objPago.FechaPago);
                micomando.Parameters.AddWithValue("@pmonto_pago", objPago.MontoPago);
                micomando.Parameters.AddWithValue("@pmetodo_pago", objPago.MetodoPago);
                micomando.Parameters.AddWithValue("@pobservaciones", objPago.Observaciones);
                micomando.Parameters.AddWithValue("@pactivo", objPago.Activo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Pago registrado correctamente!"
                    : "No se pudo registrar el pago!";
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

        public string Actualizar(CDPagos objPago)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("Pagos-Actualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_pago", objPago.IdPago);
                micomando.Parameters.AddWithValue("@pnumero_recibo", objPago.NumeroRecibo);
                micomando.Parameters.AddWithValue("@pid_prestamo", objPago.IdPrestamo);
                micomando.Parameters.AddWithValue("@pidcliente", objPago.IdCliente);
                micomando.Parameters.AddWithValue("@pfecha_pago", objPago.FechaPago);
                micomando.Parameters.AddWithValue("@pmonto_pago", objPago.MontoPago);
                micomando.Parameters.AddWithValue("@pmetodo_pago", objPago.MetodoPago);
                micomando.Parameters.AddWithValue("@pobservaciones", objPago.Observaciones);
                micomando.Parameters.AddWithValue("@pactivo", objPago.Activo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Pago actualizado correctamente!"
                    : "No se pudo actualizar el pago!";
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

        public DataTable PagosConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Pagos-Seleccionar";
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

        public string Eliminar(int idPago)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("Pagos-Eliminar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_pago", idPago);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Pago eliminado correctamente!"
                    : "No se pudo eliminar el pago!";
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

        public DataTable ObtenerPorId(int idPago)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Pagos-SeleccionarPorID";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_pago", idPago);

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

        public DataTable ObtenerPorPrestamo(int idPrestamo)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Pagos-SeleccionarPorPrestamo";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_prestamo", idPrestamo);

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

        public DataTable ObtenerPorCliente(int idCliente)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Pagos-SeleccionarPorCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pidcliente", idCliente);

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

        public DataTable ObtenerPorNumeroRecibo(string numeroRecibo)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Pagos-BuscarPorRecibo";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pnumero_recibo", numeroRecibo);

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

        public DataTable ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Pagos-SeleccionarPorFecha";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pfecha_inicio", fechaInicio);
                sqlCmd.Parameters.AddWithValue("@pfecha_fin", fechaFin);

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

        public DataTable ObtenerPorMetodoPago(string metodoPago)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Pagos-SeleccionarPorMetodo";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pmetodo_pago", metodoPago);

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