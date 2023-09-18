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

    //ボスHP監視用変数
    public int bosshp = S4_BossHP.bossHP;
    public static int lowhpObs = 0;
    //コルーチンの代入用変数とボイス管理用変数
    public static Coroutine voiceRondomize;
    public static bool VoiceActFrag;

    void Start(){
        //Bossアクティブ化で代入
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
    }

    void Update(){
        CriAtomSourceForAsset BA_Sound = GetComponent<CriAtomSourceForAsset>();
        BA_Sound.use3dPositioning = true;
        //BGM変化
        bosshp = S4_BossHP.bossHP;
        if (bosshp < 1500 && lowhpObs == 0){
            lowhpObs = 1;
        }
        if (bosshp >= 3000){
            lowhpObs = 0;
        }
        //ボス咆哮
        if(VoiceActFrag == false){
            voiceRondomize = StartCoroutine(VoiceRondomize());
            VoiceActFrag = true;
        }
        //ビーム攻撃
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
        //雑魚召喚
        if(. == true){
            BA_Sound.Cue = cueSummon;
            BA_Sound.Play();
            . = false;
        }
        */
    }

    //Voice用コルーチン
    private IEnumerator VoiceRondomize(){
        float rnd_voice = Random.Range(5.0f, 8.0f);
        while (true){
            //ボス用Source
            CriAtomSourceForAsset BVSource = GetComponent<CriAtomSourceForAsset>();
            BVSource.use3dPositioning = true;
            BVSource.Cue = cueBossVoice;
            BVSource.Play();

            yield return new WaitForSeconds(rnd_voice);
        }
    }
}