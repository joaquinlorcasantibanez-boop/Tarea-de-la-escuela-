using Microsoft.Data.SqlClient;
using System.Data;

namespace TuProyecto
{
    public class Sesion
    {
        public string Validar_Datos(string correo, string contrasena)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_Validacion_datos", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                object resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    string cargo = resultado.ToString();

                    if (cargo == "Administrador")
                        return "Administrador";

                    return "Usuario";
                }

                return "NoExiste";
            }
        }
    }
}
