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

    void Awake(){
        if (dontDestroyOnLoad){
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    void Start(){}

    void Update(){
        //���j���[SFX
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
        //��
        if (mori.Mori_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("attack_Hrpn");
            playerController.Play();
            mori.Mori_Sound = false;
            Debug.Log("HrpnSound");
        }
        //�J�W�L
        if (Kajiki.Kajiki_Sound == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Sf");
            playerController.Play();
            Kajiki.Kajiki_Sound = false;
            Debug.Log("KajikiSound");
        }
        //�N���Q
        if (Kurage.Kurage_Sound_s == true || FishSkillSystem.Kurage_Sound_s_2 == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Jf_s");
            playerController.KuragePlay();
            Kurage.Kurage_Sound_s = false;
            FishSkillSystem.Kurage_Sound_s_2 = false;
            Debug.Log("KurageSound_s");
        }
        if (Kurage.Kurage_Sound_e == true || FishSkillSystem.Kurage_Sound_e_2 == true)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_Jf_e");
            playerController.Play();
            playerController.KurageStop();
            Kurage.Kurage_Sound_e = false;
            FishSkillSystem.Kurage_Sound_e_2 = false;
            Debug.Log("KurageSound_e");
        }

        //�f���L�E�i�M
        if (SkillElectronic.EE_Sound == 1)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_EE_s");
            playerController.Play();
            playerController.SetCueName("skill_EE_l");
            playerController.EEPlay();
            SkillElectronic.EE_Sound = 0;
            Debug.Log("EESound_Start");
        }
        if (SkillElectronic.EE_Sound == 2)
        {
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("skill_EE_h");
            playerController.Play();
            SkillElectronic.EE_Sound = 0;
            Debug.Log("EESound_Hit");
        }
        if (SkillElectronic.EE_Sound == 3)
        {
            playerController.EEStop();
            SkillElectronic.EE_Sound = 0;
            Debug.Log("EESound_Stop");
        }
        //��e���^�_���[�W��
        if (PlayerHP.damaged_Sound_P == true){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("damage_P");
            playerController.Play();
            PlayerHP.damaged_Sound_P = false;
            Debug.Log("痛い！");
        }
        if (EnemyHP.damaged_Sound_E == 1){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("damage_E");
            playerController.Play();
            EnemyHP.damaged_Sound_E = 0;
            Debug.Log("Hit!");
        }
        if (EnemyHP.damaged_Sound_E == 2){
            playerController.SetAcb(atomLoader.acbAssets[2].Handle);
            playerController.SetCueName("damage_E");
            playerController.Play();
            EnemyHP.damaged_Sound_E = 0;
            Debug.Log("Enemy is Dead!");
        }
    }
}