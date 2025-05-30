using UnityEngine;

public class UITitleScreen : UIScreen
{
    public override bool Initialized()
    {
        if (base.Initialized() == false)
            return false;
        
        return true;
    }
}
