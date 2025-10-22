using EntitiesClassLibrary;
using InventoryClassLibrary;

namespace ZooClassLibrary
{
    public class Zoo : IZoo
    {
        private static int _nextNumber = 1;
        private ICollection<IAlive> alives = new List<IAlive>();
        private ICollection<IInventory> inventories = new List<IInventory>();
        private int GetInventoryItemNumber(IInventory inventoryItem)
        {
            return inventoryItem.Number;
        }
        private string GetInventoryItemName(IInventory inventoryItem)
        {
            return inventoryItem.Name;
        }
        public IVetClinic Clinic { get; protected set; }
        public bool TryAddNewAliveCreature(IAlive aliveCreature)
        {
            if (Clinic.CheckHealth(aliveCreature))
            {
                aliveCreature.Number = _nextNumber++;
                inventories.Add(aliveCreature);
                alives.Add(aliveCreature);
                return true;
            }
            return false;
        }
        public int GetAmountOfNeededFood()
        {
            int ans = 0;
            foreach (var alive in alives)
            {
                ans += alive.Food;
            }
            return ans;
        }
        public string GetInventories()
        {
            string res = string.Empty;
            foreach (var inventory in inventories)
            {
                res += GetInventoryItemNumber(inventory) + "\t\t" + GetInventoryItemName(inventory) + "\n";
            }
            return res;
        }
        public void SetVetClinic(IVetClinic vetClinic)
        {
            Clinic = vetClinic;
        }
        public ICollection<IContactable> GetContactableZooAlives()
        {
            return alives
                .OfType<IContactable>()
                .Where(a => a.Kindness > 5)
                .ToList();
        }
        public ICollection<IAlive> GetAlivesCollection()
        {
            return alives;
        }
        public ICollection<IInventory> GetInventoriesCollection()
        {
            return inventories;
        }
        public Zoo (IVetClinic vetClinic)
        {
            Clinic = vetClinic;
        }
    }
}
