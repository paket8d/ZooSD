using InventoryClassLibrary;
namespace EntitiesClassLibrary
{
    public abstract class Animal : IAlive
    {
        private static int _nextNumber = 1;
        private int? _number;
        public int Food { get; protected set; }
        public int Number 
        { 
            get => _number ?? throw new InvalidOperationException("Животное не в зоопарке, номер не присвоен");
            set => _number = value;
        }
        public string Name { get; protected set; }

        public Animal(int food, string name)
        {
            Food = food;
            Name = name;
        }
    }
}
