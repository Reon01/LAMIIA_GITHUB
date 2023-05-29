using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
