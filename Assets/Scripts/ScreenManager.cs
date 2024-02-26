using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        DontDestroyOnLoad(gameObject);
    }
}
