using UnityEngine;

// Custom event system class
public class CEventSystem : MonoBehaviour
{
    private static CEventSystem _Instance;
    public static CEventSystem Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = new GameObject().AddComponent<CEventSystem>();
                _Instance.name = "Object_CustomEventSystem";
                DontDestroyOnLoad(_Instance.gameObject);
            }
            return _Instance;
        }
    }

}
