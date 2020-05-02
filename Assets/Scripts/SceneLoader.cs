using System;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadScene(SceneType name)
    {
        SceneManager.LoadScene(name.ToString());
    }
}

public enum SceneType
{
    RocketGame,
    PlaneGame,
    HomeScreen
}
