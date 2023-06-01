using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSceneAutoLoader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadManagerScene()
    {
        string managerSceneName = "ManagerScene";
        if (!SceneManager.GetSceneByName(managerSceneName).IsValid())
        {
            SceneManager.LoadScene(managerSceneName, LoadSceneMode.Additive);
        }
    }
}