using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        private static ILogger<Program> logger;
        private static HubConnection connection;

        static void Main(string[] args)
        {

            logger = CreateLogger<Program>();

            var services = new ServiceCollection()
                .AddLogging(build =>
                {
                    build.AddConsole();
                });

            var servicesProvider = services.BuildServiceProvider();

            connection = new HubConnectionBuilder()
                        .WithUrl("https://localhost:5001/hub/game")
                        .WithAutomaticReconnect()
                        .Build();

            connection.On<string>("PlayerJoin", (playerName) => Console.WriteLine(playerName));
            connection.On<string>("PlayerStats", (stats) => Console.WriteLine(stats));
            connection.On<string>("DiceRolls", (diveValues) => Console.WriteLine(diveValues));

            //conn.Closed += async (ex) =>
            //{
            //    await Task.Delay(new Random().Next(0, 5) * 1000);
            //    await conn.StartAsync();
            //};

            bool showMenu = true;
            do
            {
                try
                {
                    showMenu = ShowMenu().Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ooooops!!!");
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                }
            } while (showMenu);

        }

        static async Task<bool> ShowMenu()
        {
            
            Console.WriteLine("1. Connect to hub");
            Console.WriteLine("2. Send PlayerJoin");
            Console.WriteLine("3. Send PlayerStats");
            Console.WriteLine("4. Send DiceRolls");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Choose an option:");

            switch (Console.ReadLine())
            {
                case "1":
                    if (connection.State != HubConnectionState.Connected)
                    {
                        await connection.StartAsync();
                    }
                    else
                    {
                        Console.WriteLine("Connection already connected");
                    }
                    return true;
                case "2":
                    if (connection.State != HubConnectionState.Connected)
                    {
                        Console.WriteLine("Connection must be connected");
                    }
                    else
                    {
                        await connection.InvokeAsync("PlayerJoin", "ConsolePlayer");
                    }
                    return true;
                case "3":
                    if (connection.State != HubConnectionState.Connected)
                    {
                        Console.WriteLine("Connection must be connected");
                    }
                    else
                    {
                        await connection.InvokeAsync("PlayerStats", "Str: 1, Dex: 7");
                    }
                    return true;
                case "4":
                    if (connection.State != HubConnectionState.Connected)
                    {
                        Console.WriteLine("Connection must be connected");
                    }
                    else
                    {
                        await connection.InvokeAsync("DiceRolls", "1 5 6 8 2 4");
                    }
                    return true;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Choose an menu option");
                    return true;
            }
        }

        static ILogger<TLogger> CreateLogger<TLogger>() {
            var logFactory = LoggerFactory.Create(build =>
            {
                build.ClearProviders()
                    .AddConsole();
            });

            return logFactory.CreateLogger<TLogger>();
        }

    }
}
