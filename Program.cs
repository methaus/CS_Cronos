using System;

namespace CS_Cronos
{
    class Program
    {
        public static void Main()
        {
            Cronometro cronos = new Cronometro();

            while (true)
            {
                cronos.Run();

                Console.Write("\n\nCronometrar outro tempo? ENTER");
                if (Console.ReadKey(true).Key != ConsoleKey.Enter)
                    break;
            }

            Console.Write("\n\nFim do programa...");
            Console.ReadKey(true);
        }
    }
}