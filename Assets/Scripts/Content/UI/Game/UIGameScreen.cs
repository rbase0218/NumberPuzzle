using UnityEngine;

public class UIGameScreen : UIScreen
{
    public override bool Initialized()
    {
        if (base.Initialized() == false)
            return false;
        
        // Grid의 정보를 가져와서 Grid 생성해주기
        var currentScreen = Managers.Instance.uiManager.CurrentScreen;
        currentScreen.ShowWindow<UIGrid>();
        
        return true;
    }
}
