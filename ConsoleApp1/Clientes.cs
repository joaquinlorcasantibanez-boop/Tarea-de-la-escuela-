using Microsoft.Data.SqlClient;
using System.Data;

namespace TuProyecto
{
    public class Clientes
    {
        public static void InsertarClienteYCaso()
        {
            try
            {
                Console.Write("Ingrese el nombre del cliente: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese el celular: ");
                string celular = Console.ReadLine();

                Console.Write("Ingrese el correo: ");
                string correo = Console.ReadLine();

                Console.Write("Ingrese la descripción del caso: ");
                string descripcion = Console.ReadLine();

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.Conectar())
                {
                    SqlCommand cmdCliente = new SqlCommand(
                        "SP_InsertarCliente", cn);

                    cmdCliente.CommandType =
                        CommandType.StoredProcedure;

                    cmdCliente.Parameters.AddWithValue(
                        "@Nombre", nombre);

                    cmdCliente.Parameters.AddWithValue(
                        "@Celular", celular);

                    cmdCliente.Parameters.AddWithValue(
                        "@Correo", correo);

                    int idCliente =
                        Convert.ToInt32(cmdCliente.ExecuteScalar());

                    SqlCommand cmdCaso = new SqlCommand(
                        "SP_InsertarCaso", cn);

                    cmdCaso.CommandType =
                        CommandType.StoredProcedure;

                    cmdCaso.Parameters.AddWithValue(
                        "@Descripcion", descripcion);

                    cmdCaso.Parameters.AddWithValue(
                        "@Estado", 1);

                    cmdCaso.Parameters.AddWithValue(
                        "@IdCliente", idCliente);

                    cmdCaso.ExecuteNonQuery();

                    Console.WriteLine(
                        $"Cliente creado, Numero de orden {idCliente}");

                    Console.WriteLine(
                        "Caso registrado correctamente.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(
                    "Error de SQL Server: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error inesperado: " + ex.Message);
            }
        }
    }
}