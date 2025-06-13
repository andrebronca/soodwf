interface IVisitor
{
    // A visit operation for SmallNumber class
    void VisitSmallNumbers(SmallNumber number);

    // A visit operation for BigNumber class
    void VisitBigNumbers(BigNumber number);
}