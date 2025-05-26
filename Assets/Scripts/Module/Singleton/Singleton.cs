using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers _instance;
    public static Managers Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Managers>();

                if (_instance == null)
                {
                    var go = new GameObject(nameof(Managers)).AddComponent<Managers>();
                    _instance = go;
                    DontDestroyOnLoad(_instance.gameObject);
                    
                    _instance.Initialized();
                }
            }
            
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance.gameObject);
            
            Initialized();
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private bool initialized = false;
    
    private void Initialized()
    {
        if (initialized)
            return;
        initialized = true;
        
        // 함수 초기화를 위한 영역
    }
}
