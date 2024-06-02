namespace DIWpfDemo.StartupHelpers
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}