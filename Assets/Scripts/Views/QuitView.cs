using System;
using UnityEngine;

public class QuitView:MonoBehaviour
{
    [SerializeField]
    private SceneType _type;

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_type == SceneType.HomeScreen)
                {
                    Application.Quit();
                }
                else
                {
                    SceneLoader.LoadScene(SceneType.HomeScreen);
                }
            }
        }
    }
}
