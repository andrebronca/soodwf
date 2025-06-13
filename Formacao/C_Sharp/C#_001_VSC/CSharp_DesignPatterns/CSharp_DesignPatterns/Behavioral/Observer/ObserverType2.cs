namespace CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Observer;

class ObserverType2 : IObserver
{
	string nameOfObserver;

	public ObserverType2(string name)
	{
		this.nameOfObserver = name;
	}

	public void Update(ICelebrity celeb)
	{
		Console.WriteLine($"{nameOfObserver} notified. Inside {celeb.Name}, the updated value is: {celeb.Flag}");
	}
}
