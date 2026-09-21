using Microsoft.Data.SqlClient;
using System.Data;

namespace TuProyecto
{
    public class Pantalla
    {
        public void BuscarTrabajador()
        {
            Console.Write("Ingrese el ID del trabajador: ");

            int idTrabajador = int.Parse(Console.ReadLine());

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                SqlCommand cmd =
                    new SqlCommand("SP_BuscarTrabajadorPorId", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdTrabajador",
                    idTrabajador);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Console.WriteLine("\n=== DATOS DEL TRABAJADOR ===");

                    Console.WriteLine(
                        $"Nombre: {dr["Nombre"]}");

                    Console.WriteLine(
                        $"Correo: {dr["Correo"]}");

                    Console.WriteLine(
                        $"Celular: {dr["Celular"]}");

                    Console.WriteLine(
                        $"Cargo: {dr["Cargo"]}");
                }
                else
                {
                    Console.WriteLine(
                        "No se encontró ningún trabajador con ese ID.");
                }
            }
        }
    }
}