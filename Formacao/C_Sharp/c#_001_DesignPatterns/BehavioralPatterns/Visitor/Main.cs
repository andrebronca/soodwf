class Main
{
    public static void Main(string[] args)
    {
        NumberCollection numberCollection = new NumberCollection();
        IncrementNumberVisitor incrVisitor = new IncrementNumberVisitor();

        Console.WriteLine("IncrementNumberVisitor is about to visit the list:");
        numberCollection.Accept(incrVisitor);
    }
}