using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using CriWare.Assets;

public class EnemySound : MonoBehaviour
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

    void Start(){}

    void Update(){
        CriAtomSourceForAsset enemy_Sound = GetComponent<CriAtomSourceForAsset>();
        enemy_Sound.use3dPositioning = true;

        if (SFXplayer.damaged_Sound_E == 1){
            ESPlay(cueDamaged, enemy_Sound);
            SFXplayer.damaged_Sound_E = 0;
        }
        if (SFXplayer.damaged_Sound_E == 2){
            ESPlay(cueDamaged, enemy_Sound);
            SFXplayer.damaged_Sound_E = 0;
        }
        if(SFXplayer.damaged_Sound_E == 3){
            ESPlay(cueSf_Hit, enemy_Sound);
            SFXplayer.damaged_Sound_E = 0;
        }
        if (EnemyKill.e_Defeat_Sound == true){
            ESPlay(cueE_Defeated, enemy_Sound);
            EnemyKill.e_Defeat_Sound = false;
        }
        if(SFXplayer.ppf_Sound == 3){
            ESPlay(cuePpf_Hit, enemy_Sound);
            SFXplayer.ppf_Sound = 0;
        }
        /*
        if(. == true && this.GameObject != ("Boss_kansei")){
            ESPlay(cueSummoned, enemy_Sound);
            . = false;
        }
        */
    }

    public void ESPlay(CriAtomCueReference cueReference, CriAtomSourceForAsset atomSource){
        atomSource.Cue = cueReference;
        atomSource.Play();
    }
}