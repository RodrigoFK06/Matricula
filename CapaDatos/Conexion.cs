using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private readonly string cadenaConexion = "Data Source=TONY;Initial Catalog=MatriculasDB;Integrated Security=True;";


        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

    }
}
