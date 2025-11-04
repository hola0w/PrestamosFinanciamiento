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

}
