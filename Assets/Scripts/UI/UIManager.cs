using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private const string UIPath = @"Prefab/UI/Screen/";
    private const string UIRoot = "UI_Root";
    
    private Stack<UIScreen> _screenStack = new Stack<UIScreen>();
    private Dictionary<Type, UIScreen> _screenDic = new Dictionary<Type, UIScreen>();

    public UIScreen CurrentScreen
    {
        get;
        private set;
    }

    public GameObject Root
    {
        get
        {
            var root = GameObject.Find(UIRoot);
            if (root == null)
            {
                root = new GameObject(UIRoot);
            }
            return root;
        }
    }
    
    // UI Screen은 Prefab 단위로 관리하자.
    // UI Screen이 Load되면 UnLoad는 Remove가 아니라 Object Pool에 개체들 둔다.
    
    /*
     [Popup UI]
     UIScreen에서 관리할 수 있도록 한다.
     */
    
    public T ShowScreen<T>(string name = null) where T : UIScreen
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        T component = null;
        
        if (_screenDic.ContainsKey(typeof(T)))
        {
            component = _screenDic[typeof(T)] as T;
            component?.gameObject.SetActive(true);
        }
        else
        {
            GameObject gameObj = Resources.Load<GameObject>(UIPath + name);
            GameObject ui = Instantiate(gameObj, Root.transform, true);

            component = Utils.TryGetOrAdd<T>(ui);
            _screenDic.TryAdd(typeof(T), component);
        }

        _screenStack.Push(component);
        CurrentScreen = component;
        
        CurrentScreen?.Initialized();

        return component;
    }

    public void HideScreen()
    {
        if (_screenStack.Count == 0)
            return;
        
        var screen = _screenStack.Pop();
        screen.gameObject.SetActive(false);
    }

    public T FindScreen<T>() where T : UIScreen
    {
        return _screenDic[typeof(T)] as T;
    }

    public void SetScreenOrder<T>()
    {
        
    }
}