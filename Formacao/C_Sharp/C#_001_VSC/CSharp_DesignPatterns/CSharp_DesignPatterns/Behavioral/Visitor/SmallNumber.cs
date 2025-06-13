namespace CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Visitor;

/// <summary>
/// Concrete class-SmallNumber
/// </summary>

class SmallNumber : Number
{
	public SmallNumber(string type, int number) : base(type, number) { }

	public override void SomeMethod()
	{
		// Some code
	}

	public override void Accept(IVisitor visitor)
	{
		visitor.VisitSmallNumbers(this);
	}
}
