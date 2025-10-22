using EntitiesClassLibrary;

namespace ZooClassLibrary
{
    public interface IAliveFactory
    {
        IAlive CreateAlive(string typeName);
        IEnumerable<string> GetAvailableTypes();
    }
}
