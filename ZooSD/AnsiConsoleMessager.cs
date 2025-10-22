using Spectre.Console;
using System.Collections;

namespace ZooSD
{
    public class AnsiConsoleMessager : IMessaging
    {
        private readonly IAnsiConsole _console;
        public AnsiConsoleMessager(IAnsiConsole console)
        {
            _console = console;
        }
        public void ShowMessage(string message)
        {
            _console.Markup($"[green]{message}\n[/]");
        }

        public void ShowInfo(string message)
        {
            _console.Markup($"[white]{message}\n[/]");
        }

        public void ShowError(string message)
        {
            _console.Markup($"[red]{message}\n[/]");
        }
    }
}
