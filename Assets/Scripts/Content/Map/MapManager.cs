using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Grid 데이터 정보
    private Grid _grid;

    public void GenerateMap(int xSize, int ySize, int level)
    {
        // Grid에 새로운 Data를 할당하기.
        _grid = GridGenerator.GenerateGrid(xSize, ySize);
        
        // 레벨을 붙여서 받아서 값을 Cell에 넣어주기.
        // xSize, ySize 다 있으니까. 분석해서 추가해주면 될듯!
    }
}
