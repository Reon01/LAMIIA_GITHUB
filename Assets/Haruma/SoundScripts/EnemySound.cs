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

    void Start(){}

    void Update(){
        CriAtomSourceForAsset enemy_Sound = GetComponent<CriAtomSourceForAsset>();
        enemy_Sound.use3dPositioning = true;

        if (EnemyHP.damaged_Sound_E == 1){
            ESPlay(cueDamaged, enemy_Sound);
            EnemyHP.damaged_Sound_E = 0;
        }
        if (EnemyHP.damaged_Sound_E == 2){
            ESPlay(cueDamaged, enemy_Sound);
            EnemyHP.damaged_Sound_E = 0;
        }
        if(EnemyHP.damaged_Sound_E == 3){
            ESPlay(cueSf_Hit, enemy_Sound);
            EnemyHP.damaged_Sound_E = 0;
        }
        if (EnemyKill.e_Defeat_Sound == true){
            ESPlay(cueE_Defeated, enemy_Sound);
            EnemyKill.e_Defeat_Sound = false;
        }
    }

    public void ESPlay(CriAtomCueReference cueReference, CriAtomSourceForAsset atomSource){
        atomSource.Cue = cueReference;
        atomSource.Play();
    }
}
