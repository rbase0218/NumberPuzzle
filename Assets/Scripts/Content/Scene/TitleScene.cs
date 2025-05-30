using UnityEngine;

public class TitleScene : SceneBase
{
    protected override bool Initialized()
    {
        if (base.Initialized() == false)
            return false;

        Managers.Instance.uiManager.ShowScreen<UITitleScreen>();
        return true;
    }
}
