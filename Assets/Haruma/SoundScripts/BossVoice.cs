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
        bosshp = S4_BossHP.bossHP;
        if (bosshp < 1500 && lowhpObs == 0){
            lowhpObs = 1;
        }
        if (bosshp >= 3000){
            lowhpObs = 0;
        }
        if(VoiceActFrag == false){
            voiceRondomize = StartCoroutine(VoiceRondomize());
            VoiceActFrag = true;
        }
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