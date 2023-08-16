using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class SFXplayer : MonoBehaviour
{
    //ウナギ用変数
    public static bool isUnagi_act;

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

    void Update(){
        if(ActiveSceneManager.S_Title == true)
        {
            playerController.EEStop();
            SkillElectronic.EE_Sound = 0;
        }
        //メニュー系SFX
        if (GameStart.menu_Sound == 1){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("menu_Confirm");
            playerController.Play();
            GameStart.menu_Sound = 0;
        }
        if (GameStart.menu_Sound == 2){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("menu_Back");
            playerController.Play();
            GameStart.menu_Sound = 0;
        }
        if (GameStart.menu_Sound == 3)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("menu_Selecting");
            playerController.Play();
            GameStart.menu_Sound = 0;
        }
        if (GameStart.menu_Sound == 4)
        {
            playerController.SetAcb(atomLoader.acbAssets[1].Handle);
            playerController.SetCueName("Start_JINGLE");
            playerController.Play();
            GameStart.menu_Sound = 0;
        }
        //銛
        if (mori.Mori_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("attack_Hrpn");
            playerController.Play();
            mori.Mori_Sound = false;
        }
        //カジキ
        if (Kajiki.Kajiki_Sound == true || S3_Kajiki.Kajiki_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Sf");
            playerController.Play();
            Kajiki.Kajiki_Sound = false;
            S3_Kajiki.Kajiki_Sound = false;
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
        if (SkillElectronic_new.c_Unagi_S == true && isUnagi_act == true && SkillElectronic.EE_Sound == 1)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_EE");
            playerController.EEPlay();
            SkillElectronic.EE_Sound = 4;
            Debug.Log("EESound_Start");
        }
        if (SkillElectronic.EE_Sound == 2)
        {
            playerController.SetEEBlock(2);
            SkillElectronic.EE_Sound = 4;
            Debug.Log("EESound_Hit");
        }
        if (SkillElectronic.EE_Sound == 4)
        {
            if (SkillElectronic_new.c_Unagi_S == false || isUnagi_act == false)
            {
                playerController.EEStop();
                Debug.Log("EESound_Stop");
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
        if (EnemyHP.damaged_Sound_E == 1){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("damage_E");
            playerController.Play();
            EnemyHP.damaged_Sound_E = 0;
        }
        if (EnemyHP.damaged_Sound_E == 2){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("damage_E");
            playerController.Play();
            EnemyHP.damaged_Sound_E = 0;
        }
        if (EnemyKill.e_Defeat_Sound == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("e_Defeated");
            playerController.Play();
            EnemyKill.e_Defeat_Sound = false;
        }

        //泡音用コルーチンスタート
        if (ActiveSceneManager.S_Title == true)
        {
            playerController.BGMStop();
            StartCoroutine(bubbleRondomize());
            ActiveSceneManager.S_Title = false;
            Debug.Log("Coroutine Start");
        }
        //ボス系アタックサウンド
        /*
        if(BossAttack.Spear_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("");
            playerController.Play();
            BossAttack.Spear_Sound = false;
            Debug.Log("Spear is Coming");

        }
        if(.Razor_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("");
            playerController.Play();
            .Razor_Sound = false;
            Debug.Log("Razor is Coming");

        }
        if(.Summon_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("");
            playerController.Play();
            .Summon_Sound = false;
            Debug.Log("Summon Voice");
        }
        */
    }

    //泡音用コルーチン
    private IEnumerator bubbleRondomize(){
        float rnd_bubble = Random.Range(3.0f,5.0f);
        while(true){
            bubble_Play();
            yield return new WaitForSeconds(rnd_bubble);
        }
    }

    private void bubble_Play(){
        playerController.SetAcb(atomLoader.acbAssets[2].Handle);
        playerController.SetCueName("bubble");
        playerController.BGMPlay();
        Debug.Log("bubble Playing");
    }
}