using System.Collections.Generic;
using UnityEngine;

public static class GridGenerator
{
    public static Grid GenerateGrid(int xSize, int ySize)
    {
        // x, y 사이즈가 정상이 아니라면 null 반환
        if (xSize < 0 || ySize < 0)
            return null;
        
        // Size만큼의 Cell을 생성한다.
        Cell[,] cells = new Cell[xSize, ySize];
        for (int i = 0; i < ySize; ++i)
        {
            for (int j = 0; j < xSize; ++j)
            {
                cells[i, j] = new Cell(j, i);
            }
        }
        return new Grid(cells);
    }
}
