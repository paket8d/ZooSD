namespace InventoryClassLibrary
{
    public abstract class Thing : IInventory
    {
        private int? _number;
        public int Number
        {
            get => _number ?? throw new InvalidOperationException("Вещь не в зоопарке, номер не присвоен");
            set => _number = value;
        }
        public string Name { get; protected set; }

        public Thing(string name)
        {
            Name = name;
        }
    }
}
