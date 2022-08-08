using System;
using System.Threading;

namespace CS_Cronos
{
    class Cronometro
    {
        private string titulo = "CRONOMETRO\n\n", timeInputType = "-1";
        private int timeInput = -1;
        private bool running = true;
        public void Run()
        {
            Menu();
            if (running == true)
            {
                PreStartRun();
                StartRun();
            }
        }
        private void Menu()
        {
            string? timeInputBrute;

            Console.Clear();
            Console.Write($"{titulo}Para contar digite o número seguido da unidade (m/s)\nEx: 30s - p/ 30 segundos\n    2m  - p/ 2 minutos");

            do
            {
                Console.Write("\n\n> ");
                timeInputBrute = Console.ReadLine();
            } while (timeInputBrute == null);

            try
            {
                timeInput = Convert.ToInt32(timeInputBrute.Substring(0, timeInputBrute.Length - 1));
                if (timeInput < 1)
                    throw new Exception("Valor a cronometrar inválido.");
                timeInputType = timeInputBrute.Substring(timeInputBrute.Length - 1);
                if (!(timeInputType.ToLower() == "s" || timeInputType.ToLower() == "m"))
                    throw new Exception("Tempo a cronometrar não é segundos (##s) nem minutos (##m).");
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}");
                running = false;
            }
        }
        private void PreStartRun()
        {
            Console.Clear();
            Console.Write($"{titulo}Pressione ENTER para iniciar o cronômetro...");
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    break;
            }

            Console.Write("\n\nCronometro começará em: ");
            for (int i = 3; i != -1; i--) //24
            {
                Console.CursorLeft = 24;
                Console.Write(i);
                Thread.Sleep(1000);
            }
        }
        private void StartRun()
        {
            Console.Clear();
            Console.Write($"{titulo}CONTANDO: ");

            if (timeInputType.ToLower() == "s")
                while (true)
                {
                    Console.CursorTop = 2;
                    Console.CursorLeft = 10;
                    Console.Write($"{timeInput--}s                ");
                    Console.CursorLeft = 9;
                    if (timeInput == -1)
                        break;
                    Thread.Sleep(1000);
                }

            if (timeInputType.ToLower() == "m")
            {
                timeInput*=60;
                while (true)
                {
                    Console.CursorTop = 2;
                    Console.CursorLeft = 10;
                    Console.Write($"{timeInput-- / 60}m {timeInput % 60}s                ");
                    Console.CursorLeft = 9;
                    if (timeInput == -1)
                        break;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
