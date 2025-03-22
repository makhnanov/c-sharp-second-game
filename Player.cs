namespace MyApp;

internal class Player(int y, int x, char pixel) : Movable(y, x, pixel)
{
    public const char PlayerPixel = '@';
    public override bool NeedAndCanMove(Map map)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            int x = 0;
            int y = 0;
            
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                
                case ConsoleKey.DownArrow:
                    y++;
                    break;

                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                
                case ConsoleKey.RightArrow:
                    x++;
                    break;
                
                default:
                    return false;
            }

            if (map.GetPixel(Y + y, X + x) != ' ')
            {
                return false;
            }
            
            NextStepX += x;
            NextStepY += y;
            
            return true;
        }
        return false;
    }
}
