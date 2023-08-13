using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*名前空間の設定 */
using CriWare;
/*ここではデータを参照しないので、Assetのやつは書かない*/

public class PlayerController : MonoBehaviour
{
    /* 音量設定用スライダー */
    private Slider volumeSlider;
    /* 3Dポジショニング用Source*/
    public CriAtomSource BV3dSource;
    /*プレーヤー */
    private CriAtomExPlayer anyPlayer;

    //プレイバック
    private CriAtomExPlayback Kurageplayback;
    private CriAtomExPlayback EEplayback;
    private CriAtomExPlayback BGMplayback;

    /*ACB 情報 */
    private CriAtomExAcb acb;

    /*キュー名 */
    private string cueName;

    //ボス用
    public bool bossObjChk = false;

    /*コルーチン化する */
    IEnumerator Start(){

        /*ライブラリの初期化済みチェック */
        while (!CriWareInitializer.IsInitialized()){
            yield return null;
        }

        /*プレーヤーの作成 */
        anyPlayer = new CriAtomExPlayer();

        if (ActiveSceneManager.S_Tutorial == true || ActiveSceneManager.S_Skill == true || ActiveSceneManager.S_Boss == true){
            Slider[] sliders = FindObjectsOfType<Slider>(true);
            Slider volSlider = sliders[1]; 
            Debug.Log(volSlider);
            volumeSlider = volSlider;

            volumeSlider.maxValue = 2.0f;
            volumeSlider.value = 1.0f;
            volumeSlider.minValue = 0.0f;
        }
        //AISACの初期値設定
        SetBossBGMAisacControl(0);
    }

    void Update() {
        //ボスボイス用
        if(PCExpander.bossObj == true && bossObjChk == false){
            BV3dSource = PCExpander.bossObj.GetComponent<CriAtomSource>();
            Debug.Log(BV3dSource.player);
            anyPlayer = BV3dSource.player;
            Debug.Log(anyPlayer);
            bossObjChk = true;
        }
        else if(PCExpander.bossObj == false && bossObjChk == true){
            Debug.Log("bossFalse");
            bossObjChk = false;
        }
    }

    public void Play(){
        /*ポーズ状態に応じた処理 */
        if (anyPlayer.IsPaused()){
            /*ポーズの解除 */
            anyPlayer.Pause(false);
        }
        else{
            /*キュー情報をプレーヤー設定 */
            anyPlayer.SetCue(acb, cueName);
            /*プレーヤーの再生 */
            anyPlayer.Start();
        }

    }
    //ボス用プレイ
    public void bossPlay(){
        anyPlayer.SetCue(acb, cueName);
        BV3dSource.Play();
    }
    //クラゲ用プレイバック
    public void KuragePlay(){
        anyPlayer.SetCue(acb, cueName);
        Kurageplayback = anyPlayer.Start();
    }
    //うなぎ用プレイバック
    public void EEPlay(){
        anyPlayer.SetCue(acb, cueName);
        EEplayback = anyPlayer.Start();
    }
    //BGM用プレイバック
    public void BGMPlay(){
        anyPlayer.SetCue(acb, cueName);
        BGMplayback = anyPlayer.Start();
    }

    /*プレーヤーの停止 */
    public void Stop(){
        anyPlayer.Stop();
    }
    //ボス用プレイヤーの停止
    public void bossStop(){
        BV3dSource.Stop();
    }
    //プレイバック停止
    public void KurageStop(){
        Kurageplayback.Stop();
    }
    public void EEStop(){
        EEplayback.Stop();
    }
    public void BGMStop()
    {
        BGMplayback.Stop();
    }

    /*プレーヤーの一時停止 */
    public void Pause(){
        anyPlayer.Pause(true);
    }

    /*ACB の指定 */
    public void SetAcb(CriAtomExAcb acb){
        /*ACB の保存 */
        this.acb = acb;
    }

    /*キュー名の指定 */
    public void SetCueName(string name){
        /*キュー名の保存 */
        cueName = name;
    }

    /*ボリュームの設定 */
    public void SetVolume(float vol){
        /*ボリュームの設定 */
        anyPlayer.SetVolume(vol);
        /*パラメーターの更新 */
        anyPlayer.UpdateAll();
    }

    public void Seek(float value){
        /*キューをシークさせる */
    }

    /*ボス用AISAC コントロール値の設定 */
    public void SetBossBGMAisacControl(float value){
        anyPlayer.SetAisacControl("BossBGM", value);

        /*パラメーターの更新 */
        anyPlayer.UpdateAll();
    }

    //EE用ブロックの指定
    public void SetEEBlock(int index){
        SetNextBlock(index, EEplayback);
    }
    //Kurage用ブロックの指定
    public void SetKurageBlock(int index){
        SetNextBlock(index, Kurageplayback);
    }

    //ブロック再生：ブロックの切り替え
    public void SetNextBlock(int index, CriAtomExPlayback playback){
        playback.SetNextBlockIndex(index);
    }

}
