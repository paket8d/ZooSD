using EntitiesClassLibrary;
using Spectre.Console;
using System.IO;
using System.Runtime.CompilerServices;
using ZooClassLibrary;
using System.Diagnostics.CodeAnalysis;

namespace ZooSD
{
    [ExcludeFromCodeCoverage]
    public class Menu : IMenu
    {
        private readonly IAnsiConsole _console;
        public IZoo Zoo { get; protected set; }
        public IAliveFactory Factory { get; protected set; }
        public IMessaging Messager { get; protected set; }
        public Menu(IAnsiConsole console, IZoo zoo, IAliveFactory factory, IMessaging messager)
        {
            _console = console;
            Zoo = zoo;
            Factory = factory;
            Messager = messager;
        }
        public void Run()
        {
            ShowMenu();
        }

        public void ShowMenu()
        {
            var mainMenu = new SelectionPrompt<string>()
                .Title("Главное меню")
                .PageSize(10)
                .AddChoices(
                [
                    "Добавить животное в зоопарк",
                    "Получить необходимое количество еды для всех живых существ в зоопарке",
                    "Получить ивентарные номера и имена животных и вещей, стоящих на балансе",
                    "Получить список животных, которые могут быть отправлены в контактный зоопарк",
                    "Выход"
                ]);

            while (true)
            {
                _console.Clear();
                string choice = _console.Prompt(mainMenu);

                switch (choice)
                {
                    case "Добавить животное в зоопарк":
                        if (Zoo.TryAddNewAliveCreature(GetAlive())) {
                            Messager.ShowMessage("Животное здорово, оно будет добавлено в зоопарк");
                        }
                        else
                        {
                            Messager.ShowError("Животное больно, оно не будет добавлено в зоопарк");
                        }
                        break;
                    case "Получить необходимое количество еды для всех живых существ в зоопарке":
                        Messager.ShowMessage("Необходимое количество еды для всех живых существ в зоопарке (в кг):");
                        Messager.ShowInfo(Zoo.GetAmountOfNeededFood().ToString());
                        break;
                    case "Получить ивентарные номера и имена животных и вещей, стоящих на балансе":
                        Messager.ShowMessage("Номер\t\tИмя");
                        Messager.ShowInfo(Zoo.GetInventories());
                        break;
                    case "Получить список животных, которые могут быть отправлены в контактный зоопарк":
                        Messager.ShowMessage("Имя");
                        foreach (var contactable in Zoo.GetContactableZooAlives().OfType<Animal>())
                        {
                            Messager.ShowInfo(contactable.Name);
                        }
                        break;
                    case "Выход":
                        return;
                }
                Messager.ShowInfo("Нажмите любую клавишу, чтобы продолжить");
                Console.ReadKey();
            }
        }

        private IAlive GetAlive()
        {
            var AddAliveMenu = new SelectionPrompt<string>()
                .Title("Выбор вида животного")
                .PageSize(10)
                .AddChoices(Factory.GetAvailableTypes());

            while (true)
            {
                _console.Clear();
                string choice = _console.Prompt(AddAliveMenu);

                return Factory.CreateAlive(choice);
            }
        }
    }
}