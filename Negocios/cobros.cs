using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace Negocios
{
    public class CNCuentasCobrar
    {
        private int nIdCuenta;
        private string nNumeroCuenta;
        private int nIdCliente;
        private int nIdPrestamo;
        private string nConcepto;
        private decimal nMontoTotal;
        private decimal nSaldoPendiente;
        private DateTime nFechaEmision;
        private DateTime nFechaVencimiento;
        private string nEstado;
        private bool nActivo;
        private DateTime nFechaActualizacion;
        private string nMensajeError;
        private string nValor;

        public CNCuentasCobrar()
        {
        }

        public CNCuentasCobrar(int pIdCuenta, string pNumeroCuenta, int pIdCliente, int pIdPrestamo,
                               string pConcepto, decimal pMontoTotal, decimal pSaldoPendiente,
                               DateTime pFechaEmision, DateTime pFechaVencimiento, string pEstado,
                               bool pActivo, DateTime pFechaActualizacion, string pMensajeError, string pValor)
        {
            nIdCuenta = pIdCuenta;
            nNumeroCuenta = pNumeroCuenta;
            nIdCliente = pIdCliente;
            nIdPrestamo = pIdPrestamo;
            nConcepto = pConcepto;
            nMontoTotal = pMontoTotal;
            nSaldoPendiente = pSaldoPendiente;
            nFechaEmision = pFechaEmision;
            nFechaVencimiento = pFechaVencimiento;
            nEstado = pEstado;
            nActivo = pActivo;
            nFechaActualizacion = pFechaActualizacion;
            nMensajeError = pMensajeError;
            nValor = pValor;
        }

        public int IdCuenta
        {
            get { return nIdCuenta; }
            set { nIdCuenta = value; }
        }

        public string NumeroCuenta
        {
            get { return nNumeroCuenta; }
            set { nNumeroCuenta = value; }
        }

        public int IdCliente
        {
            get { return nIdCliente; }
            set { nIdCliente = value; }
        }

        public int IdPrestamo
        {
            get { return nIdPrestamo; }
            set { nIdPrestamo = value; }
        }

        public string Concepto
        {
            get { return nConcepto; }
            set { nConcepto = value; }
        }

        public decimal MontoTotal
        {
            get { return nMontoTotal; }
            set { nMontoTotal = value; }
        }

        public decimal SaldoPendiente
        {
            get { return nSaldoPendiente; }
            set { nSaldoPendiente = value; }
        }

        public DateTime FechaEmision
        {
            get { return nFechaEmision; }
            set { nFechaEmision = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return nFechaVencimiento; }
            set { nFechaVencimiento = value; }
        }

        public string Estado
        {
            get { return nEstado; }
            set { nEstado = value; }
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

        public string InsertarCuenta(CNCuentasCobrar objCuenta)
        {
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            miCuenta.NumeroCuenta = objCuenta.NumeroCuenta;
            miCuenta.IdCliente = objCuenta.IdCliente;
            miCuenta.IdPrestamo = objCuenta.IdPrestamo;
            miCuenta.Concepto = objCuenta.Concepto;
            miCuenta.MontoTotal = objCuenta.MontoTotal;
            miCuenta.SaldoPendiente = objCuenta.SaldoPendiente;
            miCuenta.FechaEmision = objCuenta.FechaEmision;
            miCuenta.FechaVencimiento = objCuenta.FechaVencimiento;
            miCuenta.Estado = objCuenta.Estado;
            miCuenta.Activo = objCuenta.Activo;

            nMensajeError = miCuenta.Insertar(miCuenta);
            return nMensajeError;
        }

        public string ActualizarCuenta(CNCuentasCobrar objCuenta)
        {
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            miCuenta.IdCuenta = objCuenta.IdCuenta;
            miCuenta.NumeroCuenta = objCuenta.NumeroCuenta;
            miCuenta.IdCliente = objCuenta.IdCliente;
            miCuenta.IdPrestamo = objCuenta.IdPrestamo;
            miCuenta.Concepto = objCuenta.Concepto;
            miCuenta.MontoTotal = objCuenta.MontoTotal;
            miCuenta.SaldoPendiente = objCuenta.SaldoPendiente;
            miCuenta.FechaEmision = objCuenta.FechaEmision;
            miCuenta.FechaVencimiento = objCuenta.FechaVencimiento;
            miCuenta.Estado = objCuenta.Estado;
            miCuenta.Activo = objCuenta.Activo;

            nMensajeError = miCuenta.Actualizar(miCuenta);
            return nMensajeError;
        }

        public DataTable ConsultarCuenta(string parametro)
        {
            DataTable dt = new DataTable();
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            dt = miCuenta.CuentasCobrarConsultar(parametro);
            return dt;
        }

        public string EliminarCuenta(int idCuenta)
        {
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();
            nMensajeError = miCuenta.Eliminar(idCuenta);
            return nMensajeError;
        }

        public DataTable ObtenerCuentaPorId(int idCuenta)
        {
            DataTable dt = new DataTable();
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            dt = miCuenta.ObtenerPorId(idCuenta);
            return dt;
        }

        public DataTable ObtenerCuentasPorCliente(int idCliente)
        {
            DataTable dt = new DataTable();
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            dt = miCuenta.ObtenerPorCliente(idCliente);
            return dt;
        }

        public DataTable ObtenerCuentasPorPrestamo(int idPrestamo)
        {
            DataTable dt = new DataTable();
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            dt = miCuenta.ObtenerPorPrestamo(idPrestamo);
            return dt;
        }

        public DataTable BuscarPorNumeroCuenta(string numeroCuenta)
        {
            DataTable dt = new DataTable();
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            dt = miCuenta.ObtenerPorNumeroCuenta(numeroCuenta);
            return dt;
        }

        public DataTable ObtenerCuentasPorEstado(string estado)
        {
            DataTable dt = new DataTable();
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            dt = miCuenta.ObtenerPorEstado(estado);
            return dt;
        }

        public DataTable ObtenerCuentasVencidas()
        {
            DataTable dt = new DataTable();
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            dt = miCuenta.ObtenerVencidas();
            return dt;
        }

        public DataTable ObtenerCuentasProximasVencer(int dias)
        {
            DataTable dt = new DataTable();
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();

            dt = miCuenta.ObtenerProximasVencer(dias);
            return dt;
        }

        public string ActualizarSaldoCuenta(int idCuenta, decimal nuevoSaldo)
        {
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();
            nMensajeError = miCuenta.ActualizarSaldo(idCuenta, nuevoSaldo);
            return nMensajeError;
        }

        public string ActualizarEstadoCuenta(int idCuenta, string nuevoEstado)
        {
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();
            nMensajeError = miCuenta.ActualizarEstado(idCuenta, nuevoEstado);
            return nMensajeError;
        }

        public bool ValidarDatosCuenta(CNCuentasCobrar objCuenta)
        {
            if (string.IsNullOrWhiteSpace(objCuenta.NumeroCuenta))
            {
                nMensajeError = "El número de cuenta es obligatorio.";
                return false;
            }

            if (objCuenta.IdCliente <= 0)
            {
                nMensajeError = "Debe seleccionar un cliente válido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(objCuenta.Concepto))
            {
                nMensajeError = "El concepto es obligatorio.";
                return false;
            }

            if (objCuenta.MontoTotal <= 0)
            {
                nMensajeError = "El monto total debe ser mayor a cero.";
                return false;
            }

            if (objCuenta.SaldoPendiente < 0)
            {
                nMensajeError = "El saldo pendiente no puede ser negativo.";
                return false;
            }

            if (objCuenta.SaldoPendiente > objCuenta.MontoTotal)
            {
                nMensajeError = "El saldo pendiente no puede ser mayor al monto total.";
                return false;
            }

            if (objCuenta.FechaVencimiento < objCuenta.FechaEmision)
            {
                nMensajeError = "La fecha de vencimiento no puede ser anterior a la fecha de emisión.";
                return false;
            }

            return true;
        }

        public bool ValidarNumeroCuentaUnico(string numeroCuenta)
        {
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();
            DataTable dt = miCuenta.ObtenerPorNumeroCuenta(numeroCuenta);

            if (dt != null && dt.Rows.Count > 0)
            {
                nMensajeError = "Ya existe una cuenta registrada con este número.";
                return false;
            }

            return true;
        }

        public bool ValidarNumeroCuentaUnicoActualizar(string numeroCuenta, int idCuenta)
        {
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();
            DataTable dt = miCuenta.ObtenerPorNumeroCuenta(numeroCuenta);

            if (dt != null && dt.Rows.Count > 0)
            {
                int idEncontrado = Convert.ToInt32(dt.Rows[0]["id_cuenta"]);
                if (idEncontrado != idCuenta)
                {
                    nMensajeError = "Ya existe otra cuenta registrada con este número.";
                    return false;
                }
            }

            return true;
        }

        public string RegistrarAbonoCuenta(int idCuenta, decimal montoAbono)
        {
            CDCuentasCobrar miCuenta = new CDCuentasCobrar();
            DataTable dt = miCuenta.ObtenerPorId(idCuenta);

            if (dt == null || dt.Rows.Count == 0)
            {
                return "No se encontró la cuenta especificada.";
            }

            decimal saldoActual = Convert.ToDecimal(dt.Rows[0]["saldo_pendiente"]);

            if (montoAbono > saldoActual)
            {
                return $"El monto del abono ({montoAbono:C}) no puede ser mayor al saldo pendiente ({saldoActual:C}).";
            }

            decimal nuevoSaldo = saldoActual - montoAbono;
            string resultado = miCuenta.ActualizarSaldo(idCuenta, nuevoSaldo);

            if (resultado.Contains("correctamente") && nuevoSaldo == 0)
            {
                miCuenta.ActualizarEstado(idCuenta, "Pagado");
            }

            return resultado;
        }

        public decimal CalcularTotalPorCobrarCliente(int idCliente)
        {
            DataTable dt = ObtenerCuentasPorCliente(idCliente);
            decimal total = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToBoolean(row["activo"]))
                    {
                        total += Convert.ToDecimal(row["saldo_pendiente"]);
                    }
                }
            }

            return total;
        }

        public decimal CalcularTotalCuentasVencidas()
        {
            DataTable dt = ObtenerCuentasVencidas();
            decimal total = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToDecimal(row["saldo_pendiente"]);
                }
            }

            return total;
        }

        public int ContarCuentasVencidas()
        {
            DataTable dt = ObtenerCuentasVencidas();
            return dt != null ? dt.Rows.Count : 0;
        }

        public int ContarCuentasProximasVencer(int dias)
        {
            DataTable dt = ObtenerCuentasProximasVencer(dias);
            return dt != null ? dt.Rows.Count : 0;
        }

        public DataTable ObtenerResumenPorEstado()
        {
            DataTable dt = ConsultarCuenta("");
            DataTable dtResumen = new DataTable();

            dtResumen.Columns.Add("Estado", typeof(string));
            dtResumen.Columns.Add("CantidadCuentas", typeof(int));
            dtResumen.Columns.Add("TotalSaldo", typeof(decimal));

            if (dt != null && dt.Rows.Count > 0)
            {
                var grupos = dt.AsEnumerable()
                    .Where(row => Convert.ToBoolean(row["activo"]))
                    .GroupBy(row => row["estado"].ToString());

                foreach (var grupo in grupos)
                {
                    DataRow newRow = dtResumen.NewRow();
                    newRow["Estado"] = grupo.Key;
                    newRow["CantidadCuentas"] = grupo.Count();
                    newRow["TotalSaldo"] = grupo.Sum(row => Convert.ToDecimal(row["saldo_pendiente"]));
                    dtResumen.Rows.Add(newRow);
                }
            }

            return dtResumen;
        }

        public void ActualizarEstadosAutomaticamente()
        {
            DataTable dt = ConsultarCuenta("");

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (!Convert.ToBoolean(row["activo"])) continue;

                    int idCuenta = Convert.ToInt32(row["id_cuenta"]);
                    decimal saldoPendiente = Convert.ToDecimal(row["saldo_pendiente"]);
                    DateTime fechaVencimiento = Convert.ToDateTime(row["fecha_vencimiento"]);
                    string estadoActual = row["estado"].ToString();

                    string nuevoEstado = estadoActual;

                    if (saldoPendiente == 0)
                    {
                        nuevoEstado = "Pagado";
                    }
                    else if (fechaVencimiento < DateTime.Now)
                    {
                        nuevoEstado = "Vencido";
                    }
                    else if (fechaVencimiento <= DateTime.Now.AddDays(7))
                    {
                        nuevoEstado = "Por Vencer";
                    }
                    else
                    {
                        nuevoEstado = "Activo";
                    }

                    if (nuevoEstado != estadoActual)
                    {
                        ActualizarEstadoCuenta(idCuenta, nuevoEstado);
                    }
                }
            }
        }

        public string GenerarNumeroCuenta()
        {
            string prefijo = "CXC";
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            Random random = new Random();
            string numeroAleatorio = random.Next(1000, 9999).ToString();

            return $"{prefijo}-{fecha}-{numeroAleatorio}";
        }
    }
}
