using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class BGMplayer : MonoBehaviour
{
    public bool dontDestroyOnLoad = true;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private AtomLoader atomLoader;

    void Awake()
    {
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if (ActiveSceneManager.S_Title == true)
        {
            playerController.BGMStop();
            playerController.Stop();
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Title_BGM");
            playerController.BGMPlay();
            ActiveSceneManager.S_Title = false;
        }
        if (ActiveSceneManager.S_Tutorial == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Tutorial_BGM");
            playerController.BGMPlay();
            ActiveSceneManager.S_Tutorial = false;
            Debug.Log("Playing Tutorial_BGM");
        }
        else if (ActiveSceneManager.S_Skill == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Skill_BGM");
            playerController.BGMPlay();
            ActiveSceneManager.S_Skill = false;
            Debug.Log("Playing Skill_BGM");
        }
        else if (ActiveSceneManager.S_Boss == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Skill_BGM");
            playerController.BGMPlay();
            ActiveSceneManager.S_Boss = false;
            Debug.Log("Playing Skill_BGM for Scene_BossStage");
        }
    }
}
