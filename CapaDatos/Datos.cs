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

    public class prestamos
    {
        private int dId_Prestamo;
        private string dNumero_Prestamo;
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

        public prestamos(int pId_Prestamo,
                         string pNumero_Prestamo,
                         int pIdCliente,
                         decimal pMontoPrestamo,
                         decimal pTasaInteres,
                         int pPlazoMeses,
                         DateTime pFechaPrestamo,
                         DateTime pFechaVencimiento,
                         string pEstado,     
                         decimal pSaldoPendiente,
                         bool pActivo,
                         DateTime pFechaActualizacion)
        {
            dId_Prestamo = pId_Prestamo;
            dNumero_Prestamo = pNumero_Prestamo;
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

        public int Id_Prestamo
        {
            get { return dId_Prestamo; }
            set { dId_Prestamo = value; }
        }

        public string Numero_Prestamo
        {
            get { return dNumero_Prestamo; }
            set { dNumero_Prestamo = value; }
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

                SqlCommand micomando = new SqlCommand("Prestamo-Insertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pNumeroPrestamo", objPrestamo.Numero_Prestamo);
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
                SqlCommand micomando = new SqlCommand("Prestamo-Actualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdPrestamo", objPrestamo.Id_Prestamo);
                micomando.Parameters.AddWithValue("@pNumeroPrestamo", objPrestamo.Numero_Prestamo);
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
                sqlCmd.CommandText = "Prestamo-Seleccionar";
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
        public string Eliminar(int idPrestamo)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.ConexionMY;
                SqlCommand micomando = new SqlCommand("Prestamo-Eliminar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdPrestamo", idPrestamo);

                mensaje = micomando.ExecuteNonQuery() == 1
                    ? "Préstamo eliminado correctamente!"
                    : "No se pudo eliminar el préstamo!";
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

        public DataTable ObtenerPorCliente(int idCliente)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Prestamo-SeleccionarPorCliente";
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

        public DataTable ObtenerPorId(int idPrestamo)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbConexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Prestamo-SeleccionarPorID";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pIdPrestamo", idPrestamo);

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
