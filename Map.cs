namespace MyApp;

internal class Map
{
    private const string MapFilePath = "Map.txt";
    public const int Rows = 40;
    public const int Columns = 180;
    private readonly char[,] _mapInit = new char[Rows, Columns];
    private readonly char[,] _map = new char[Rows, Columns];
    private List<Movable> _movables = new();

    private bool _gameOver = false;
    
    public Map()
    {
        FillMapsFromFile(MapFilePath);
    }

    private void FillMapsFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
    
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Columns; x++)
            {
                char pixel = lines[y][x];
                _map[y, x] = pixel;
                _mapInit[y, x] = pixel;
            }
        }
    }

    public void SetPixel(int x, int y, char pixel)
    {
        _map[x, y] = pixel;
    }

    public char GetPixel(int x, int y)
    {
         return _map[x, y];
    }

    public void AddMovable(Movable movable)
    {
        if (_map[movable.Y, movable.X] != ' ')
        {
            throw new Exception($"Cant add movable to X: {movable.X} Y: {movable.Y} !");
        }
        SetPixel(movable.Y, movable.X, movable.Pixel);
        _movables.Add(movable);
    }

    public void MoveMovables()
    {
        foreach (Movable movable in _movables)
        {
            if (movable.NeedAndCanMove(this))
            {
                SetPixel(movable.Y, movable.X, _mapInit[movable.Y, movable.X]);
                movable.Move();
                SetPixel(movable.Y, movable.X, movable.Pixel);
            }
        }
    }

    public bool GameOver()
    {
        if (!_gameOver)
        {
            return false;
        }
        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.WriteLine("Game Over! You die & lost!");
        return true;
    }

    public void SetGameOver()
    {
        _gameOver = true;
    }
}
