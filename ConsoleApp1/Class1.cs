public class Contador_de_Intentos
{
    private int maxIntentos;

    public Contador_de_Intentos(int maxIntentos)
    {
        this.maxIntentos = maxIntentos;
    }

    public int LeerOpcion()
    {
        int intentos = 0;

        while (intentos < maxIntentos)
        {
            Console.WriteLine("Ingrese una opción del 1 al 4:");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("No se aceptan letras, solo numeros");

                Console.ResetColor();

                Console.WriteLine("El programa se cerrara.");
            
                Thread.Sleep(3000);

                Environment.Exit(0);
            }

            if (opcion >= 1 && opcion <= 4)
            {
                if (opcion == 4)
                {
                    Console.WriteLine("Hasta pronto.");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }

                return opcion;
            }

            intentos++;
            Console.WriteLine($"Solo numeros. {intentos}/{maxIntentos}");
        }

        Console.WriteLine("No hay mas intentos.");
        Thread.Sleep(3000);
        Environment.Exit(0);

        return -1;

        
    }
}