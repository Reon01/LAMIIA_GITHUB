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

    //�{�XHP�Ď��p�ϐ�
    public int bosshp = S4_BossHP.bossHP;
    public static int lowhpObs = 0;


    void Start(){
        //Boss�A�N�e�B�u���ő��
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
        
        //Voice�R���[�`���̃X�^�[�g
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

    //Voice�p�R���[�`��
    private IEnumerator VoiceRondomize()
    {
        float rnd_voice = Random.Range(5.0f, 8.0f);
        while (true)
        {
            //�{�X�pSource
            CriAtomSource BVSource = GetComponent<CriAtomSource>();
            Debug.Log(BVSource);
            BVSource.cueSheet = "SFX";
            BVSource.cueName = "voice_Boss";
            BVSource.Play();

            Debug.Log("voice played in Coroutine");
            yield return new WaitForSeconds(rnd_voice);
        }
    }
}