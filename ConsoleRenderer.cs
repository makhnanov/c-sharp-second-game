using System.Diagnostics;

namespace MyApp;

internal class ConsoleRenderer(Map map)
{
    private const int MaxScreen = 500;
    private const char Block = '\u2588';

    private int _lastWindowWidth;
    private int _lastWindowHeight;
    
    private char[,] _lastRender = new char[MaxScreen, MaxScreen];
    public static void SetCursorInvisible()
    {
        Console.CursorVisible = false;
    }

    public void Render()
    {
        if (_lastWindowWidth != Console.WindowWidth)
        {
            _lastWindowWidth = Console.WindowWidth;
            _lastRender = new char[500, 500];
            Console.Clear();
        }
        if (_lastWindowHeight != Console.WindowHeight)
        {
            _lastWindowHeight = Console.WindowHeight;
            _lastRender = new char[500, 500];
            Console.Clear();
        }
        
        bool isHeightValid = IsValidScreenHeight();
        bool isWidthValid = IsValidScreenWidth();
        if (!isHeightValid || !isWidthValid)
        {
            return;
        }

        int height = Console.WindowHeight;
        int width = Console.WindowWidth;
        
        int heightDiffOnePart = (height - Map.Rows) / 2;

        int commonY = 0;
        if (heightDiffOnePart > 0)
        {
            for (int h = 0; h < heightDiffOnePart; h++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (_lastRender[commonY, x] != Block) 
                    {
                        _lastRender[commonY, x] = Block;
                        Console.SetCursorPosition(x, commonY);
                        Console.Write(Block);
                    }
                }

                commonY++;
                // Console.WriteLine();
            }
        }
        
        int widthDiffOnePart = (width - Map.Columns) / 2;
        
        for (int mapY = 0; mapY < Map.Rows; mapY++)
        {
            int commonX = 0;
            for (int y = 0; y < widthDiffOnePart; y++)
            {
                if (_lastRender[commonY, commonX] != Block)
                {
                    _lastRender[commonY, commonX] = Block;
                    Console.SetCursorPosition(commonX, commonY);
                    Console.Write(Block);
                }
            
                commonX++;
            }
        
            if (widthDiffOnePart + widthDiffOnePart + Map.Columns < Console.WindowWidth)
            {
                if (_lastRender[commonY, commonX] != Block)
                {
                    _lastRender[commonY, commonX] = Block;
                    Console.SetCursorPosition(commonX, commonY);
                    Console.Write(Block);
                }
                commonX++;
            }
            
            for (int mapX = 0; mapX < Map.Columns; mapX++)
            {
                char mapPixel = map.GetPixel(mapY, mapX);
                if (mapPixel == '#')
                {
                    mapPixel = '\u2593';
                }
                if (_lastRender[commonY, commonX] != mapPixel)
                {
                    _lastRender[commonY, commonX] = mapPixel;
                    Console.SetCursorPosition(commonX, commonY);
                    Console.Write(mapPixel);
                }
                commonX++;
            }
            
            for (int y = 0; y < widthDiffOnePart; y++)
            {
                if (_lastRender[commonY, commonX] != Block)
                {
                    _lastRender[commonY, commonX] = Block;
                    Console.SetCursorPosition(commonX, commonY);
                    Console.Write(Block);
                }
            
                commonX++;
            }
            
            commonY++;
        }
        
        if (heightDiffOnePart > 0)
        {
            for (int h = 0; h < heightDiffOnePart; h++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (_lastRender[commonY, x] != Block) 
                    {
                        _lastRender[commonY, x] = Block;
                        Console.SetCursorPosition(x, commonY);
                        Console.Write(Block);
                    }
                }

                commonY++;
            }
        }
    }

    private bool IsValidScreenWidth()
    {
        int width = Console.WindowWidth;
        if (width < Map.Columns)
        {
            Console.WriteLine($"Console width must be greater than or equal to {Map.Columns}. Now: {width}");
            return false;
        }
        return true;
    }
    
    private bool IsValidScreenHeight()
    {
        int height = Console.WindowHeight;
        if (height < Map.Rows)
        {
            Console.WriteLine($"Console height must be greater than or equal to {Map.Rows}. Now: {height}");
            return false;
        }
        return true;
    }
}
