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

    void Start(){
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
        StartCoroutine(VoiceRondomize());
        Debug.Log("voiceCoroutine Start");
    }

    void Update(){

    }

    //Voice�p�R���[�`��
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
        playerController.SetAcb(atomLoader.acbAssets[2].Handle);
        playerController.SetCueName("voice_Boss");
        playerController.bossPlay();
        Debug.Log("BossVoice Playing");
    }
}