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

    //シーン切り替わり検知の準備
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //シーンロード時に変数をTrueに変更
    void SceneLoaded (Scene nextScene, LoadSceneMode mode)
    {
        Debug.Log("SceneLoaded");
        Scene AScene = SceneManager.GetActiveScene();
        if (AScene.name == "Scene1_Start")
        {
            S_Title = true;
            Debug.Log("AS = Title");
        }
        else if (AScene.name == "Scene2_Tutorial")
        {
            S_Tutorial = true;
            Debug.Log("AS = Tutorial");
        }
        else if (AScene.name == "Scene3_Tutorial skillcharge bossbattle") 
        {
            S_Skill = true;
            Debug.Log("AS = Scene_Tutorial skillcharge bossbattle");
        }
        else if (AScene.name == "Scene4_BossBattle") 
        {
            S_Boss = true;
            Debug.Log("AS = BossBattle");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーンが切り替わったときに実行される処理
        Debug.Log("OnSceneLoaded");
        Scene AScene = SceneManager.GetActiveScene();
        if (AScene.name == "Scene1_Start")
        {
            S_Title = true;
            Debug.Log("AS = Title");
        }
        else if (AScene.name == "Scene2_Tutorial")
        {
            S_Tutorial = true;
            Debug.Log("AS = Tutorial");
        }
        else if (AScene.name == "Scene3_Tutorial skillcharge bossbattle")
        {
            S_Skill = true;
            Debug.Log("AS = Scene_Tutorial skillcharge bossbattle");
        }
        else if (AScene.name == "Scene4_BossBattle")
        {
            S_Boss = true;
            Debug.Log("AS = BossBattle");
        }
    }
}
