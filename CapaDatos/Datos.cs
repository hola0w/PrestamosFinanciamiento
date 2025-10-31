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
    public class ConexionDB
    {
        public static String ConexionMY = @"Data Source = (LocalDB)\MSSQLLocalDB;
             AttachDbFilename=C:\PrestamosFinanciamiento\PrestamosFinanciamiento\DBPrestamos.mdf;
                Integrated Security = True";

        public SqlConnection dbConexion = new SqlConnection(ConexionMY);
    }

    public class prestamos
    {
        #region Propiedades privadas
        private int dIdPrestamo;
        private string dNumeroPrestamo;
        private int dIdCliente;
        private decimal dMontoPrestamo;
        private decimal dTasaInteres;
        private int dPlazoMeses;
        private DateTime dFechaPrestamo;
        private DateTime dFechaVencimiento;
        private string dEstado;
        private decimal dSaldoPendiente;
        private bool dActivo;
        private DateTime dFechaActualizacion;

        public prestamos()
        {
        }

        public prestamos(int pIdPrestamo, string pNumeroPrestamo, int pIdCliente,
                              decimal pMontoPrestamo, decimal pTasaInteres, int pPlazoMeses,
                              DateTime pFechaPrestamo, DateTime pFechaVencimiento, string pEstado,
                              decimal pSaldoPendiente, bool pActivo, DateTime pFechaActualizacion)
        {
            dIdPrestamo = pIdPrestamo;
            dNumeroPrestamo = pNumeroPrestamo;
            dIdCliente = pIdCliente;
            dMontoPrestamo = pMontoPrestamo;
            dTasaInteres = pTasaInteres;
            dPlazoMeses = pPlazoMeses;
            dFechaPrestamo = pFechaPrestamo;
            dFechaVencimiento = pFechaVencimiento;
            dEstado = pEstado;
            dSaldoPendiente = pSaldoPendiente;
            dActivo = pActivo;
            dFechaActualizacion = pFechaActualizacion;
        }

        public int IdPrestamo
        {
            get { return dIdPrestamo; }
            set { dIdPrestamo = value; }
        }

        public string NumeroPrestamo
        {
            get { return dNumeroPrestamo; }
            set { dNumeroPrestamo = value; }
        }

        public int IdCliente
        {
            get { return dIdCliente; }
            set { dIdCliente = value; }
        }

        public decimal MontoPrestamo
        {
            get { return dMontoPrestamo; }
            set { dMontoPrestamo = value; }
        }

        public decimal TasaInteres
        {
            get { return dTasaInteres; }
            set { dTasaInteres = value; }
        }

        public int PlazoMeses
        {
            get { return dPlazoMeses; }
            set { dPlazoMeses = value; }
        }

        public DateTime FechaPrestamo
        {
            get { return dFechaPrestamo; }
            set { dFechaPrestamo = value; }
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

        public decimal SaldoPendiente
        {
            get { return dSaldoPendiente; }
            set { dSaldoPendiente = value; }
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

        public string Insertar(prestamos objPrestamo)  
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;

                SqlCommand micomando = new SqlCommand("PrestamoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pNumeroPrestamo", objPrestamo.NumeroPrestamo);
                micomando.Parameters.AddWithValue("@pIdCliente", objPrestamo.IdCliente);
                micomando.Parameters.AddWithValue("@pMontoPrestamo", objPrestamo.MontoPrestamo);
                micomando.Parameters.AddWithValue("@pTasaInteres", objPrestamo.TasaInteres);
                micomando.Parameters.AddWithValue("@pPlazoMeses", objPrestamo.PlazoMeses);
                micomando.Parameters.AddWithValue("@pFechaPrestamo", objPrestamo.FechaPrestamo);
                micomando.Parameters.AddWithValue("@pFechaVencimiento", objPrestamo.FechaVencimiento);
                micomando.Parameters.AddWithValue("@pEstado", objPrestamo.Estado);
                micomando.Parameters.AddWithValue("@pSaldoPendiente", objPrestamo.SaldoPendiente);
                micomando.Parameters.AddWithValue("@pActivo", objPrestamo.Activo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Préstamo insertado correctamente!"
                    : "No se pudo insertar el préstamo!";
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

        public string Actualizar(prestamos objPrestamo)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("PrestamoActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdPrestamo", objPrestamo.IdPrestamo);
                micomando.Parameters.AddWithValue("@pNumeroPrestamo", objPrestamo.NumeroPrestamo);
                micomando.Parameters.AddWithValue("@pIdCliente", objPrestamo.IdCliente);
                micomando.Parameters.AddWithValue("@pMontoPrestamo", objPrestamo.MontoPrestamo);
                micomando.Parameters.AddWithValue("@pTasaInteres", objPrestamo.TasaInteres);
                micomando.Parameters.AddWithValue("@pPlazoMeses", objPrestamo.PlazoMeses);
                micomando.Parameters.AddWithValue("@pFechaPrestamo", objPrestamo.FechaPrestamo);
                micomando.Parameters.AddWithValue("@pFechaVencimiento", objPrestamo.FechaVencimiento);
                micomando.Parameters.AddWithValue("@pEstado", objPrestamo.Estado);
                micomando.Parameters.AddWithValue("@pSaldoPendiente", objPrestamo.SaldoPendiente);
                micomando.Parameters.AddWithValue("@pActivo", objPrestamo.Activo);

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

        public DataTable PrestamoConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "PrestamoConsultar";
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
        #endregion

    } 
}