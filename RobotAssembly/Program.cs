using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RobotAssembly.DataContracts;

namespace RobotAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Stage1();
            Stage2();
            Console.ReadKey();
        }

        static async void Stage1()
        {
            Console.WriteLine("Start STAGE 1");
            AssembleHeadAsync(1);
            AssembleBodyAsync(1);

        }

        static async void Stage2()
        {
            Console.WriteLine("Start STAGE 2");
            Task<Head> T1 = AssembleHeadAsync(2);
            Task<Body> T2 = AssembleBodyAsync(2);

            var headTask = await T1;
            var bodyTask = await T1;

            await Task.WhenAll(T1, T2);

        }

        static async Task<Head> AssembleHeadAsync(int stageNumber)
        {
            Console.WriteLine($"STAGE {stageNumber} : Start head assembling...");

            Console.WriteLine($"STAGE {stageNumber} : Assemble head eyes");
            await Task.Delay(100);
            Console.WriteLine($"STAGE {stageNumber} : Assemble head sensors");
            await Task.Delay(100);
            Console.WriteLine($"STAGE {stageNumber} : Assemble head speeking unit");
            await Task.Delay(50);
            Console.WriteLine($"STAGE {stageNumber} : Assemble head skull");
            await Task.Delay(200);

            Console.WriteLine($"STAGE {stageNumber} : Finish head assembling...");
            return new Head();
        }

        static async Task<Body> AssembleBodyAsync(int stageNumber)
        {
            Console.WriteLine($"STAGE {stageNumber} : Start body assembling...");

            Console.WriteLine($"STAGE {stageNumber} : Assemble body reactor");
            await Task.Delay(300);
            Console.WriteLine($"STAGE {stageNumber} : Assemble body   torso");
            await Task.Delay(200);
            Console.WriteLine($"STAGE {stageNumber} : Assemble body limbs");
            await Task.Delay(250);
            Console.WriteLine($"STAGE {stageNumber} : Assemble body armor");
            await Task.Delay(200);
            Console.WriteLine($"STAGE {stageNumber} : Assemble body servo motors");
            await Task.Delay(150);
            Console.WriteLine($"STAGE {stageNumber} : Anodize");
            await Task.Delay(10);

            Console.WriteLine($"STAGE {stageNumber} : Finish body assembling...");
            return new Body();
        }
    }
}
