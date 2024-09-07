class Minefield
{
    private int[,] field;
    public int Rows { get; private set; }
    public int Cols { get; private set; }

    public Minefield(int rows, int cols)
    {
        this.Rows = rows;
        this.Cols = cols;
        field = new int[rows, cols];
        GenerateMinefield();
    }

    private void GenerateMinefield()
    {
        Random rand = new Random();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                field[i, j] = rand.Next(0, 4) == 0 ? 1 : 0;
            }
        }
        field[0, 0] = 0;
        field[Rows - 1, Cols - 1] = 0;
    }

    public bool IsSafe(int x, int y)
    {
        if (x < 0 || x >= Rows || y < 0 || y >= Cols) return false;
        return field[x, y] == 0;
    }

    public void PrintField(SnifferPup pup, Ally ally)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (i == pup.X && j == pup.Y)
                    Console.Write("P "); 
                else if (i == ally.X && j == ally.Y)
                    Console.Write("A "); 
                else
                    Console.Write(field[i, j] == 0 ? "√ " : "X ");
            }
            Console.WriteLine();
        }
    }
}
