using Microsoft.Data.SqlClient;
using System.Data;

namespace TuProyecto
{
    public class Casos
    {
        public static void ActualizarEstadoCaso()
        {
            Console.Write("Ingrese el registro del caso: ");
            int idCaso = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo estado : ");
            int estado = int.Parse(Console.ReadLine());

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(
                    "SP_ActualizarEstadoCaso", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCaso", idCaso);
                cmd.Parameters.AddWithValue("@Estado", estado);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Estado actualizado correctamente.");
            }
        }
    }
     
    
}