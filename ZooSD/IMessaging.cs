namespace ZooSD
{
    public interface IMessaging
    {
        public void ShowInfo(string info);
        public void ShowError(string error);
        public void ShowMessage(string message);
    }
}
