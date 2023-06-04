using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CriWare;

public class BGMplayer : MonoBehaviour
{
    public bool dontDestroyOnLoad = true;

    void Awake()
    {
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    void Start()
    {
        //シーンアクティブを検知するデリゲートの登録
        SceneManager.activeSceneChanged += ActiveSceneChanged;
        Scene scene_Tutorial = SceneManager.GetSceneByName("Scene_Tutorial");
        Scene scene_Tutorialskillchargebossbattle = SceneManager.GetSceneByName("Scene_Tutorialskillchargebossbattle");

    }

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private AtomLoader atomLoader;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Tutorial_BGM");
            playerController.Play();
        }
    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        if(nextScene == SceneManager.GetSceneByName("Scene_Tutorial"))
        {
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Tutorial_BGM");
            playerController.Play();
        }
    }
}
