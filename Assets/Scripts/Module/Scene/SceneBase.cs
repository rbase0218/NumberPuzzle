using UnityEngine;

public class SceneBase : MonoBehaviour
{
    protected bool init = false;

    private void Awake()
    {
        Initialized();
    }

    protected virtual bool Initialized()
    {
        if (init)
        {
            return false;
        }
        init = true;
        
        return init;
    }
}
