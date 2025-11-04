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
    public class CDCuentasCobrar
    {
        private int dIdCuenta;
        private string dNumeroCuenta;
        private int dIdCliente;
        private int dIdPrestamo;
        private string dConcepto;
        private decimal dMontoTotal;
        private decimal dSaldoPendiente;
        private DateTime dFechaEmision;
        private DateTime dFechaVencimiento;
        private string dEstado;
        private bool dActivo;
        private DateTime dFechaActualizacion;

        public CDCuentasCobrar()
        {
        }

        public CDCuentasCobrar(int pIdCuenta, string pNumeroCuenta, int pIdCliente, int pIdPrestamo,
                               string pConcepto, decimal pMontoTotal, decimal pSaldoPendiente,
                               DateTime pFechaEmision, DateTime pFechaVencimiento, string pEstado,
                               bool pActivo, DateTime pFechaActualizacion)
        {
            dIdCuenta = pIdCuenta;
            dNumeroCuenta = pNumeroCuenta;
            dIdCliente = pIdCliente;
            dIdPrestamo = pIdPrestamo;
            dConcepto = pConcepto;
            dMontoTotal = pMontoTotal;
            dSaldoPendiente = pSaldoPendiente;
            dFechaEmision = pFechaEmision;
            dFechaVencimiento = pFechaVencimiento;
            dEstado = pEstado;
            dActivo = pActivo;
            dFechaActualizacion = pFechaActualizacion;
        }

        public int IdCuenta
        {
            get { return dIdCuenta; }
            set { dIdCuenta = value; }
        }

        public string NumeroCuenta
        {
            get { return dNumeroCuenta; }
            set { dNumeroCuenta = value; }
        }

        public int IdCliente
        {
            get { return dIdCliente; }
            set { dIdCliente = value; }
        }

        public int IdPrestamo
        {
            get { return dIdPrestamo; }
            set { dIdPrestamo = value; }
        }

        public string Concepto
        {
            get { return dConcepto; }
            set { dConcepto = value; }
        }

        public decimal MontoTotal
        {
            get { return dMontoTotal; }
            set { dMontoTotal = value; }
        }

        public decimal SaldoPendiente
        {
            get { return dSaldoPendiente; }
            set { dSaldoPendiente = value; }
        }

        public DateTime FechaEmision
        {
            get { return dFechaEmision; }
            set { dFechaEmision = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return dFechaVencimiento; }
            set { dFechaVencimiento = value; }
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

        public string Insertar(CDCuentasCobrar objCuenta)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;

                SqlCommand micomando = new SqlCommand("CuentasCobrar-Insertar", sqlCon);
                sqlCon.Open();

                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pnumero_cuenta", objCuenta.NumeroCuenta);
                micomando.Parameters.AddWithValue("@pidcliente", objCuenta.IdCliente);
                micomando.Parameters.AddWithValue("@pid_prestamo", objCuenta.IdPrestamo);
                micomando.Parameters.AddWithValue("@pconcepto", objCuenta.Concepto);
                micomando.Parameters.AddWithValue("@pmonto_total", objCuenta.MontoTotal);
                micomando.Parameters.AddWithValue("@psaldo_pendiente", objCuenta.SaldoPendiente);
                micomando.Parameters.AddWithValue("@pfecha_emision", objCuenta.FechaEmision);
                micomando.Parameters.AddWithValue("@pfecha_vencimiento", objCuenta.FechaVencimiento);
                micomando.Parameters.AddWithValue("@pestado", objCuenta.Estado);
                micomando.Parameters.AddWithValue("@pactivo", objCuenta.Activo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Cuenta por cobrar registrada correctamente!"
                    : "No se pudo registrar la cuenta por cobrar!";
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

        public string Actualizar(CDCuentasCobrar objCuenta)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("CuentasCobrar-Actualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_cuenta", objCuenta.IdCuenta);
                micomando.Parameters.AddWithValue("@pnumero_cuenta", objCuenta.NumeroCuenta);
                micomando.Parameters.AddWithValue("@pidcliente", objCuenta.IdCliente);
                micomando.Parameters.AddWithValue("@pid_prestamo", objCuenta.IdPrestamo);
                micomando.Parameters.AddWithValue("@pconcepto", objCuenta.Concepto);
                micomando.Parameters.AddWithValue("@pmonto_total", objCuenta.MontoTotal);
                micomando.Parameters.AddWithValue("@psaldo_pendiente", objCuenta.SaldoPendiente);
                micomando.Parameters.AddWithValue("@pfecha_emision", objCuenta.FechaEmision);
                micomando.Parameters.AddWithValue("@pfecha_vencimiento", objCuenta.FechaVencimiento);
                micomando.Parameters.AddWithValue("@pestado", objCuenta.Estado);
                micomando.Parameters.AddWithValue("@pactivo", objCuenta.Activo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Cuenta por cobrar actualizada correctamente!"
                    : "No se pudo actualizar la cuenta por cobrar!";
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

        public DataTable CuentasCobrarConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "CuentasCobrar-Seleccionar";
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

        public string Eliminar(int idCuenta)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("CuentasCobrar-Eliminar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_cuenta", idCuenta);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Cuenta por cobrar eliminada correctamente!"
                    : "No se pudo eliminar la cuenta por cobrar!";
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

        public DataTable ObtenerPorId(int idCuenta)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "CuentasCobrar-SeleccionarPorID";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_cuenta", idCuenta);

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
                sqlCmd.CommandText = "CuentasCobrar-SeleccionarPorCliente";
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

        public DataTable ObtenerPorPrestamo(int idPrestamo)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "CuentasCobrar-SeleccionarPorPrestamo";
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

        public DataTable ObtenerPorNumeroCuenta(string numeroCuenta)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "CuentasCobrar-BuscarPorNumero";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pnumero_cuenta", numeroCuenta);

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

        public DataTable ObtenerPorEstado(string estado)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "CuentasCobrar-SeleccionarPorEstado";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pestado", estado);

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

        public DataTable ObtenerVencidas()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "CuentasCobrar-SeleccionarVencidas";
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

        public DataTable ObtenerProximasVencer(int dias)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "CuentasCobrar-ProximasVencer";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pdias", dias);

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

        public string ActualizarSaldo(int idCuenta, decimal nuevoSaldo)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("CuentasCobrar-ActualizarSaldo", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_cuenta", idCuenta);
                micomando.Parameters.AddWithValue("@pnuevo_saldo", nuevoSaldo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Saldo actualizado correctamente!"
                    : "No se pudo actualizar el saldo!";
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

        public string ActualizarEstado(int idCuenta, string nuevoEstado)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("CuentasCobrar-ActualizarEstado", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_cuenta", idCuenta);
                micomando.Parameters.AddWithValue("@pnuevo_estado", nuevoEstado);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Estado actualizado correctamente!"
                    : "No se pudo actualizar el estado!";
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
    }
}