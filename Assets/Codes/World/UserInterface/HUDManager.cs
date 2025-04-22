using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private static HUDManager _Instance;
    public static HUDManager Instance
    {

        get 
        { 
            if (_Instance == null)
            {
                _Instance = new GameObject().AddComponent<HUDManager>();
                _Instance.name = "HUDManager";
                DontDestroyOnLoad(_Instance);
            }
            return _Instance;
        } 
    }

}
