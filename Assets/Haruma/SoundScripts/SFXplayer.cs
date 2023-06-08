using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class SFXplayer : MonoBehaviour
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

    void Start()
    {

    }
    void Update()
    {
        //メニューSFX
        if (GameStart.menu_Sound == 1){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("menu_Confirm");
            playerController.Play();
            GameStart.menu_Sound = 0;
            Debug.Log("Confirm");
        }
        if (GameStart.menu_Sound == 2){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("menu_Back");
            playerController.Play();
            GameStart.menu_Sound = 0;
            Debug.Log("Back");
        }
        //スキル＆銛
        if (mori.Mori_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("attack_Hrpn");
            playerController.Play();
            mori.Mori_Sound = false;
            Debug.Log("HrpnSound");
        }
        if (Kajiki.Kajiki_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Sf");
            playerController.Play();
            Kajiki.Kajiki_Sound = false;
            Debug.Log("KajikiSound");
        }
        if (Kurage.Kurage_Sound_s == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Jf");
            playerController.Play();
            Kurage.Kurage_Sound_s = false;
            Debug.Log("KurageSound_s");
        }
        if (Kurage.Kurage_Sound_e == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Jf");
            playerController.Play();
            Kurage.Kurage_Sound_e = false;
            Debug.Log("KurageSound_e");
        }
    }
}