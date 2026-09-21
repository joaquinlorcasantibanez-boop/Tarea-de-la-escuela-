using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using TuProyecto;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema para modificar estado.");
            Console.WriteLine("¿Qué quiere hacer?");
            Console.WriteLine("1. Modificar estado del caso.");
            Console.WriteLine("2. Buscar trabajadores.");
            Console.WriteLine("3. Añadir clientes");
            Console.WriteLine("4. Salir");

            Contador_de_Intentos contador = new Contador_de_Intentos(4);
            int opcion = contador.LeerOpcion();

            Pantalla pantalla = new Pantalla();

            switch (opcion)
            {
                case 1:
                    Casos.ActualizarEstadoCaso();
                    break;

                case 2:
                    pantalla.BuscarTrabajador();
                    break;

                case 3:
                    Clientes.InsertarClienteYCaso();
                    break;

                case 4:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.ReadKey();
        }
    }
}


   