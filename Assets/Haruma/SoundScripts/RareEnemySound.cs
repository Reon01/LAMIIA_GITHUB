using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using CriWare.Assets;

public class RareEnemySound : MonoBehaviour
{
    [SerializeField]
    CriAtomCueReference cueE_Defeated;
    [SerializeField]
    CriAtomCueReference cueSf_Hit;
    [SerializeField]
    CriAtomCueReference cueDamaged;
    [SerializeField]
    CriAtomCueReference cuePpf_Hit;
    [SerializeField]
    CriAtomCueReference cueSummoned;
    [SerializeField]
    CriAtomCueReference cueRare_Hit;
    [SerializeField]
    CriAtomCueReference cueRare_defeat;

    void Start(){}

    void Update(){
        CriAtomSourceForAsset RE_Sound = GetComponent<CriAtomSourceForAsset>();
        RE_Sound.use3dPositioning = true;
        //レア敵用
        if (SFXplayer.damaged_Sound_E == 1){
            RESPlay(cueDamaged, RE_Sound);
            RESPlay(cueRare_Hit, RE_Sound);
            SFXplayer.damaged_Sound_E = 0;
        }
        /*
        if (SFXplayer.damaged_Sound_E == 2){
            RESPlay(cueDamaged, RE_Sound);
            SFXplayer.damaged_Sound_E = 0;
        }
        */
        if(SFXplayer.damaged_Sound_E == 3){
            RESPlay(cueSf_Hit, RE_Sound);
            RESPlay(cueRare_Hit, RE_Sound);
            SFXplayer.damaged_Sound_E = 0;
        }
        if (EnemyKill.e_Defeat_Sound == true){
            SFXplayer.skillCharge_Sound = true;
            RESPlay(cueE_Defeated, RE_Sound);
            RESPlay(cueRare_defeat, RE_Sound);
            EnemyKill.e_Defeat_Sound = false;
        }
        if(SFXplayer.ppf_Sound == 3){
            RESPlay(cuePpf_Hit, RE_Sound);
            SFXplayer.ppf_Sound = 0;
        }
        /*
        if(. == true && this.GameObject != ("Boss_kansei")){
            RESPlay(cueSummoned, RE_Sound);
            . = false;
        }
        */
    }

    public void RESPlay(CriAtomCueReference cueReference, CriAtomSourceForAsset atomSource){
        atomSource.Cue = cueReference;
        atomSource.Play();
        Debug.Log("RESPlay");
    }
}