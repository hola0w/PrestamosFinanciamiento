using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace Negocios
{
    public class CNPagos
    {
        private int nIdPago;
        private string nNumeroRecibo;
        private int nIdPrestamo;
        private int nIdCliente;
        private DateTime nFechaPago;
        private decimal nMontoPago;
        private string nMetodoPago;
        private string nObservaciones;
        private bool nActivo;
        private DateTime nFechaActualizacion;
        private string nMensajeError;

        public CNPagos()
        {
        }

        public CNPagos(int pIdPago, string pNumeroRecibo, int pIdPrestamo, int pIdCliente,
                      DateTime pFechaPago, decimal pMontoPago, string pMetodoPago,
                      string pObservaciones, bool pActivo, DateTime pFechaActualizacion)
        {
            nIdPago = pIdPago;
            nNumeroRecibo = pNumeroRecibo;
            nIdPrestamo = pIdPrestamo;
            nIdCliente = pIdCliente;
            nFechaPago = pFechaPago;
            nMontoPago = pMontoPago;
            nMetodoPago = pMetodoPago;
            nObservaciones = pObservaciones;
            nActivo = pActivo;
            nFechaActualizacion = pFechaActualizacion;
        }

        // Propiedades
        public int IdPago
        {
            get { return nIdPago; }
            set { nIdPago = value; }
        }

        public string NumeroRecibo
        {
            get { return nNumeroRecibo; }
            set { nNumeroRecibo = value; }
        }

        public int IdPrestamo
        {
            get { return nIdPrestamo; }
            set { nIdPrestamo = value; }
        }

        public int IdCliente
        {
            get { return nIdCliente; }
            set { nIdCliente = value; }
        }

        public DateTime FechaPago
        {
            get { return nFechaPago; }
            set { nFechaPago = value; }
        }

        public decimal MontoPago
        {
            get { return nMontoPago; }
            set { nMontoPago = value; }
        }

        public string MetodoPago
        {
            get { return nMetodoPago; }
            set { nMetodoPago = value; }
        }

        public string Observaciones
        {
            get { return nObservaciones; }
            set { nObservaciones = value; }
        }

        public bool Activo
        {
            get { return nActivo; }
            set { nActivo = value; }
        }

        public DateTime FechaActualizacion
        {
            get { return nFechaActualizacion; }
            set { nFechaActualizacion = value; }
        }

        public string MensajeError
        {
            get { return nMensajeError; }
            set { nMensajeError = value; }
        }

        public static string Insertar(
            int pIdPrestamo,
            int pIdCliente,
            decimal pMontoPago,
            DateTime pFechaPago,
            string pMetodoPago,
            string pObservaciones,
            bool pActivo)
        {
            Pagos objPago = new Pagos();
            
            objPago.NumeroRecibo = objPago.GenerarNumeroRecibo();
            objPago.IdPrestamo = pIdPrestamo;
            objPago.IdCliente = pIdCliente;
            objPago.FechaPago = pFechaPago;
            objPago.MontoPago = pMontoPago;
            objPago.MetodoPago = pMetodoPago;
            objPago.Observaciones = pObservaciones;
            objPago.Activo = pActivo;

            return objPago.Insertar(objPago);
        }

        public static string Actualizar(
            int pIdPago,
            string pNumeroRecibo,
            int pIdPrestamo,
            int pIdCliente,
            DateTime pFechaPago,
            decimal pMontoPago,
            string pMetodoPago,
            string pObservaciones,
            bool pActivo)
        {
            Pagos objPago = new Pagos();
            
            objPago.IdPago = pIdPago;
            objPago.NumeroRecibo = pNumeroRecibo;
            objPago.IdPrestamo = pIdPrestamo;
            objPago.IdCliente = pIdCliente;
            objPago.FechaPago = pFechaPago;
            objPago.MontoPago = pMontoPago;
            objPago.MetodoPago = pMetodoPago;
            objPago.Observaciones = pObservaciones;
            objPago.Activo = pActivo;

            return objPago.Actualizar(objPago);
        }

        public static string Eliminar(int pIdPago)
        {
            Pagos objPago = new Pagos();
            return objPago.Eliminar(pIdPago);
        }

        public static DataTable ObtenerPorId(int idPago)
        {
            Pagos objPago = new Pagos();
            return objPago.ObtenerPorId(idPago);
        }

        public static DataTable ObtenerPorCliente(int idCliente)
        {
            Pagos objPago = new Pagos();
            return objPago.ObtenerPorCliente(idCliente);
        }

        public static DataTable ObtenerPorPrestamo(int idPrestamo)
        {
            Pagos objPago = new Pagos();
            return objPago.ObtenerPorPrestamo(idPrestamo);
        }

        public static DataTable ConsultarPagos(string parametro)
        {
            Pagos objPago = new Pagos();
            return objPago.PagosConsultar(parametro);
        }

        public static DataTable ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            Pagos objPago = new Pagos();
            return objPago.ObtenerPorFecha(fechaInicio, fechaFin);
        }

        public static DataTable ObtenerResumenGeneral()
        {
            Pagos objPago = new Pagos();
            return objPago.ResumenGeneral();
        }

        public static decimal CalcularTotalPagosPorCliente(int idCliente)
        {
            DataTable dt = ObtenerPorCliente(idCliente);
            decimal total = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToBoolean(row["activo"]))
                    {
                        total += Convert.ToDecimal(row["monto_pago"]);
                    }
                }
            }

            return total;
        }

        public static decimal CalcularTotalPagosPorPrestamo(int idPrestamo)
        {
            DataTable dt = ObtenerPorPrestamo(idPrestamo);
            decimal total = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToBoolean(row["activo"]))
                    {
                        total += Convert.ToDecimal(row["monto_pago"]);
                    }
                }
            }

            return total;
        }

        public static int ContarPagosPorPrestamo(int idPrestamo)
        {
            DataTable dt = ObtenerPorPrestamo(idPrestamo);
            return dt != null ? dt.Rows.Count : 0;
        }

        public static DataRow ObtenerUltimoPago(int idPrestamo)
        {
            DataTable dt = ObtenerPorPrestamo(idPrestamo);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "fecha_pago DESC";
                return dv[0].Row;
            }

            return null;
        }
    }
}