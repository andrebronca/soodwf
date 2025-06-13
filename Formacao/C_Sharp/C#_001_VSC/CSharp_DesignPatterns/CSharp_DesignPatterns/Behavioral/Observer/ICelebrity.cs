namespace CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Observer;

interface ICelebrity
{
	// Name of Subject
	string Name { get; }
	int Flag { get; set; }
	// To Register
	void Register(IObserver o);
	// To Unregister
	void Unregister(IObserver o);
	// To notify registered users
	void NotifyRegisteredUsers();
}
