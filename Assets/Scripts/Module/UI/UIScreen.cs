using System;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : UIBase
{
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

    public T ShowWindow<T>(string name = null) where T : UIWindow
    {
        T component = null;
        if (_windowDic.ContainsKey(typeof(T)))
        {
            component = _windowDic[typeof(T)] as T;
        }
        else
        {
            // 생성할 필요 없이, 하단에 있는 컴포넌트를 찾으면 된다.
            component = Utils.FindChild<T>(gameObject, name, true);
            _windowDic.TryAdd(typeof(T), component);
        }
        
        component?.gameObject.SetActive(true);
        component?.Initialized();
        
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
