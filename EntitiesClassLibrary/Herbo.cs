namespace EntitiesClassLibrary
{
    public abstract class Herbo : Animal, IContactable
    {
        public int Kindness { get; protected set; }
        public Herbo(int food, string name, int kindness) : base(food, name)
        {
            Kindness = kindness;
        }
    }
}
