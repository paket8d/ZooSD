using InventoryClassLibrary;

namespace EntitiesClassLibrary
{
    public interface IAlive : IInventory
    {
        public int Food { get; }
    }
}
