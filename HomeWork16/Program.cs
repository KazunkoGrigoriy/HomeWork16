using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork16
{
    class Program
    {
        static async void Method()
        {
            await Task.Run(() =>
            {
                var method = Thread.CurrentThread;
                method.Name = "Method";

                Console.WriteLine($"\nПоток {method.Name} начал работу");

                for (int i = 0; i < 100; i++)
                {
                    Console.Write("+ ");
                    Thread.Sleep(200);
                }

                Console.WriteLine($"\nПоток {method.Name} завершен");
            });
        }

        static void Main(string[] args)
        {
            var mainThread = Thread.CurrentThread;
            mainThread.Name = "CurentThread";
            
            Thread thread = new Thread(Method);
            thread.Start();

            Console.WriteLine($"\nПоток {mainThread.Name} начал работу");

            for (int i = 0; i < 100; i++)
            {
                Console.Write("- ");
                Thread.Sleep(20);
            }

            Console.WriteLine($"\nПоток {mainThread.Name} завершен");

            Console.ReadKey();
        }
    }
}
