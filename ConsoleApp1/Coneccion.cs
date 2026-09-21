using Microsoft.Data.SqlClient;

namespace TuProyecto
{
    public class Conexion
    {
        private string cadena =
       @"Server=JOAQUIN1\SQLEXPRESS;
        Database=Tarea_aiep;
        Integrated Security=True;
        Encrypt=True;
        TrustServerCertificate=True;";

        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            return cn;
        }
    }
}