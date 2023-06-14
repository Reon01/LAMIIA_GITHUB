using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* (1) ���O��Ԃ̐ݒ� */
using CriWare;
/*�����ł̓f�[�^���Q�Ƃ��Ȃ��̂ŁAAsset�̂�͏����Ȃ�*/

public class BGMController : MonoBehaviour
{
    /* (2) �v���[���[ */
    private CriAtomExPlayer BGMplayer;

    /* (12) ACB ��� */
    private CriAtomExAcb acb;

    /* (16) �L���[�� */
    private string cueName;

    /* (3) �R���[�`�������� */
    IEnumerator Start(){
        /* (4) ���C�u�����̏������ς݃`�F�b�N */
        while (!CriWareInitializer.IsInitialized()){
            yield return null;
        }

        /* (5) �v���[���[�̍쐬 */
        BGMplayer = new CriAtomExPlayer();
    }

    void Update() { }

    public void Play(){
        /* (10) �|�[�Y��Ԃɉ��������� */
        if (BGMplayer.IsPaused()){
            /* (11) �|�[�Y�̉��� */
            BGMplayer.Pause(false);
        }
        else{
            /* (18) �L���[�����v���[���[�ݒ� */
            BGMplayer.SetCue(acb, cueName);
            /* (7) �v���[���[�̍Đ� */
            BGMplayer.Start();
        }

    }

    /* (8) �v���[���[�̒�~ */
    public void Stop(){
        BGMplayer.Stop();
    }

    /* (9) �v���[���[�̈ꎞ��~ */
    public void Pause(){
        BGMplayer.Pause(true);
    }

    /* (12) ACB �̎w�� */
    public void SetAcb(CriAtomExAcb acb){
        /* (14) ACB �̕ۑ� */
        this.acb = acb;
    }

    /* (15) �L���[���̎w�� */
    public void SetCueName(string name){
        /* (17) �L���[���̕ۑ� */
        cueName = name;
    }

    /* (19) �{�����[���̐ݒ� */
    public void SetVolume(float vol){
        /* (19) �{�����[���̐ݒ� */
        BGMplayer.SetVolume(vol);
        /* (20) �p�����[�^�[�̍X�V */
        BGMplayer.UpdateAll();
    }

    public void Seek(float value){
        /* (Ex) �L���[���V�[�N������ */
    }

    /* (21) AISAC �R���g���[���l�̐ݒ� */
    public void SetAisacControl(float value){
        /* (21) AISAC �R���g���[���l�̐ݒ� */
        BGMplayer.SetAisacControl("Any", value);

        /* (22) �p�����[�^�[�̍X�V */
        BGMplayer.UpdateAll();
    }
}
