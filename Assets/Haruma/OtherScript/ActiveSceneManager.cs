using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveSceneManager : MonoBehaviour
{

    public int n_Scene;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �V�[�����؂�ւ�����Ƃ��Ɏ��s����鏈��
        if (scene.name == "Scene_Start")
        {
            n_Scene = 0;
        }
        else if (scene.name == "Scene_Tutorial")
        {
            n_Scene = 1;
        }
        else if (scene.name == "Scene_Tutorial skillcharge bossbattle")
        {
            n_Scene = 2;
        }
        else if (scene.name == "Scene_BossBattle")
        {
            n_Scene = 3;
        }
    }
}
