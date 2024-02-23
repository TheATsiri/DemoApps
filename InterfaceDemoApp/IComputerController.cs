namespace InterfaceDemoApp
{
    public interface IComputerController : IDisposable
    {
        void Connect();
        void KeyPressed();
    }
}
