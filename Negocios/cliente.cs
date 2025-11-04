using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace Negocios
{
    public class CNCliente
    {
        private int nIdCliente;
        private string nNombre;
        private string nApellido;
        private decimal nCedula;
        private string nDireccion;
        private decimal nTelefono;
        private string nEmail;
        private bool nActivo;
        private DateTime nFechaRegistro;
        private DateTime nFechaModificacion;
        private string nMensajeError;
        private string nValor;

        public CNCliente()
        {
        }

        public CNCliente(int pIdCliente, string pNombre, string pApellido,
                         decimal pCedula, string pDireccion, decimal pTelefono,
                         string pEmail, bool pActivo, DateTime pFechaRegistro,
                         DateTime pFechaModificacion, string pMensajeError, string pValor)
        {
            nIdCliente = pIdCliente;
            nNombre = pNombre;
            nApellido = pApellido;
            nCedula = pCedula;
            nDireccion = pDireccion;
            nTelefono = pTelefono;
            nEmail = pEmail;
            nActivo = pActivo;
            nFechaRegistro = pFechaRegistro;
            nFechaModificacion = pFechaModificacion;
            nMensajeError = pMensajeError;
            nValor = pValor;
        }

        public int IdCliente
        {
            get { return nIdCliente; }
            set { nIdCliente = value; }
        }

        public string Nombre
        {
            get { return nNombre; }
            set { nNombre = value; }
        }

        public string Apellido
        {
            get { return nApellido; }
            set { nApellido = value; }
        }

        public decimal Cedula
        {
            get { return nCedula; }
            set { nCedula = value; }
        }

        public string Direccion
        {
            get { return nDireccion; }
            set { nDireccion = value; }
        }

        public decimal Telefono
        {
            get { return nTelefono; }
            set { nTelefono = value; }
        }

        public string Email
        {
            get { return nEmail; }
            set { nEmail = value; }
        }

        public bool Activo
        {
            get { return nActivo; }
            set { nActivo = value; }
        }

        public DateTime FechaRegistro
        {
            get { return nFechaRegistro; }
            set { nFechaRegistro = value; }
        }

        public DateTime FechaModificacion
        {
            get { return nFechaModificacion; }
            set { nFechaModificacion = value; }
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

        public string InsertarCliente(CNCliente objCliente)
        {
            CDCliente miCliente = new CDCliente();

            miCliente.Nombre = objCliente.Nombre;
            miCliente.Apellido = objCliente.Apellido;
            miCliente.Cedula = objCliente.Cedula;
            miCliente.Direccion = objCliente.Direccion;
            miCliente.Telefono = objCliente.Telefono;
            miCliente.Email = objCliente.Email;
            miCliente.Activo = objCliente.Activo;

            nMensajeError = miCliente.Insertar(miCliente);
            return nMensajeError;
        }

        public string ActualizarCliente(CNCliente objCliente)
        {
            CDCliente miCliente = new CDCliente();

            miCliente.IdCliente = objCliente.IdCliente;
            miCliente.Nombre = objCliente.Nombre;
            miCliente.Apellido = objCliente.Apellido;
            miCliente.Cedula = objCliente.Cedula;
            miCliente.Direccion = objCliente.Direccion;
            miCliente.Telefono = objCliente.Telefono;
            miCliente.Email = objCliente.Email;
            miCliente.Activo = objCliente.Activo;

            nMensajeError = miCliente.Actualizar(miCliente);
            return nMensajeError;
        }

        public DataTable ConsultarCliente(string parametro)
        {
            DataTable dt = new DataTable();
            CDCliente miCliente = new CDCliente();

            dt = miCliente.ClienteConsultar(parametro);
            return dt;
        }

        public string EliminarCliente(int idCliente)
        {
            CDCliente miCliente = new CDCliente();
            nMensajeError = miCliente.Eliminar(idCliente);
            return nMensajeError;
        }

        public DataTable ObtenerClientePorId(int idCliente)
        {
            DataTable dt = new DataTable();
            CDCliente miCliente = new CDCliente();

            dt = miCliente.ObtenerPorId(idCliente);
            return dt;
        }

        public DataTable BuscarClientePorCedula(string cedula)
        {
            DataTable dt = new DataTable();
            CDCliente miCliente = new CDCliente();

            dt = miCliente.BuscarPorCedula(cedula);
            return dt;
        }

        public bool ValidarDatosCliente(CNCliente objCliente)
        {
            if (string.IsNullOrWhiteSpace(objCliente.Nombre))
            {
                nMensajeError = "El nombre es obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(objCliente.Apellido))
            {
                nMensajeError = "El apellido es obligatorio.";
                return false;
            }

            if (objCliente.Cedula <= 0)
            {
                nMensajeError = "La cédula es obligatoria.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(objCliente.Direccion))
            {
                nMensajeError = "La dirección es obligatoria.";
                return false;
            }

            if (objCliente.Telefono <= 0)
            {
                nMensajeError = "El teléfono es obligatorio.";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(objCliente.Email))
            {
                if (!ValidarFormatoEmail(objCliente.Email))
                {
                    nMensajeError = "El formato del email no es válido.";
                    return false;
                }
            }

            return true;
        }

        private bool ValidarFormatoEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidarCedulaUnica(decimal cedula)
        {
            CDCliente miCliente = new CDCliente();
            DataTable dt = miCliente.BuscarPorCedula(cedula.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                nMensajeError = "Ya existe un cliente registrado con esta cédula.";
                return false;
            }

            return true;
        }

        public bool ValidarCedulaUnicaActualizar(decimal cedula, int idCliente)
        {
            CDCliente miCliente = new CDCliente();
            DataTable dt = miCliente.BuscarPorCedula(cedula.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                int idEncontrado = Convert.ToInt32(dt.Rows[0]["IdCliente"]);
                if (idEncontrado != idCliente)
                {
                    nMensajeError = "Ya existe otro cliente registrado con esta cédula.";
                    return false;
                }
            }

            return true;
        }

        public int ObtenerTotalClientes()
        {
            DataTable dt = ConsultarCliente("");
            return dt != null ? dt.Rows.Count : 0;
        }

        public int ObtenerClientesActivos()
        {
            DataTable dt = ConsultarCliente("");
            if (dt == null) return 0;

            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToBoolean(row["activo"]))
                    count++;
            }
            return count;
        }

        public int ObtenerClientesInactivos()
        {
            DataTable dt = ConsultarCliente("");
            if (dt == null) return 0;

            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (!Convert.ToBoolean(row["activo"]))
                    count++;
            }
            return count;
        }
    }
}