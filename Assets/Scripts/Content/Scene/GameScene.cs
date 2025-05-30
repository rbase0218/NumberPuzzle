using UnityEngine;

public class GameScene : SceneBase
{
    [SerializeField] private MapManager mapManager;
    
    protected override bool Initialized()
    {
        if (base.Initialized() == false)
            return false;

        // 데이터는 나중에 S.O 데이터로 연결하기
        mapManager.GenerateMap(4, 4, 4);
        Managers.Instance.uiManager.ShowScreen<UIGameScreen>();
        
        return true;
    }
}