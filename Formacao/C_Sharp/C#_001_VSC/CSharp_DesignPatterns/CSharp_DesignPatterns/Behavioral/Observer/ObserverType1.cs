namespace CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Observer;

class ObserverType1 : IObserver
{
	string nameOfObserver;

	public ObserverType1(String name)
	{
		this.nameOfObserver = name;
	}

	public void Update(ICelebrity celeb)
	{
		Console.WriteLine($"{nameOfObserver} has received an alert from {celeb.Name}. Updated value is: {celeb.Flag}");
	}
}
