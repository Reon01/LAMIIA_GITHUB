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

    //ボス攻撃用変数
    public static bool Summon_Sound;
    //プレイバック
    private CriAtomExPlayback Beamplayback;

    //ﾂボﾂスHPﾂ甘?ﾂ篠仰用ﾂ米篠青?
    public int bosshp = S4_BossHP.bossHP;
    public static int lowhpObs = 0;
    //ﾂコﾂδ仰ーﾂチﾂδ督て堋惰δ禿ｼﾂ用ﾂ米篠青板て?ﾂボﾂイﾂスﾂ甘?ﾂ猟敖用ﾂ米篠青?
    public static Coroutine voiceRondomize;
    public static bool VoiceActFrag;

    void Start(){
        //Bossﾂアﾂクﾂテﾂィﾂブﾂ嫁･ﾂてｹﾂ惰δ禿ｼ
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
    }

    void Update(){
        CriAtomSourceForAsset BA_Sound = GetComponent<CriAtomSourceForAsset>();
        BA_Sound.use3dPositioning = true;
        //BGMﾂ米篠嫁･
        bosshp = S4_BossHP.bossHP;
        if (bosshp < 1500 && lowhpObs == 0){
            lowhpObs = 1;
        }
        if (bosshp >= 3000){
            lowhpObs = 0;
        }
        //ﾂボﾂスﾂ凖ｴﾂ哮
        if(VoiceActFrag == false){
            voiceRondomize = StartCoroutine(VoiceRondomize());
            VoiceActFrag = true;
        }
        //ﾂビﾂーﾂδﾂ攻ﾂ個?
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
        //ﾂ雑ﾂ仰崢祥伉看､
        if(Summon_Sound == true){
            BA_Sound.Cue = cueSummon;
            BA_Sound.Play();
            Summon_Sound = false;
        }
    }

    //Voiceﾂ用ﾂコﾂδ仰ーﾂチﾂδ?
    private IEnumerator VoiceRondomize(){
        float rnd_voice = Random.Range(5.0f, 8.0f);
        while (true){
            //ﾂボﾂスﾂ用Source
            CriAtomSourceForAsset BVSource = GetComponent<CriAtomSourceForAsset>();
            BVSource.use3dPositioning = true;
            BVSource.Cue = cueBossVoice;
            BVSource.Play();

            yield return new WaitForSeconds(rnd_voice);
        }
    }
}