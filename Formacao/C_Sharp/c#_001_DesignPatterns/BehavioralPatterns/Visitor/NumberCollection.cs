class NumberCollection
{
    List<Number> numberList = new List<Number>();
    // List contains both SmallNumber's and BigNumber's
    public NumberCollection()
    {
        numberList.add(new SmallNumber("small-1", 10));
        numberList.add(new SmallNumber("small-2", 20));
        numberList.add(new SmallNumber("small-3", 30));
        numberList.add(new BigNumber("big-1", 200));
        numberList.add(new BigNumber("big-2", 150));
        numberList.add(new BigNumber("big-3", 70));
    }

    public void AddNumberToList(Number number)
    {
        numberList.add(number);
    }

    public void RemoveNumberFromList(Number number)
    {
        numberList.Remove(number);
    }

    public void Accept()
    {
        foreach (var number in numberList)
        {
            number.Accept();
        }
    }
}