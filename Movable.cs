namespace MyApp;

internal abstract class Movable()
{
    protected int _x;
    public int X => _x;

    
    protected int _y;
    public int Y => _y;

    private char _pixel;
    public char Pixel => _pixel;
    
    protected int NextStepX = 0;
    
    protected int NextStepY = 0;

    protected Movable(int y, int x, char pixel) : this()
    {
        _y = y;
        _x = x;
        _pixel = pixel;
    }

    public abstract bool NeedAndCanMove(Map map);

    public  void Move()
    {
        _x += NextStepX;
        _y += NextStepY;
        NextStepX = 0;
        NextStepY = 0;
    }
}
