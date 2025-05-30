using UnityEngine;

public static class Utils
{
    public static T TryGetOrAdd<T>(GameObject obj) where T : Component
    {
        if (obj.TryGetComponent(out T component) == false)
        {
            component = obj.AddComponent<T>();
        }
        
        return component;
    }
    
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
        {
            return null;
        }
        
        if (recursive == false)
        {
            Transform transform = go.transform.Find(name);
            
            if (transform != null)
            {
                return transform.GetComponent<T>();
            }
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>(true))
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                {
                    return component;
                }
            }
        }

        return null;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform != null)
        {
            return transform.gameObject;
        }

        return null;
    }
}
