namespace MyApp;

internal class ConsoleRenderer(Map map)
{
    public static void SetCursorInvisible()
    {
        Console.CursorVisible = false;
    }

    public void Render()
    {
        map.Render();
    }
}
