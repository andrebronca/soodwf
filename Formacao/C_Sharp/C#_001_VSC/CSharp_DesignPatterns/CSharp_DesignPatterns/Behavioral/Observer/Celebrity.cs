namespace CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Observer;

class Celebrity : ICelebrity
{
	List<IObserver> observerList = new List<IObserver>();
	private int flag;
	public int Flag
	{
		get
		{
			return flag;
		}
		set
		{
			flag = value;
			// Flag value changed. So notify observer(s).
			NotifyRegisteredUsers();
		}
	}

	private string name;
	public string Name => name; //get, set

	public Celebrity(string name)
	{
		this.name = name;
	}

	// To register an observer
	public void Register(IObserver anObserver)
	{
		observerList.Add(anObserver);
	}

	// To unregister an Observer
	public void Unregister(IObserver anObserver)
	{
		observerList.Remove(anObserver);
	}

	// Notify all registered observers
	public void NotifyRegisteredUsers()
	{
		foreach (IObserver observer in observerList)
		{
			observer.Update(this);
		}
	}
}
