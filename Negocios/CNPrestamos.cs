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
            string pNumero_Prestamo,
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
            objPrestamo.Numero_Prestamo = pNumero_Prestamo;
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

        public static string Actualizar(
            int pId_Prestamo,
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
            objPrestamo.Id_Prestamo = pId_Prestamo;
            objPrestamo.Numero_Prestamo = pNumeroPrestamo;
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

        public static string Eliminar(int pIdPrestamo)
        {
            prestamos objPrestamo = new prestamos();
            return objPrestamo.Eliminar(pIdPrestamo);
        }

        public static DataTable ObtenerPrestamo(string miparametro)
        {
            prestamos objPrestamo = new prestamos();
            DataTable dt = new DataTable();
            dt = objPrestamo.PrestamoConsultar(miparametro);
            return dt;
        }

        public static DataTable ObtenerTodosPrestamos()
        {
            prestamos objPrestamo = new prestamos();
            DataTable dt = new DataTable();
            dt = objPrestamo.PrestamoConsultar("");
            return dt;
        }

        public static DataTable ObtenerPrestamosPorCliente(int idCliente)
        {
            prestamos objPrestamo = new prestamos();
            DataTable dt = new DataTable();
            dt = objPrestamo.ObtenerPorCliente(idCliente);
            return dt;
        }

        public static DataTable ObtenerPrestamosPorID(int idPrestamo)
        {
            prestamos objPrestamo = new prestamos();
            DataTable dt = new DataTable();
            dt = objPrestamo.ObtenerPorId(idPrestamo);
            return dt;
        }
    }
}
