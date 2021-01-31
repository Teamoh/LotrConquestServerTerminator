using System;
using System.Diagnostics;

namespace LotrConquestServerTerminator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverProcessName = "ConquestServer";
            var serverProcesses = Process.GetProcessesByName(serverProcessName);
            var serverProcessesLength = serverProcesses.Length;

            if (serverProcessesLength == 0)
            {
                Console.WriteLine("No ConquestServer processes found");
            }
            else
            {
                Console.WriteLine($"Please confirm to terminate {serverProcessesLength} ConquestServer {(serverProcessesLength == 1 ? "process" : "processes")} (y/n)?");

                var confirmInput = Console.ReadLine().Trim();

                if (confirmInput.ToLower() != "y")
                {
                    return;
                }

                var counter = 0;
                var successCounter = 0;

                foreach (var process in serverProcesses)
                {
                    counter++;

                    Console.WriteLine($"\nTerminating server process {counter}...");

                    try
                    {
                        process.Kill();
                        Console.WriteLine($"Successfully terminated server process {counter}");
                        successCounter++;
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine($"Failed to terminate server process {counter}: {exc.Message}");
                    }
                }

                if (successCounter == 0)
                {
                    Console.WriteLine("\nFailed to terminate server processes");
                }
                else {
                    Console.WriteLine($"\nTerminated {successCounter}/{serverProcessesLength} server processes");
                }
            }

            Console.ReadKey();
        }
    }
}
