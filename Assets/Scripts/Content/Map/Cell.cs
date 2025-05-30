using UnityEngine;

public class Cell
{
    private int _x, _y;
    private int _number;

    private Color _cellColor;

    public Cell(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void Initialized(int num, int x = -1, int y = -1)
    {
        if (x != -1 && y != -1)
        {
            _x = x;
            _y = y;
        }
        _number = num;
    }

    public void Clear()
    {
        _x = _y = _number = -1;
    }

    public Color GetCellColor()
    {
        return _cellColor;
    }
}
