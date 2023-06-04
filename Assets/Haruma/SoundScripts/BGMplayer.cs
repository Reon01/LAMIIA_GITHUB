using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class BGMplayer : MonoBehaviour
{
    //n_SceneÇÃî‘çÜÇ…ÇÊÇ¡ÇƒBGMÇçƒê∂
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private AtomLoader atomLoader;

    public ActiveSceneManager ASManager;

    void Start()
    {
        int n_SceneValue = ASManager.n_Scene;
        
        if(n_SceneValue == 0)
        {
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Title_BGM");
            Debug.Log("Title_BGM");
            playerController.Play();
        }
        else if (n_SceneValue == 1)
        {
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Tutorial_BGM");
            Debug.Log("Tutorial_BGM");
            playerController.Play();
        }
    }

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
}
