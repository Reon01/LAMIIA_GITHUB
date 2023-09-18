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

    //�{�X�U���p�ϐ�
    public static bool Summon_Sound;
    //�v���C�o�b�N
    private CriAtomExPlayback Beamplayback;

    //{XHP�?pĎ�?
    public int bosshp = S4_BossHP.bossHP;
    public static int lowhpObs = 0;
    //R[`ĚăüpĎ�?{CX�?pĎ�?
    public static Coroutine voiceRondomize;
    public static bool VoiceActFrag;

    void Start(){
        //BossANeBuťĹăü
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
    }

    void Update(){
        CriAtomSourceForAsset BA_Sound = GetComponent<CriAtomSourceForAsset>();
        BA_Sound.use3dPositioning = true;
        //BGMĎť
        bosshp = S4_BossHP.bossHP;
        if (bosshp < 1500 && lowhpObs == 0){
            lowhpObs = 1;
        }
        if (bosshp >= 3000){
            lowhpObs = 0;
        }
        //{XôK
        if(VoiceActFrag == false){
            voiceRondomize = StartCoroutine(VoiceRondomize());
            VoiceActFrag = true;
        }
        //r[U�?
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
        */
        //G˘Ť
        if(Summon_Sound == true){
            BA_Sound.Cue = cueSummon;
            BA_Sound.Play();
            Summon_Sound = false;
        }
    }

    //VoicepR[`�?
    private IEnumerator VoiceRondomize(){
        float rnd_voice = Random.Range(5.0f, 8.0f);
        while (true){
            //{XpSource
            CriAtomSourceForAsset BVSource = GetComponent<CriAtomSourceForAsset>();
            BVSource.use3dPositioning = true;
            BVSource.Cue = cueBossVoice;
            BVSource.Play();

            yield return new WaitForSeconds(rnd_voice);
        }
    }
}