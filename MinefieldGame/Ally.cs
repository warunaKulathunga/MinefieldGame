class Ally
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Ally()
    {
        X = -1; 
        Y = -1;
    }

    public void Follow(int previousPupX, int previousPupY)
    {
        X = previousPupX;
        Y = previousPupY;
    }
}
