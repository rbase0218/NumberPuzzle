using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBase : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    protected bool _init = false;

    public virtual bool Initialized()
    {
        if (_init)
        {
            return false;
        }
        _init = true;
        
        return _init;
    }

    private void Start()
    {
        Initialized();
    }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Utils.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Utils.FindChild<T>(gameObject, names[i], true);
            }
        }
    }

    protected void BindObject(Type type)
    {
        Bind<GameObject>(type);
    }
    protected void BindImage(Type type)
    {
        Bind<Image>(type);
    }
    protected void BindText(Type type)
    {
        Bind<TextMeshProUGUI>(type);
    }
    protected void BindButton(Type type)
    {
        Bind<Button>(type);
    }
    
    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
        {
            return null;
        }
        return objects[idx] as T;
    }

    protected GameObject GetObject(int idx)
    {
        return Get<GameObject>(idx);
    }
    protected TextMeshProUGUI GetText(int idx)
    {
        return Get<TextMeshProUGUI>(idx);
    }
    protected Button GetButton(int idx)
    {
        return Get<Button>(idx);
    }
    protected Image GetImage(int idx)
    {
        return Get<Image>(idx);
    }
}
