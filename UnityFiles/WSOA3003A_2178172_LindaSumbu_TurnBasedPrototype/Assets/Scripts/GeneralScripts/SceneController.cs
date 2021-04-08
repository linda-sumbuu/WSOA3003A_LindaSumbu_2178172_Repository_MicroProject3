using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static string prevScene = "ExploreGameMode";
    public static string currentScene = "BattleMode";

    public virtual void Start()
    {
        // Meant to be extended/overwritten by a scene script
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneName)
    {
        prevScene = currentScene;
        SceneManager.LoadScene(sceneName);

    }
}
