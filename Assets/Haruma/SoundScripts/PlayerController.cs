using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* (1) ���O��Ԃ̐ݒ� */
using CriWare;
/*�����ł̓f�[�^���Q�Ƃ��Ȃ��̂ŁAAsset�̂�͏����Ȃ�*/

public class PlayerController : MonoBehaviour
{
    /* (2) �v���[���[ */
    private CriAtomExPlayer player;

    //�v���C�o�b�N
    private CriAtomExPlayback Kurageplayback;
    private CriAtomExPlayback EEplayback;
    private CriAtomExPlayback BGMplayback;

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
        player = new CriAtomExPlayer();
    }

    void Update() { }

    public void Play(){
        /* (10) �|�[�Y��Ԃɉ��������� */
        if (player.IsPaused()){
            /* (11) �|�[�Y�̉��� */
            player.Pause(false);
        }
        else{
            /* (18) �L���[�����v���[���[�ݒ� */
            player.SetCue(acb, cueName);
            /* (7) �v���[���[�̍Đ� */
            player.Start();
        }

    }
    //�N���Q�p�v���C�o�b�N
    public void KuragePlay(){
        player.SetCue(acb, cueName);
        Kurageplayback = player.Start();
    }
    //���Ȃ��p�v���C�o�b�N
    public void EEPlay(){
        player.SetCue(acb, cueName);
        EEplayback = player.Start();
    }
    //BGM�p�v���C�o�b�N
    public void BGMPlay(){
        player.SetCue(acb, cueName);
        BGMplayback = player.Start();
    }


    /* (8) �v���[���[�̒�~ */
    public void Stop(){
        player.Stop();
    }
    //�v���C�o�b�N��~
    public void KurageStop(){
        Kurageplayback.Stop();
    }
    public void EEStop(){
        EEplayback.Stop();
    }
    public void BGMStop()
    {
        BGMplayback.Stop();
    }

    /* (9) �v���[���[�̈ꎞ��~ */
    public void Pause(){
        player.Pause(true);
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
        player.SetVolume(vol);
        /* (20) �p�����[�^�[�̍X�V */
        player.UpdateAll();
    }

    public void Seek(float value){
        /* (Ex) �L���[���V�[�N������ */
    }

    /* (21) AISAC �R���g���[���l�̐ݒ� */
    public void SetAisacControl(float value){
        /* (21) AISAC �R���g���[���l�̐ݒ� */
        player.SetAisacControl("Any", value);

        /* (22) �p�����[�^�[�̍X�V */
        player.UpdateAll();
    }
}
