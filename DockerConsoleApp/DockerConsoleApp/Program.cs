using System;
using System.Threading.Tasks;

namespace DockerConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int counter = 0;
            int max = args.Length != 0 ? Convert.ToInt32(args[0]) : -1;
            while(max == -1 || counter < max)
            {
                Console.WriteLine($"Counter: {++counter}");
                await Task.Delay(1000);
            }
        }
    }
}
