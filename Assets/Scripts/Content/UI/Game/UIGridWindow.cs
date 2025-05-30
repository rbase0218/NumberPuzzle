using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGridWindow : UIWindow
{
    private UICell[,] _cells;
    private GameObject _cellPrefab;

    private GridLayoutGroup _gridLayout;
    
    public override bool Initialized()
    {
        if (base.Initialized() == false)
        {
            return false;
        }
        
        init = true;
        
        return init;
    }

    public void MakeGrid(int xSize, int ySize)
    {
        for (int i = 0; i < ySize; ++i)
        {
            for (int j = 0; j < xSize; ++j)
            {
                var cell = Instantiate(_cellPrefab, transform, true);
                _cells[i, j] = Utils.TryGetOrAdd<UICell>(cell);
            }
        }
    }
}
