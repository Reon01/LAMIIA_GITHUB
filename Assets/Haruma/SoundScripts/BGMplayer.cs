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

    void Awake(){
        if (dontDestroyOnLoad){
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    void Start(){}

    // Update is called once per frame
    void Update(){
        /*
        if (ActiveSceneManager.S_Title == true){
            //BGMや効果音の停止
            playerController.Stop();
            playerController.BGMStop();
            playerController.KurageStop();
            playerController.EEStop();

            ActiveSceneManager.S_Title = false;
        }
        */
        if (ActiveSceneManager.S_Tutorial == true){
            //ラジオ用変数変化
            if(SFXplayer.radio_Sound == 0){
                SFXplayer.radio_Sound = 1;
            }
            //BGM再生
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Tutorial_BGM");
            playerController.BGMPlay();
            ActiveSceneManager.S_Tutorial = false;
        }
        else if (ActiveSceneManager.S_Skill == true){
            //ラジオ用変数変化
            if(SFXplayer.radio_Sound == 0){
                SFXplayer.radio_Sound = 1;
            }
            //BGM再生
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Skill_BGM");
            playerController.BGMPlay();
            ActiveSceneManager.S_Skill = false;
        }
        else if (ActiveSceneManager.S_Boss == true){
            playerController.SetAcb(atomLoader.acbAssets[0].Handle);
            playerController.SetCueName("Boss_BGM");
            playerController.BGMPlay();
            ActiveSceneManager.S_Boss = false;
        }
        //BGM用AISAC値の変更
        if(BossVoice.lowhpObs == 1){
            playerController.SetAcb(atomLoader.acbAssets[3].Handle);
            playerController.SetCueName("act_bossBGM21");
            playerController.Play();
            BossVoice.lowhpObs = 2;
            Debug.Log("AISAC Changed 21");
        }
    }
    //フェードイン・アウト用コルーチン
    /*
    private IEnumerator FadeIn_Out(string nextmusic){
        playerController.SetAcb(atomLoader.acbAssets[3].Handle);
        playerController.SetCueName("FadeOut");
        playerController.Play();
        
        yield return new WaitForSeconds(0.7f);
        
        playerController.SetAcb(atomLoader.acbAssets[0].Handle);
        playerController.SetCueName(nextmusic);
        playerController.BGMPlay();
        playerController.SetAcb(atomLoader.acbAssets[3].Handle);
        playerController.SetCueName("FadeIn");
        playerController.Play();
    }
    */
}
