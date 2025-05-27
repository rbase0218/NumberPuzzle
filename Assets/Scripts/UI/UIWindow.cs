using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIWindow : UIBase
{
    public override bool Initialized()
    {
        if (base.Initialized() == false)
            return false;

        return true;
    }
}