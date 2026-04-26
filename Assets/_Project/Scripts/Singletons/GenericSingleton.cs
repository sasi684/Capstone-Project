using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    private static bool _isApplicationQuitting = false;

    public static T Instance
    {
        get
        {
            if (_isApplicationQuitting) return null;

            CreateOrGetInstance();
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private static void CreateOrGetInstance()
    {
        if (_instance == null)
        {
            _instance = FindAnyObjectByType<T>(FindObjectsInactive.Include);
            if (_instance == null)
            {
                T prefab = Resources.Load<T>("Singletons/" + typeof(T));
                _instance = Instantiate(prefab);
            }
            DontDestroyOnLoad(_instance.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        _isApplicationQuitting = true;
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
