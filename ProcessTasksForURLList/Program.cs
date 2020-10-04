using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTasksForURLList
{
    class Program
    {
        static readonly HttpClient _client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        static readonly IEnumerable<string> _urlList = new string[]
{
            "https://docs.microsoft.com",
            "https://docs.microsoft.com/aspnet/core",
            "https://docs.microsoft.com/azure",
            "https://docs.microsoft.com/azure/devops",
            "https://docs.microsoft.com/dotnet",
            "https://docs.microsoft.com/dynamics365",
            "https://docs.microsoft.com/education",
            "https://docs.microsoft.com/enterprise-mobility-security",
            "https://docs.microsoft.com/gaming",
            "https://docs.microsoft.com/graph",
            "https://docs.microsoft.com/microsoft-365",
            "https://docs.microsoft.com/office",
            "https://docs.microsoft.com/powershell",
            "https://docs.microsoft.com/sql",
            "https://docs.microsoft.com/surface",
            "https://docs.microsoft.com/system-center",
            "https://docs.microsoft.com/visualstudio",
            "https://docs.microsoft.com/windows",
            "https://docs.microsoft.com/xamarin"
};

        static void Main(string[] args)
        {
            SumPageSizesAsync();
            BigCalc();
            Console.WriteLine("--------------------------------------------Finish main thread");
            Console.ReadKey();
        }


        static async Task<int> ProcessUrlAsync(string url, HttpClient client)
        {
            byte[] content = await client.GetByteArrayAsync(url);
            Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

            return content.Length;
        }

        static async Task SumPageSizesAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            IEnumerable<Task<int>> downloadTasksQuery =
                from url in _urlList
                select ProcessUrlAsync(url, _client);

            List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

            int total = 0;
            while (downloadTasks.Any())
            {
                Task<int> finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
                total += await finishedTask;
            }

            stopwatch.Stop();

            Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
        }


        static async Task<int> CalculateNuclearExplosion()
        {
            int result = 0;
            while (result < 100)
            {
                await Task.Delay(500);
                result += 10;
                Console.WriteLine($"Result of calculation : {result}");
            }

            return result;
        }

        static async Task AssembleRobot()
        {
            int percent = 0;
            while (percent < 100)
            {
                await Task.Delay(100);
                percent += 10;
                Console.WriteLine($"Percent of completition : {percent}");
            }
        }

        static async Task BigCalc()
        {
            //await CalculateNuclearExplosion();
            //await AssembleRobot();
            //await Task.WhenAll(Task.Run(() => CalculateNuclearExplosion()), Task.Run(() => AssembleRobot()));
            var t = Task.WhenAll(Task.Run(() => CalculateNuclearExplosion()), Task.Run(() => AssembleRobot()));
            await t;
            Console.WriteLine($"FINISH BIG CALC");
        }
    }
}
