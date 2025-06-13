namespace CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Visitor;

class IncrementNumberVisitor : IVisitor
{
	public void VisitSmallNumbers(SmallNumber number)
	{
		Number currentNumber = number as Number;

		int temp = currentNumber.NumberValue;
		// For SmallNumber's incrementing by 1
		Console.WriteLine($"{currentNumber.TypeInfo} is {currentNumber.NumberValue}; I use it as:{++temp} for rest of my code.");
		// code, if any
	}

	public void VisitBigNumbers(BigNumber number)
	{
		Number currentNumber = number as Number;
		int temp = currentNumber.NumberValue;
		// For BigNumber's incrementing by 10
		Console.WriteLine($"{currentNumber.TypeInfo} is {currentNumber.NumberValue}; I convert it as:{temp + 10} for ret of my code.");
		// code, if any
	}

	public void VisitNumbers(UndefinedNumber number)
	{
		throw new NotImplementedException();
	}
}
