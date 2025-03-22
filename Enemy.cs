namespace MyApp;

internal class Enemy(int y, int x, char pixel) : Movable(y, x, pixel)
{
    private bool _moveToLeft = true;
    
    public override bool NeedAndCanMove(Map map)
    {
        int nextX = X - (_moveToLeft ? 1 : -1);
        char nextPixel = map.GetPixel(Y, nextX);
        if (nextPixel is ' ' or Player.PlayerPixel)
        {
            if (_moveToLeft)
            {
                NextStepX--;
            }
            else
            {
                NextStepX++;
            }

            if (nextPixel is Player.PlayerPixel)
            {
                map.SetGameOver();
            }
            
            return true;
        }
        
        _moveToLeft = !_moveToLeft;
        return false;
    }
}
