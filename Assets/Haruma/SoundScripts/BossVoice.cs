using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;


public class BossVoice : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private AtomLoader atomLoader;

    [SerializeField]
    CriAtomSource BVSource;

    //ボスHP監視用変数
    public int bosshp = S4_BossHP.bossHP;
    public static int lowhpObs = 0;

    void Start(){
        //Bossアクティブ化で代入
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
        
        //Voiceコルーチンのスタート
        StartCoroutine(VoiceRondomize());
    }

    void Update(){
        bosshp = S4_BossHP.bossHP;
        if (bosshp < 1500 && lowhpObs == 0){
            lowhpObs = 1;
        }
        if (bosshp >= 3000){
            lowhpObs = 0;
        }
    }

    //Voice用コルーチン
    private IEnumerator VoiceRondomize()
    {
        float rnd_voice = Random.Range(5.0f, 8.0f);
        while (true)
        {
            //ボス用Source
            CriAtomSource BVSource = GetComponent<CriAtomSource>();
            //BVSource.use3dPositioning = true;
            //BVSource.cue = cueBossVoice;
            BVSource.cueSheet = "SFX";
            BVSource.cueName = "voice_Boss";
            BVSource.Play();

            yield return new WaitForSeconds(rnd_voice);
        }
    }
}