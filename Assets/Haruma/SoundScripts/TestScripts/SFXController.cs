using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* (1) ���O��Ԃ̐ݒ� */
using CriWare;
/*�����ł̓f�[�^���Q�Ƃ��Ȃ��̂ŁAAsset�̂�͏����Ȃ�*/

public class SFXController : MonoBehaviour
{
    /* (2) �v���[���[ */
    private CriAtomExPlayer SFXplayer;

    //�v���C�o�b�N
    private CriAtomExPlayback Kurageplayback;
    private CriAtomExPlayback EEplayback;

    /* (12) ACB ��� */
    private CriAtomExAcb acb;

    /* (16) �L���[�� */
    private string cueName;

    /* (3) �R���[�`�������� */
    IEnumerator Start()
    {
        /* (4) ���C�u�����̏������ς݃`�F�b�N */
        while (!CriWareInitializer.IsInitialized())
        {
            yield return null;
        }

        /* (5) �v���[���[�̍쐬 */
        SFXplayer = new CriAtomExPlayer();
    }

    void Update() { }

    public void sfxPlay()
    {
        /* (10) �|�[�Y��Ԃɉ��������� */
        if (SFXplayer.IsPaused())
        {
            /* (11) �|�[�Y�̉��� */
            SFXplayer.Pause(false);
        }
        else
        {
            /* (18) �L���[�����v���[���[�ݒ� */
            SFXplayer.SetCue(acb, cueName);
            /* (7) �v���[���[�̍Đ� */
            SFXplayer.Start();
        }

    }
    //�N���Q�p�v���C�o�b�N
    public void KuragePlay()
    {
        SFXplayer.SetCue(acb, cueName);
        Kurageplayback = SFXplayer.Start();
    }
    //���Ȃ��p�v���C�o�b�N
    public void EEPlay()
    {
        SFXplayer.SetCue(acb, cueName);
        EEplayback = SFXplayer.Start();
    }

    /* (8) �v���[���[�̒�~ */
    public void sfxStop()
    {
        SFXplayer.Stop();
    }
    //�v���C�o�b�N��~
    public void KurageStop()
    {
        Kurageplayback.Stop();
    }
    public void EEStop()
    {
        EEplayback.Stop();
    }

    /* (9) �v���[���[�̈ꎞ��~ */
    public void sfxPause()
    {
        SFXplayer.Pause(true);
    }

    /* (12) ACB �̎w�� */
    public void sfxSetAcb(CriAtomExAcb acb)
    {
        /* (14) ACB �̕ۑ� */
        this.acb = acb;
    }

    /* (15) �L���[���̎w�� */
    public void sfxSetCueName(string name)
    {
        /* (17) �L���[���̕ۑ� */
        cueName = name;
    }

    /* (19) �{�����[���̐ݒ� */
    public void sfxSetVolume(float vol)
    {
        /* (19) �{�����[���̐ݒ� */
        SFXplayer.SetVolume(vol);
        /* (20) �p�����[�^�[�̍X�V */
        SFXplayer.UpdateAll();
    }

    public void sfxSeek(float value)
    {
        /* (Ex) �L���[���V�[�N������ */
    }

    /* (21) AISAC �R���g���[���l�̐ݒ� */
    public void sfxSetAisacControl(float value)
    {
        /* (21) AISAC �R���g���[���l�̐ݒ� */
        SFXplayer.SetAisacControl("Any", value);

        /* (22) �p�����[�^�[�̍X�V */
        SFXplayer.UpdateAll();
    }
}
