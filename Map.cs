namespace MyApp;

internal class Map
{
    private const string MapFilePath = "Map.txt";
    private const int Rows = 40;
    private const int Columns = 180;
    private readonly char[,] _map = new char[Rows, Columns];
    
    public Map()
    {
        ReadMapFromFile(MapFilePath);
    }

    public void Render()
    {
        for (int x = 0; x < _map.GetLength(0); x++)
        {
            for (int y = 0; y < _map.GetLength(1); y++)
            {
                Console.Write(_map[x, y]);            
            }
            Console.WriteLine();            
        }
    }

    private void ReadMapFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
    
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Columns; x++)
            {
                _map[y, x] = lines[y][x];
            }
        }
    }

    public void SetPixel()
    {
        _map[5, 5] = 'd';
    }
}
