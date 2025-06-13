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
        visitor.VisitSmallNumber(this);
    }
}