using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;


public class PCExpander : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    //ボス用
    public static GameObject bossObj;
    public static bool bossObjChk = false;

    void Start(){
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
    }

    void Update(){
        if(bossObjChk == true && bossObj == null){
            bossObj = GameObject.Find("Boss_kansei");
        }
    }

    public void SetVolume_as(float vol)
    {
        GameObject SoundObject = GameObject.Find("AudioManager");
        if (SoundObject != null)
        {
            playerController.SetVolume(vol);
        }
    }
}
