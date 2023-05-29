﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* (1) 名前空間の設定 */
using CriWare;
/*ここではデータを参照しないので、Assetのやつは書かない*/

public class PlayerController : MonoBehaviour
{
    /* (2) プレーヤー */
    private CriAtomExPlayer SFXplayer;
    /* (12) ACB 情報 */
    private CriAtomExAcb acb;

    /* (16) キュー名 */
    private string cueName;
    /* (3) コルーチン化する */
    IEnumerator Start()
    {
        /* (4) ライブラリの初期化済みチェック */
        while (!CriWareInitializer.IsInitialized())
        {
            yield return null;
        }

        /* (5) プレーヤーの作成 */
        SFXplayer = new CriAtomExPlayer();
    }

    void Update(){}

    public void Play()
    {
        /* (10) ポーズ状態に応じた処理 */
        if (SFXplayer.IsPaused())
        {
            /* (11) ポーズの解除 */
            SFXplayer.Pause(false);
        }
        else
        {

            /* (18) キュー情報をプレーヤー設定 */
            SFXplayer.SetCue(acb, cueName);
            /* (7) プレーヤーの再生 */
            SFXplayer.Start();
        }
    
    }

    /* (8) プレーヤーの停止 */
    public void Stop()
    {
        /* (8) プレーヤーの停止 */
        SFXplayer.Stop();
    }

    /* (9) プレーヤーの一時停止 */
    public void Pause()
    {
        /* (9) プレーヤーの一時停止 */
        SFXplayer.Pause(true);
    }

    /* (12) ACB の指定 */
    public void SetAcb(CriAtomExAcb acb)
    {
        /* (14) ACB の保存 */
        this.acb = acb;
    }

    /* (15) キュー名の指定 */
    public void SetCueName(string name)
    {
        /* (17) キュー名の保存 */
        cueName = name;
    }

    /* (19) ボリュームの設定 */
    public void SetVolume(float vol)
    {
        /* (19) ボリュームの設定 */
        SFXplayer.SetVolume(vol);
        /* (20) パラメーターの更新 */
        SFXplayer.UpdateAll();
    }

    public void Seek(float value)
    {
        /* (Ex) キューをシークさせる */
    }

    /* (21) AISAC コントロール値の設定 */
    public void SetAisacControl(float value)
    {
        /* (21) AISAC コントロール値の設定 */
        SFXplayer.SetAisacControl("Any", value);

        /* (22) パラメーターの更新 */
        SFXplayer.UpdateAll();
    }
}
