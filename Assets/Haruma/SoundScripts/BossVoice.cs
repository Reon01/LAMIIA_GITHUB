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

    //ボスHP監視用変数
    public int bosshp = S4_BossHP.bossHP;
    public static int lowhpObs = 0;

    void Start(){
        
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
        
        StartCoroutine(VoiceRondomize());
        Debug.Log("voiceCoroutine Start");
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
            voice_Play();
            yield return new WaitForSeconds(rnd_voice);
        }
    }

    private void voice_Play()
    {
        playerController.bossPlay();
        Debug.Log("BossVoice Playing");
    }
}