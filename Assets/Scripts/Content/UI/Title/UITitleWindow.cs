using UnityEngine;

public class UITitleWindow : UIWindow
{
    public override bool Initialized()
    {
        if (base.Initialized() == false)
            return false;
        return true;
    }
}
