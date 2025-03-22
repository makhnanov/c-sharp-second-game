namespace MyApp;

internal static class Program
{
    static Program()
    {
        ConsoleRenderer.SetCursorInvisible();
        Console.Clear();
    }

    private static void Main()
    {
        Map map = new Map();
        
        map.AddMovable(new Player(1, 1, '@'));
        // map.AddMovable(new Enemy(Map.Rows - 2, Map.Columns - 2, '*'));
        map.AddMovable(new Enemy(Map.Rows - 2, 10, '*'));
            
        ConsoleRenderer renderer = new ConsoleRenderer(map);

        while (true)
        {
            map.MoveMovables();
            renderer.Render();
            if (map.GameOver())
            {
                break;
            }
            Thread.Sleep(50);
        }   
    }
}
