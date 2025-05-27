using System;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : UIBase
{
    // UI Window는 이미 UIScreen의 Prefab 안에 포함되어 있다.
    private Dictionary<Type, UIWindow> _windowDic = new Dictionary<Type, UIWindow>();
    
    // 현재 Screen이 몇번째 순서인가.
    private int _sortOrder = 0;
    // 현재 Screen의 고정 여부 
    private bool _fixedWindow = false;
    
    public override bool Initialized()
    {
        if (base.Initialized() == false)
            return false;
        
        _windowDic.Clear();
        
        return true;
    }

    public T ShowWindow<T>() where T : UIWindow
    {
        T component = null;
        if (_windowDic.ContainsKey(typeof(T)))
        {
            component = _windowDic[typeof(T)] as T;
            component?.gameObject.SetActive(true);
            
            component?.Initialized();
        }
        else
        {
            Debug.LogError($"{typeof(T).Name}은 존재하지 않습니다.");
        }
        
        return component;
    }

    public void HideWindow<T>()
    {
        _windowDic[typeof(T)].gameObject.SetActive(false);
    }

    public T FindWindow<T>() where T : UIWindow
    {
        return _windowDic[typeof(T)] as T;
    }
}
