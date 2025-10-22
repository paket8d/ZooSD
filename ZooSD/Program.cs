using EntitiesClassLibrary;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;
using ZooClassLibrary;

namespace ZooSD
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static Dictionary<string, Type> GetDictOfAlives()
        {
            var type = typeof(IAlive);
            var types = type.Assembly
                .GetTypes()
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface);
            Dictionary<string, Type> dict = new();
            foreach (var t in types)
            {
                dict[t.Name] = t;
            }
            return dict;
        }
        static void Main(string[] args)
        {
            var type = typeof(IAlive);
            Dictionary<string, Type> dict = GetDictOfAlives();

            var services = new ServiceCollection()
                .AddTransient<IVetClinic, VetClinic>()
                .AddTransient<IAliveFactory>(serviceProvider => new AliveFactory(dict))
                .AddTransient<IZoo, Zoo>()
                .AddTransient<IAnsiConsole>(serviceProvider => AnsiConsole.Console)
                .AddTransient<IMessaging, AnsiConsoleMessager>()
                .AddTransient<IMenu, Menu>();

            using var serviceProvider = services.BuildServiceProvider();
            var zoo = serviceProvider.GetRequiredService<IZoo>();
            var factory = serviceProvider.GetRequiredService<IAliveFactory>();
            var messager = serviceProvider.GetRequiredService<IMessaging>();
            var console = serviceProvider.GetRequiredService<IAnsiConsole>();

            Menu menu = new Menu(console, zoo, factory, messager);
            menu.Run();
        }
    }
}
