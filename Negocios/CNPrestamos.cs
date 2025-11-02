using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using CapaDatos;

namespace Negocios
{
    public class CNPrestamos
    {
        public static string Insertar(
            string pNumeroPrestamo,
            int pIdCliente,
            decimal pMontoPrestamo,
            decimal pTasaInteres,
            int pPlazoMeses,
            DateTime pFechaPrestamo,
            DateTime pFechaVencimiento,
            string pEstado,
            decimal pSaldoPendiente,
            bool pActivo)
        {
            prestamos objPrestamo = new prestamos();

            objPrestamo.NumeroPrestamo = pNumeroPrestamo;
            objPrestamo.IdCliente = pIdCliente;
            objPrestamo.MontoPrestamo = pMontoPrestamo;
            objPrestamo.TasaInteres = pTasaInteres;
            objPrestamo.PlazoMeses = pPlazoMeses;
            objPrestamo.FechaPrestamo = pFechaPrestamo;
            objPrestamo.FechaVencimiento = pFechaVencimiento;
            objPrestamo.Estado = pEstado;
            objPrestamo.SaldoPendiente = pSaldoPendiente;
            objPrestamo.Activo = pActivo;


            return objPrestamo.Insertar(objPrestamo);
        }
        public static string Actualaizar(
            int pIdPrestamo,    
            string pNumeroPrestamo,
            int pIdCliente,
            decimal pMontoPrestamo,
            decimal pTasaInteres,
            int pPlazoMeses,
            DateTime pFechaPrestamo,
            DateTime pFechaVencimiento,
            string pEstado,
            decimal pSaldoPendiente,
            bool pActivo)
        {
            prestamos objPrestamo = new prestamos();

            objPrestamo.IdPrestamo = pIdPrestamo; 
            objPrestamo.NumeroPrestamo = pNumeroPrestamo;
            objPrestamo.IdCliente = pIdCliente;
            objPrestamo.MontoPrestamo = pMontoPrestamo;
            objPrestamo.TasaInteres = pTasaInteres;
            objPrestamo.PlazoMeses = pPlazoMeses;
            objPrestamo.FechaPrestamo = pFechaPrestamo;
            objPrestamo.FechaVencimiento = pFechaVencimiento;
            objPrestamo.Estado = pEstado;
            objPrestamo.SaldoPendiente = pSaldoPendiente;
            objPrestamo.Activo = pActivo;

            return objPrestamo.Actualizar(objPrestamo);


        }

        public DataTable ObtenerPrestamo(string miparametro)
        {
            prestamos objPrestamo = new prestamos();
            DataTable dt = new DataTable();
            dt = objPrestamo.PrestamoConsultar(miparametro);

            return dt;
        }
        public DataTable ObtenerTodosPrestamos()
        {
            prestamos objPrestamo = new prestamos();
            DataTable dt = new DataTable();
            dt = objPrestamo.PrestamoConsultar("");
            return dt;
        }
        public DataTable ObtenerPrestamosPorCliente(int idCliente)
        {
            prestamos objPrestamo = new prestamos();
            DataTable dt = new DataTable();

            dt = objPrestamo.PrestamoConsultar(idCliente.ToString());

            return dt;
        }
    }
}


