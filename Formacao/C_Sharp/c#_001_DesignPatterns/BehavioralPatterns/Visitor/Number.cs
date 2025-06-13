/// <summary>
/// Abstract class - Number
/// </summary>
abstract class Number
{
    private int numberValue;
    private string type;

    public Number(string type, int number)
    {
        this.type = type;
        this.numberValue = number;
    }

    // I want to restrict the change in original data
    // So, no setter is present here.
    public int NumberValue
    {
        get { return numberValue; }
    }

    public string TypeInfo
    {
        get { return type; }
    }

    public abstract void SomeMethod();

    public abstract void Accept(IVisitor visitor);
}