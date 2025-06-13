namespace CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Visitor;

class InvestigateNumberVisitor : IVisitor
{
	public void VisitSmallNumbers(SmallNumber number)
	{
		Number currentNumber = number as Number;
		int temp = currentNumber.NumberValue;
		// Checking whether the number is greater than 10 or not
		string isTrue = temp > 10 ? "Yes" : "No";
		Console.WriteLine($"Is {currentNumber.TypeInfo} greater than 10? {isTrue}");
	}

	public void VisitBigNumbers(BigNumber number)
	{
		Number currentNumber = number as Number;
		int temp = currentNumber.NumberValue;
		// Checking whether the number is greater than 10 or not
		string isTrue = temp > 100 ? "Yes" : "No";
		Console.WriteLine($"Is {currentNumber.TypeInfo} greater than 100? {isTrue}");
	}

	public void VisitNumbers(UndefinedNumber number)
	{
		throw new NotImplementedException();
	}
}
