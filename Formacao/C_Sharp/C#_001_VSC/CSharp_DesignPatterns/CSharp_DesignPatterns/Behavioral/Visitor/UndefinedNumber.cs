namespace CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Visitor;

class UndefinedNumber : Number
{
	public UndefinedNumber(string type, int number) : base(type, number) { }

	public override void SomeMethod()
	{
		// Some code
	}

	public override void Accept(IVisitor visitor)
	{
		visitor.VisitNumbers(this);
	}
}
