﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using UnityEngine.InputSystem;

public class SFXplayer : MonoBehaviour
{
    //InputSystem
    private PlayerInput playerInput;
    private InputAction inputAction;
    //移動を検出する変数
    public static bool isPlayerMoving_S;
    public static bool isMovSdPlaying_S;
    //回避用変数
    public static bool Step_Soud;
    //カジキ用変数
    public static int Sf_Sound;
    public static bool c_Sf_S;
    public static bool isSf_act;
    //クラゲ用
    public static bool isJf_act;
    public static bool c_Jf_S;
    //ウナギ用変数
    public static bool isUnagi_act;
    public static bool c_Unagi_S = false;
    //ハリセンボン用変数
    public static int ppf_Sound;
    //ダメージ用変数
    public static int damaged_Sound_E;
    //ラジオ用変数
    public static int radio_Sound;
    public static bool radio_Sound_obs;
    //スキル切り替え用変数
    public static bool skillChange_Sound;
    //Dont Destroy On Load
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

    void Start(){
        if(ActiveSceneManager.S_Title != true && ActiveSceneManager.S_StageSelect != true){
            playerInput = GameObject.Find("PlayerInput").GetComponent<PlayerInput>();
            inputAction = playerInput.actions.FindAction("Fire");
        }
    }

    void Update(){
        //メニュー系SFX
        if (GameStart.menu_Sound == 1){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("menu_Confirm");
            playerController.MenuSFXPlay();
            GameStart.menu_Sound = 0;
        }
        if (GameStart.menu_Sound == 2){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("menu_Back");
            playerController.MenuSFXPlay();
            GameStart.menu_Sound = 0;
        }
        if (GameStart.menu_Sound == 3){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("menu_Selecting");
            playerController.MenuSFXPlay();
            GameStart.menu_Sound = 0;
        }
        //ジングル
        if (GameStart.menu_Sound == 4){
            playerController.SetAcb(atomLoader.acbAssets[1].Handle);
            playerController.SetCueName("Start_JINGLE");
            playerController.MenuSFXPlay();
            GameStart.menu_Sound = 0;
        }
        if (GameStart.menu_Sound == 5){
            playerController.SetAcb(atomLoader.acbAssets[1].Handle);
            playerController.SetCueName("Clear_JINGLE");
            playerController.MenuSFXPlay();
            GameStart.menu_Sound = 0;
        }
        //ラジオ
        if (radio_Sound == 1){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("radio");
            playerController.Play();
            radio_Sound = 2;
        }
        if (radio_Sound == 2 && radio_Sound_obs == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("radio_next");
            playerController.Play();
            radio_Sound_obs = false;
        }
        if (radio_Sound == 3){
            //ラジオ終了の音を追加予定
            /*
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("radio_next");
            playerController.Play();
            */
            radio_Sound = 0;
        }
        //スキル切り替え
        if(skillChange_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_equip");
            playerController.Play();
            skillChange_Sound = false;
        }
        //スキルの空撃ち
        if(ActiveSceneManager.AScene.name == "Scene2_Tutorial" ||
         ActiveSceneManager.AScene.name == "Scene3_Tutorial skillcharge bossbattle" ||
         ActiveSceneManager.AScene.name == "Scene4_BossStage"){
            if(inputAction.WasPressedThisFrame()){
                if(isUnagi_act == true && c_Unagi_S == false){
                    playerController.SetAcb(atomLoader.acbAssets[2].Handle);
                    playerController.SetCueName("skill_noAmmo");
                    playerController.Play();
                }
                if(isSf_act == true && c_Sf_S == false){
                    playerController.SetAcb(atomLoader.acbAssets[2].Handle);
                    playerController.SetCueName("skill_noAmmo");
                    playerController.Play();
                }
                if(isJf_act == true && c_Jf_S == false){
                    playerController.SetAcb(atomLoader.acbAssets[2].Handle);
                    playerController.SetCueName("skill_noAmmo");
                    playerController.Play();
                }
            }
        }
        //移動中効果音
        if(isPlayerMoving_S == true){
            if(isMovSdPlaying_S == false){
                playerController.SetAcb(atomLoader.acbAssets[2].Handle);
                playerController.SetCueName("swimmming");
                playerController.MovingSFXPlay();
                StartCoroutine(swimmingDelay());
                isMovSdPlaying_S = true;
            }
        }
        if(isMovSdPlaying_S == true && isPlayerMoving_S == false){
            playerController.SetMovingBlock(2);
            StopCoroutine(swimmingDelay());
            isMovSdPlaying_S = false;
        }
        //回避の音
        if(Step_Soud == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("step");
            playerController.Play();
            Step_Soud = false;
        }
        //銛
        if (mori.Mori_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("attack_Hrpn");
            playerController.Play();
            mori.Mori_Sound = false;
        }
        //カジキ
        if (Sf_Sound == 1){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Sf");
            playerController.Play();
            Sf_Sound = 0;
        }
        //クラゲ
        if (Kurage.Kurage_Sound_s == true || FishSkillSystem.Kurage_Sound_s_2 == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Jf");
            playerController.KuragePlay();
            Kurage.Kurage_Sound_s = false;
            FishSkillSystem.Kurage_Sound_s_2 = false;
        }
        if (Kurage.Kurage_Sound_e == true || FishSkillSystem.Kurage_Sound_e_2 == true)
        {
            playerController.SetKurageBlock(1);
            Kurage.Kurage_Sound_e = false;
            FishSkillSystem.Kurage_Sound_e_2 = false;
        }
        //電気ウナギ
        if (c_Unagi_S == true && isUnagi_act == true && SkillElectronic.EE_Sound == 1)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_EE");
            playerController.EEPlay();
            SkillElectronic.EE_Sound = 4;
        }
        if (SkillElectronic.EE_Sound == 2)
        {
            playerController.SetEEBlock(2);
            SkillElectronic.EE_Sound = 4;
        }
        if (SkillElectronic.EE_Sound == 4)
        {
            if (c_Unagi_S == false || isUnagi_act == false)
            {
                playerController.EEStop();
                SkillElectronic.EE_Sound = 0;
            }
        }
        //ダメージ系SFX
        if (PlayerHP.damaged_Sound_P == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("damage_P");
            playerController.Play();
            PlayerHP.damaged_Sound_P = false;
        }

        //泡音用コルーチンスタート
        if (ActiveSceneManager.S_Title == true || ActiveSceneManager.S_StageSelect == true)
        {
            //BGMや効果音の停止
            playerController.BGMStop();
            playerController.KurageStop();
            playerController.EEStop();

            StartCoroutine(bubbleRondomize());
            ActiveSceneManager.S_Title = false;
            ActiveSceneManager.S_StageSelect = false;
            Debug.Log("Coroutine Start");
        }
    }

    //泡音用コルーチン
    private IEnumerator bubbleRondomize(){
        float rnd_bubble;
        float rnd_Pan;
        float rnd_Volume;
        while(true){
            rnd_bubble = Random.Range(3.0f,5.0f);
            rnd_Pan = Random.Range(0.0f,1.0f);
            rnd_Volume = Random.Range(0.0f,1.0f);
            playerController.SetAisacCtrl("Rondom_Pan",rnd_Pan);
            playerController.SetAisacCtrl("Rondom_Volume",rnd_Volume);
            bubble_Play();
            yield return new WaitForSeconds(rnd_bubble);
        }
    }
    private void bubble_Play(){
        playerController.SetAcb(atomLoader.acbAssets[2].Handle);
        playerController.SetCueName("bubble");
        playerController.MenuSFXPlay();
        Debug.Log("bubble Playing");
    }

    //移動中効果音用コルーチン
    private IEnumerator swimmingDelay(){
        float SBDelayTime = 0.6f;
        while(true){
            yield return new WaitForSeconds(SBDelayTime);
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("swimming_bubble");
            playerController.Play();
            SBDelayTime = 0.25f;
        }
    }
}