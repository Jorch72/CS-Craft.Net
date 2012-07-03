using System;
using Craft.Net.Server;
using System.Net;
using Craft.Net.Server.Worlds;
using Craft.Net.Server.Worlds.Generation;

namespace Craft.Net.Server.Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Create a server on 0.0.0.0:25565
            MinecraftServer minecraftServer = new MinecraftServer(
		        new IPEndPoint(IPAddress.Any, 25565));
            minecraftServer.OnlineMode = false;
            // Add a console logger
            minecraftServer.AddLogProvider(new ConsoleLogWriter(LogImportance.High));
            minecraftServer.AddLogProvider(new FileLogWriter("packetLog.txt", LogImportance.Low));
            // Add a flatland world
            minecraftServer.AddWorld(new World(new FlatlandGenerator()));
            // Start the server
            minecraftServer.Start();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
            // Stop the server
            minecraftServer.Stop();
        }
    }
}
