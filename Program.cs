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
        ConsoleRenderer renderer = new ConsoleRenderer(map);
        
        while (true)
        {
            renderer.Render();
            map.SetPixel();
            // map.Render();
            // map.SetPixel();
        }
    }
}
