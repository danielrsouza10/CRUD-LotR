public sealed class SingletonPersonagem
{
	private static SingletonPersonagem instance = null;

	private SingletonPersonagem() { }

	public static SingletonPersonagem Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new SingletonPersonagem();
			}
			return instance;
		}
	}