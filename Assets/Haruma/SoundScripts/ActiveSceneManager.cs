﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveSceneManager : MonoBehaviour
{

    public static bool S_Title = false;
    public static bool S_Tutorial = false;
    public static bool S_Skill = false;
    public static bool S_Boss = false;
    public static bool S_StageSelect = false;

    public static Scene AScene;

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
        AScene = SceneManager.GetActiveScene();
        if (AScene.name == "Scene1_Start")
        {
            S_Title = true;
        }
        else if (AScene.name == "Scene2_Tutorial")
        {
            S_Tutorial = true;
        }
        else if (AScene.name == "Scene3_Tutorial skillcharge bossbattle") 
        {
            S_Skill = true;
        }
        else if (AScene.name == "Scene4_BossStage") 
        {
            S_Boss = true;
        }
        else if (AScene.name == "Scene1.5_StageSelect")
        {
            S_StageSelect = true;
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
        }
        else if (AScene.name == "Scene2_Tutorial")
        {
            S_Tutorial = true;
        }
        else if (AScene.name == "Scene3_Tutorial skillcharge bossbattle")
        {
            S_Skill = true;
        }
        else if (AScene.name == "Scene4_BossStage")
        {
            S_Boss = true;
        }
        else if (AScene.name == "Scene1.5_StageSelect")
        {
            S_StageSelect = true;
        }
    }
}
