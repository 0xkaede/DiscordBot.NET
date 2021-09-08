using System;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        public static async Task Main(string[] args) 
            => await Startup.RunAsync(args);
    }
}
