namespace PhoneBookTestApp.DependencyInjection
{
    public interface IContainer
    {
        T Get<T>() where T : class;
    }
}