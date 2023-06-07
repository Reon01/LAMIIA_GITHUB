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
        if (Kajiki.Kajiki_Sound == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Sf");
            playerController.Play();
            Kajiki.Kajiki_Sound = false;
            Debug.Log("KajikiSound");
        }

        if (mori.Mori_Sound == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("attack_Hrpn");
            playerController.Play();
            mori.Mori_Sound = false;
            Debug.Log("HrpnSound");
        }
        if (Kurage.Kurage_Sound == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Jf");
            playerController.Play();
            Kurage.Kurage_Sound = false;
            Debug.Log("KurageSound");
        }
    }
}
