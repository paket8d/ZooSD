using Spectre.Console;
using ZooClassLibrary;

namespace ZooSD
{
    public interface IMenu
    {
        public IZoo Zoo { get; }
        public IAliveFactory Factory { get; }
        public IMessaging Messager { get; }
        public void ShowMenu();
    }
}
