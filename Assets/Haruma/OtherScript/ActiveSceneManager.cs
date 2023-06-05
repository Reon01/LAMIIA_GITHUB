using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveSceneManager : MonoBehaviour
{

    public static bool S_Title = false;
    public static bool S_Tutorial = false;
    public static bool S_Skill = false;
    public static bool S_Boss = false;

    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.sceneUnloaded += SceneUnloaded;
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void SceneLoaded (Scene nextScene, LoadSceneMode mode)
    {
        Debug.Log("SceneLoaded");
        Scene AScene = SceneManager.GetActiveScene();
        Debug.Log(AScene);
        if (AScene.name == "Scene_Start")
        {
            S_Title = true;
            Debug.Log("AS = Title");
        }
        else if (AScene.name == "Scene_Tutorial")
        {
            S_Tutorial = true;
            Debug.Log("AS = Tutorial");
        }
        else if (AScene.name == "Scene_Tutorial skillcharge bossbattle") 
        {
            S_Skill = true;
            Debug.Log("AS = Scene_Tutorial skillcharge bossbattle");
        }
        else if (AScene.name == "Scene_BossBattle") 
        {
            S_Boss = true;
            Debug.Log("AS = BossBattle");
        }
    }

    void SceneUnloaded (Scene thisScene)
    {
        Debug.Log("SceneUnloaded");
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ÉVÅ[ÉìÇ™êÿÇËë÷ÇÌÇ¡ÇΩÇ∆Ç´Ç…é¿çsÇ≥ÇÍÇÈèàóù
        Debug.Log("OnSceneLoaded");
        Scene AScene = SceneManager.GetActiveScene();
        Debug.Log(AScene);
        if (AScene.name == "Scene_Start")
        {
            S_Title = true;
            Debug.Log("AS = Title");
        }
        else if (AScene.name == "Scene_Tutorial")
        {
            S_Tutorial = true;
            Debug.Log("AS = Tutorial");
        }
        else if (AScene.name == "Scene_Tutorial skillcharge bossbattle")
        {
            S_Skill = true;
            Debug.Log("AS = Scene_Tutorial skillcharge bossbattle");
        }
        else if (AScene.name == "Scene_BossBattle")
        {
            S_Boss = true;
            Debug.Log("AS = BossBattle");
        }
    }
}
