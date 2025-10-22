using EntitiesClassLibrary;

namespace ZooClassLibrary
{
    public class VetClinic : IVetClinic
    {
        /// <summary>
        /// Метод проверки здоровья, детальная реализация оставлена на потом, последующим разработчкам
        /// </summary>
        /// <param name="alive"></param>
        /// <returns></returns>
        public bool CheckHealth(IAlive aliveCreature)
        {
            return true;
        }
    }
}
