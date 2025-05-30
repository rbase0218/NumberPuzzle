using UnityEngine;

public class UITitleScreen : UIScreen
{
    public override bool Initialized()
    {
        if (base.Initialized() == false)
            return false;

        var currScreen = Managers.Instance.uiManager.CurrentScreen;
        currScreen.ShowWindow<UITitleWindow>("TitleGroup");
        
        return true;
    }
}
