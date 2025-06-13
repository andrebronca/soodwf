namespace CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Visitor;

/// <summary>
/// Concrete class-BigNumber
/// </summary>

class BigNumber : Number
{
	public BigNumber(string type, int number) : base(type, number) { }

	public override void SomeMethod()
	{
		// some code
	}

	public override void Accept(IVisitor visitor)
	{
		visitor.VisitBigNumbers(this);
	}
}
