public sealed class SingletonRaca
{
    private static SingletonRaca instance = null;

    private SingletonRaca() { }

    public static SingletonRaca Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonRaca();
            }
            return instance;
        }
    }