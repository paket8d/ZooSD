using EntitiesClassLibrary;
namespace ZooClassLibrary
{
    public class AliveFactory : IAliveFactory
    {
        private readonly Dictionary<string, Type> _creators;

        public AliveFactory(Dictionary<string, Type> creators)
        {
            _creators = creators;
        }

        /// <summary>
        /// Создание животного, немного хардкода, не придумал, как реализовать лучше,
        /// потому что у каждого животного в дальнейшем могут быть уникальные поля
        /// </summary>
        /// <param name="typeName">Название класса</param>
        /// <returns>Объект - IAlive</returns>
        /// <exception cref="NotImplementedException">Такого вида нет</exception>
        public IAlive CreateAlive(string typeName)
        {
            _creators.TryGetValue(typeName, out var type);
            switch (type)
            {
                case Type t when t == typeof(Tiger):
                    return CreateTiger();
                case Type t when t == typeof(Monkey):
                    return CreateMonkey();
                case Type t when t == typeof(Rabbit):
                    return CreateRabbit();
                case Type t when t == typeof(Wolf):
                    return CreateWolf();
                default:
                    throw new NotImplementedException("Такого вида животных нет в зоопарке");
            }
        }
        private IAlive CreateTiger()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите количество еды: ");
            int food = int.Parse(Console.ReadLine());
            return new Tiger(food, name);
        }
        private IAlive CreateMonkey()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите количество еды: ");
            int food = int.Parse(Console.ReadLine());
            return new Monkey(food, name);
        }
        private IAlive CreateRabbit()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите количество еды: ");
            int food = int.Parse(Console.ReadLine());
            Console.Write("Введите уровень счастья: ");
            int kindness = int.Parse(Console.ReadLine());
            return new Rabbit(food, name, kindness);
        }
        private IAlive CreateWolf()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите количество еды: ");
            int food = int.Parse(Console.ReadLine());
            return new Wolf(food, name);
        }

        public IEnumerable<string> GetAvailableTypes() => _creators.Keys;
    }
}
