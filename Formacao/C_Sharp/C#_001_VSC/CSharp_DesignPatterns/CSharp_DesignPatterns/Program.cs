using CSharp_DesignPatterns.CSharp_DesignPatterns.Behavioral.Visitor;

class Program
{
	public static void Main()
	{
		//VisitorPattern();

	}

	private static void VisitorPattern()
	{
		NumberCollection numberCollection = new NumberCollection();
		numberCollection.DisplayList();
		IncrementNumberVisitor incrVisitor = new IncrementNumberVisitor();
		Console.WriteLine("IncrementNumberVisitor is about to visit the list:");
		numberCollection.Accept(incrVisitor);
		numberCollection.DisplayList();

		InvestigateNumberVisitor investigateNumberVisitor = new InvestigateNumberVisitor();
		Console.WriteLine("InvestigateNubmerVisitor is about to visit the list:");
		numberCollection.Accept(investigateNumberVisitor);

		Console.ReadLine();
	}
}