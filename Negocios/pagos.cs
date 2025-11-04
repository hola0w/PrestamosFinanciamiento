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
        private string nValor;

        public CNPagos()
        {
        }

        public CNPagos(int pIdPago, string pNumeroRecibo, int pIdPrestamo, int pIdCliente,
                       DateTime pFechaPago, decimal pMontoPago, string pMetodoPago,
                       string pObservaciones, bool pActivo, DateTime pFechaActualizacion,
                       string pMensajeError, string pValor)
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
            nMensajeError = pMensajeError;
            nValor = pValor;
        }

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

        public string Valor
        {
            get { return nValor; }
            set { nValor = value; }
        }

        public string InsertarPago(CNPagos objPago)
        {
            CDPagos miPago = new CDPagos();

            miPago.NumeroRecibo = objPago.NumeroRecibo;
            miPago.IdPrestamo = objPago.IdPrestamo;
            miPago.IdCliente = objPago.IdCliente;
            miPago.FechaPago = objPago.FechaPago;
            miPago.MontoPago = objPago.MontoPago;
            miPago.MetodoPago = objPago.MetodoPago;
            miPago.Observaciones = objPago.Observaciones;
            miPago.Activo = objPago.Activo;

            nMensajeError = miPago.Insertar(miPago);
            return nMensajeError;
        }

        public string ActualizarPago(CNPagos objPago)
        {
            CDPagos miPago = new CDPagos();

            miPago.IdPago = objPago.IdPago;
            miPago.NumeroRecibo = objPago.NumeroRecibo;
            miPago.IdPrestamo = objPago.IdPrestamo;
            miPago.IdCliente = objPago.IdCliente;
            miPago.FechaPago = objPago.FechaPago;
            miPago.MontoPago = objPago.MontoPago;
            miPago.MetodoPago = objPago.MetodoPago;
            miPago.Observaciones = objPago.Observaciones;
            miPago.Activo = objPago.Activo;

            nMensajeError = miPago.Actualizar(miPago);
            return nMensajeError;
        }

        public DataTable ConsultarPago(string parametro)
        {
            DataTable dt = new DataTable();
            CDPagos miPago = new CDPagos();

            dt = miPago.PagosConsultar(parametro);
            return dt;
        }

        public string EliminarPago(int idPago)
        {
            CDPagos miPago = new CDPagos();
            nMensajeError = miPago.Eliminar(idPago);
            return nMensajeError;
        }

        public DataTable ObtenerPagoPorId(int idPago)
        {
            DataTable dt = new DataTable();
            CDPagos miPago = new CDPagos();

            dt = miPago.ObtenerPorId(idPago);
            return dt;
        }

        public DataTable ObtenerPagosPorPrestamo(int idPrestamo)
        {
            DataTable dt = new DataTable();
            CDPagos miPago = new CDPagos();

            dt = miPago.ObtenerPorPrestamo(idPrestamo);
            return dt;
        }

        public DataTable ObtenerPagosPorCliente(int idCliente)
        {
            DataTable dt = new DataTable();
            CDPagos miPago = new CDPagos();

            dt = miPago.ObtenerPorCliente(idCliente);
            return dt;
        }

        public DataTable BuscarPorNumeroRecibo(string numeroRecibo)
        {
            DataTable dt = new DataTable();
            CDPagos miPago = new CDPagos();

            dt = miPago.ObtenerPorNumeroRecibo(numeroRecibo);
            return dt;
        }

        public DataTable ObtenerPagosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            CDPagos miPago = new CDPagos();

            dt = miPago.ObtenerPorFecha(fechaInicio, fechaFin);
            return dt;
        }

        public DataTable ObtenerPagosPorMetodo(string metodoPago)
        {
            DataTable dt = new DataTable();
            CDPagos miPago = new CDPagos();

            dt = miPago.ObtenerPorMetodoPago(metodoPago);
            return dt;
        }

        public bool ValidarDatosPago(CNPagos objPago)
        {
            if (string.IsNullOrWhiteSpace(objPago.NumeroRecibo))
            {
                nMensajeError = "El número de recibo es obligatorio.";
                return false;
            }

            if (objPago.IdPrestamo <= 0)
            {
                nMensajeError = "Debe seleccionar un préstamo válido.";
                return false;
            }

            if (objPago.IdCliente <= 0)
            {
                nMensajeError = "Debe seleccionar un cliente válido.";
                return false;
            }

            if (objPago.MontoPago <= 0)
            {
                nMensajeError = "El monto del pago debe ser mayor a cero.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(objPago.MetodoPago))
            {
                nMensajeError = "El método de pago es obligatorio.";
                return false;
            }

            if (objPago.FechaPago > DateTime.Now)
            {
                nMensajeError = "La fecha del pago no puede ser futura.";
                return false;
            }

            return true;
        }

        public bool ValidarNumeroReciboUnico(string numeroRecibo)
        {
            CDPagos miPago = new CDPagos();
            DataTable dt = miPago.ObtenerPorNumeroRecibo(numeroRecibo);

            if (dt != null && dt.Rows.Count > 0)
            {
                nMensajeError = "Ya existe un pago registrado con este número de recibo.";
                return false;
            }

            return true;
        }

        public bool ValidarNumeroReciboUnicoActualizar(string numeroRecibo, int idPago)
        {
            CDPagos miPago = new CDPagos();
            DataTable dt = miPago.ObtenerPorNumeroRecibo(numeroRecibo);

            if (dt != null && dt.Rows.Count > 0)
            {
                int idEncontrado = Convert.ToInt32(dt.Rows[0]["id_pago"]);
                if (idEncontrado != idPago)
                {
                    nMensajeError = "Ya existe otro pago registrado con este número de recibo.";
                    return false;
                }
            }

            return true;
        }

        public bool ValidarMontoPagoContraPrestamo(int idPrestamo, decimal montoPago)
        {
            CDPagos miPago = new CDPagos();
            prestamos objPrestamo = new prestamos();

            DataTable dtPrestamo = objPrestamo.ObtenerPorId(idPrestamo);

            if (dtPrestamo == null || dtPrestamo.Rows.Count == 0)
            {
                nMensajeError = "No se encontró el préstamo especificado.";
                return false;
            }

            decimal saldoPendiente = Convert.ToDecimal(dtPrestamo.Rows[0]["SaldoPendiente"]);

            if (montoPago > saldoPendiente)
            {
                nMensajeError = $"El monto del pago ({montoPago:C}) no puede ser mayor al saldo pendiente ({saldoPendiente:C}).";
                return false;
            }

            return true;
        }

        public decimal CalcularTotalPagadoPorPrestamo(int idPrestamo)
        {
            DataTable dt = ObtenerPagosPorPrestamo(idPrestamo);
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

        public int ContarPagosPorPrestamo(int idPrestamo)
        {
            DataTable dt = ObtenerPagosPorPrestamo(idPrestamo);
            return dt != null ? dt.Rows.Count : 0;
        }

        public decimal CalcularTotalPagadoPorCliente(int idCliente)
        {
            DataTable dt = ObtenerPagosPorCliente(idCliente);
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

        public decimal CalcularTotalPagadoPorPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = ObtenerPagosPorFecha(fechaInicio, fechaFin);
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

        public DataTable ObtenerResumenPagosPorMetodo()
        {
            DataTable dt = ConsultarPago("");
            DataTable dtResumen = new DataTable();

            dtResumen.Columns.Add("MetodoPago", typeof(string));
            dtResumen.Columns.Add("CantidadPagos", typeof(int));
            dtResumen.Columns.Add("TotalMonto", typeof(decimal));

            if (dt != null && dt.Rows.Count > 0)
            {
                var grupos = dt.AsEnumerable()
                    .Where(row => Convert.ToBoolean(row["activo"]))
                    .GroupBy(row => row["metodo_pago"].ToString());

                foreach (var grupo in grupos)
                {
                    DataRow newRow = dtResumen.NewRow();
                    newRow["MetodoPago"] = grupo.Key;
                    newRow["CantidadPagos"] = grupo.Count();
                    newRow["TotalMonto"] = grupo.Sum(row => Convert.ToDecimal(row["monto_pago"]));
                    dtResumen.Rows.Add(newRow);
                }
            }

            return dtResumen;
        }

        public string GenerarNumeroRecibo()
        {
            string prefijo = "REC";
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            Random random = new Random();
            string numeroAleatorio = random.Next(1000, 9999).ToString();

            return $"{prefijo}-{fecha}-{numeroAleatorio}";
        }
    }
}