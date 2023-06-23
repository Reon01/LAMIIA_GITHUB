using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* (1) 名前空間の設定 */
using CriWare;
using CriWare.Assets;

public class AtomLoader : MonoBehaviour
{
    public bool dontDestroyOnLoad = true;

    void Awake()
    {
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    /* (9) 全データがロード済みかどうか(他コンポーネントへの返答用) */
    public bool isLoaded
    {
        get
        {
            /* (11) 各データがロード済みかどうかをチェック(=の前に|を挟む) */
            bool value = acfIsRegisterd;

            foreach (var acbAsset in acbAssets)
            {
                value |= acbAsset.Loaded;
            }

            return value;
        }
    }



    /* (2) ACF アセット */
    public CriAtomAcfAsset acfAsset;

    /* (3) ACB アセットの配列 */
    /* Note: ACB は複数ファイルになっている可能性があるため */
    public CriAtomAcbAsset[] acbAssets;

    /* (10) レジスト済みかどうかのフラグ */
    private bool acfIsRegisterd = false;

    /* (4) コルーチン化(whileで止まらず他の処理に進んでくれるようになる) */
    IEnumerator Start()
    {
        /* (5) ライブラリの初期化済みチェック */
        while (!CriWareInitializer.IsInitialized())
        {
            yield return null;
        }

        /* (6) ACF データの登録 */
        acfIsRegisterd = acfAsset.Register();

        /* (7) デフォルトの DSP バス設定を適応(レジストしないと、カッコの中身が動かない) */
        CriAtomEx.AttachDspBusSetting(CriAtomExAcf.GetDspSettingNameByIndex(0));

        /* (8) ACB データ(キューシート)のロード(foreachはacbAssetsの中身を要素分だけ見つけてくれる) */
        foreach (var acbAsset in acbAssets)
        {
            if (!acbAsset.LoadRequested) acbAsset.LoadImmediate();
        }
    }
}
