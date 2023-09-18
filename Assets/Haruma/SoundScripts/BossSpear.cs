using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using CriWare.Assets;

public class BossSpear : MonoBehaviour
{
    [SerializeField]
    CriAtomCueReference cueSpear_Shoot;

    void Start(){}

    void Update(){
        CriAtomSourceForAsset Spear_Sound = GetComponent<CriAtomSourceForAsset>();
        Spear_Sound.use3dPositioning = true;
        
        if(BossAttack.Spear_Sound == true){
            Spear_Sound.Cue = cueSpear_Shoot;
            Spear_Sound.Play();
        }
    }
}
