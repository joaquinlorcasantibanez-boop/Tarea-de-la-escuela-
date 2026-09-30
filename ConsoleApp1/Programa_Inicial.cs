using TuProyecto;

Console.WriteLine("===== INICIO DE SESIÓN =====");

Console.Write("Correo: ");
string correo = Console.ReadLine();

Console.Write("Contraseña: ");
string contrasena = Console.ReadLine();

Sesion login = new Sesion();

string rol = login.Validar_Datos(correo, contrasena);

if (rol == "NoExiste")
{
    Console.WriteLine("\nCorreo o contraseña incorrectos.");
    Thread.Sleep(3000);
    return;
}

Console.Clear();
Console.WriteLine($"Bienvenido {rol}");

int opcion;

Contador_de_Intentos contador = new Contador_de_Intentos(3);

do
{
    Console.WriteLine("\n===== BIENVENIDO AL SISTEMA =====");
    Console.WriteLine("1. Modificar estado caso");
    Console.WriteLine("2. Buscar trabajador");
    Console.WriteLine("3. Añadir cliente y caso");
    Console.WriteLine("4. Salir");

    opcion = contador.LeerOpcion();

    switch (opcion)
    {
        case 1:
            Console.Clear();

            Casos.ActualizarEstadoCaso();

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            Console.Clear();
            break;

        case 2:
            Console.Clear();
            if (rol != "Administrador")
            {
                Console.WriteLine(
                    "\nNo puede ingresar a esta opción con sus permisos.");

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

                Console.Clear();
                break;
            }

            Ver_Info_Trabajador.BuscarTrabajador();

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            Console.Clear();
            break;

            Ver_Info_Trabajador pantalla = new Ver_Info_Trabajador();
           
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            Console.Clear();
            break;

        case 3:
            Console.Clear();

            Añadir_Cliente_y_Caso.InsertarClienteYCaso();

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            Console.Clear();
            break;

        case 4:
            Console.Clear();
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opción no válida.");
            break;
    }

} while (opcion != 4);