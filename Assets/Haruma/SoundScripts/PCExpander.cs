using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;


public class PCExpander : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    //ボス用
    public static bool bossObjChk = false;

    void Start(){
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
    }

    //ボスのボイス再生
    void Update(){
        if(bossObjChk == false && BossVoice.VoiceActFrag == true){
            StopCoroutine(BossVoice.voiceRondomize);
            Debug.Log("VoiceStop");
            BossVoice.VoiceActFrag = false;
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
