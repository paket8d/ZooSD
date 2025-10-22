using EntitiesClassLibrary;
using InventoryClassLibrary;

namespace ZooClassLibrary
{
    public interface IZoo
    {
        public IVetClinic Clinic { get; }
        public bool TryAddNewAliveCreature(IAlive aliveCreature);
        public int GetAmountOfNeededFood();
        public string GetInventories();
        public void SetVetClinic(IVetClinic vetClinic);
        public ICollection<IAlive> GetAlivesCollection();
        public ICollection<IInventory> GetInventoriesCollection();
        ICollection<IContactable> GetContactableZooAlives();
    }
}
