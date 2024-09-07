class GameController
{
    private Minefield minefield;
    private SnifferPup snifferPup;
    private Ally ally;
    private HashSet<(int, int)> visitedPositions;

    public GameController(int rows, int cols)
    {
        minefield = new Minefield(rows, cols);
        snifferPup = new SnifferPup(minefield);
        ally = new Ally();
        visitedPositions = new HashSet<(int, int)>();
    }

    public void StartGame()
    {
        while (snifferPup.X != minefield.Rows - 1 || snifferPup.Y != minefield.Cols - 1)
        {
            minefield.PrintField(snifferPup, ally);

            Console.WriteLine($"Pup is at ({snifferPup.X}, {snifferPup.Y}). Bomb nearby: {snifferPup.DetectBombNearby()}");
            Console.WriteLine($"Ally is at ({ally.X}, {ally.Y})");

            
            int previousPupX = snifferPup.X;
            int previousPupY = snifferPup.Y;

            
            visitedPositions.Add((snifferPup.X, snifferPup.Y));

            
            bool moved = false;
            foreach (var (dx, dy) in new[] { (1, 0), (0, 1), (-1, 0), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1) })
            {
                int newX = snifferPup.X + dx;
                int newY = snifferPup.Y + dy;

                if (minefield.IsSafe(newX, newY) && !visitedPositions.Contains((newX, newY)))
                {
                    if (snifferPup.Move(newX, newY))
                    {
                        moved = true;
                        break;
                    }
                }
            }

            if (moved)
            {
                
                ally.Follow(previousPupX, previousPupY);
            }
            else
            {
                Console.WriteLine("No safe move found. Checking if stuck...");

                
                if (snifferPup.X == previousPupX && snifferPup.Y == previousPupY)
                {
                    Console.WriteLine("Stuck in a position. Game Over!");
                    break; 
                }
            }
        }

        Console.WriteLine("Game Over!");
    }
}