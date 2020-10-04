using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitNonAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            AwaitMethod();
            NonAwaitMethod();

            Console.WriteLine("Finish Main thread\n");
            Console.ReadKey();
        }

        static async Task AwaitMethod()
        {
            Console.WriteLine("Start AwaitMethod\n");
            await Action1("AwaitMethod\n");
            Console.WriteLine("Stop AwaitMethod\n");
        }

        static async Task<int> Action1(string msg)
        {
            await Task.Delay(5000);
            Console.WriteLine($"Finish Action1. Caller {msg}\n");
            return 10;
        }

        static async Task NonAwaitMethod()
        {
            Console.WriteLine("Start NonAwaitMethod\n");
            Action1("NonAwaitMethod");
            Console.WriteLine("Stop NonAwaitMethod\n");
        }

        static int Action2()
        {
            Thread.Sleep(1000);
            return 2;
        }
    }
}
