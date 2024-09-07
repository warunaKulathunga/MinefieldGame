class SnifferPup
{
    public int X { get; private set; }
    public int Y { get; private set; }
    private Minefield minefield;

    public SnifferPup(Minefield minefield)
    {
        this.minefield = minefield;
        X = 0;
        Y = 0;
    }

    public bool Move(int newX, int newY)
    {
        if (minefield.IsSafe(newX, newY))
        {
            X = newX;
            Y = newY;
            return true;
        }
        return false;
    }

    public bool DetectBombNearby()
    {
        int[] dx = { -1, -1, -1, 0, 1, 1, 1, 0 };
        int[] dy = { -1, 0, 1, 1, 1, 0, -1, -1 };

        for (int i = 0; i < 8; i++)
        {
            int newX = X + dx[i];
            int newY = Y + dy[i];
            if (!minefield.IsSafe(newX, newY))
            {
                return true;
            }
        }
        return false;
    }
}
