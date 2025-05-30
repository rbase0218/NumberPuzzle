using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    // 정사각형인가?
    private bool _isSquare;
    // Grid의 Size가 몇인가?
    private Vector2 _size;

    private Cell[,] _cells;
    
    public Grid() {}

    public Grid(Cell[,] cells)
    {
        _cells = cells;
    }
}
