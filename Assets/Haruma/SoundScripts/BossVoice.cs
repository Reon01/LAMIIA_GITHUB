using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using CriWare.Assets;


public class BossVoice : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private AtomLoader atomLoader;

    [SerializeField]
    CriAtomCueReference cueBossVoice;

    [SerializeField]
    CriAtomCueReference cueBeam;

    [SerializeField]
    CriAtomCueReference cueSummon;

    private CriAtomExPlayback Beamplayback;

    //�{�XHP�Ď��p�ϐ�
    public int bosshp = S4_BossHP.bossHP;
    public static int lowhpObs = 0;
    //�R���[�`���̑���p�ϐ��ƃ{�C�X�Ǘ��p�ϐ�
    public static Coroutine voiceRondomize;
    public static bool VoiceActFrag;

    void Start(){
        //Boss�A�N�e�B�u���ő��
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
    }

    void Update(){
        CriAtomSourceForAsset BA_Sound = GetComponent<CriAtomSourceForAsset>();
        BA_Sound.use3dPositioning = true;
        //BGM�ω�
        bosshp = S4_BossHP.bossHP;
        if (bosshp < 1500 && lowhpObs == 0){
            lowhpObs = 1;
        }
        if (bosshp >= 3000){
            lowhpObs = 0;
        }
        //�{�X���K
        if(VoiceActFrag == false){
            voiceRondomize = StartCoroutine(VoiceRondomize());
            VoiceActFrag = true;
        }
        //�r�[���U��
        /*
        if(. == true){
            BA_Sound.Cue = cueBeam;
            Beamplayback = BA_Sound.Play();
            . = false;
        }
        if(. == true){
            playerController.SetNextBlock(2, Beamplayback);
            . = false;
        }
        //�G������
        if(. == true){
            BA_Sound.Cue = cueSummon;
            BA_Sound.Play();
            . = false;
        }
        */
    }

    //Voice�p�R���[�`��
    private IEnumerator VoiceRondomize(){
        float rnd_voice = Random.Range(5.0f, 8.0f);
        while (true){
            //�{�X�pSource
            CriAtomSourceForAsset BVSource = GetComponent<CriAtomSourceForAsset>();
            BVSource.use3dPositioning = true;
            BVSource.Cue = cueBossVoice;
            BVSource.Play();

            yield return new WaitForSeconds(rnd_voice);
        }
    }
}