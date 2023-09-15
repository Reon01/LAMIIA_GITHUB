using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using CriWare.Assets;

public class SfAndPpf : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    CriAtomCueReference cueSf_shoot;

    [SerializeField]
    CriAtomCueReference cuePpf_shoot;

    private CriAtomExPlayback Sfplayback;
    private CriAtomExPlayback Ppfplayback;

    void Start(){
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
    }

    void Update(){
        CriAtomSourceForAsset shoot_Sound = GetComponent<CriAtomSourceForAsset>();
        shoot_Sound.use3dPositioning = true;
        //カジキ発射
        if(SFXplayer.Sf_Sound == 1){
            SSPlay(Sfplayback, cueSf_shoot, shoot_Sound);
            SFXplayer.Sf_Sound = 0;
        }
        //カジキヒット
        if(SFXplayer.Sf_Sound == 2){
            playerController.SetNextBlock(2, Sfplayback);
            SFXplayer.Sf_Sound = 0;
        }
        //ハリセンボン発射
        if(SFXplayer.ppf_Sound == 1){
            SSPlay(Ppfplayback, cuePpf_shoot, shoot_Sound);
            SFXplayer.ppf_Sound = 0;
        }
        //ハリセンボン炸裂
        else if (SFXplayer.ppf_Sound == 2){
            playerController.SetNextBlock(2, Ppfplayback);
            SFXplayer.ppf_Sound = 0;
        }
    }

    public void SSPlay(CriAtomExPlayback playback, CriAtomCueReference cueReference, CriAtomSourceForAsset atomSource){
        atomSource.Cue = cueReference;
        playback = atomSource.Play();
    }
}