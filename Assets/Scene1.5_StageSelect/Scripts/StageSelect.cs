using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CriWare;

public class StageSelect : MonoBehaviour
{
    //　非同期動作で使用するAsyncOperation
    private AsyncOperation async;
    //　シーンロード中に表示するUI画面
    [SerializeField]
    private GameObject loadUI;
    //　読み込み率を表示するスライダー
    [SerializeField]
    private Slider slider;

    //サウンド用
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    AtomLoader atomLoader;

    public GameObject canvas_stageselect;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadingTutorial()
    {
        // セレクトボタンを非表示
        canvas_stageselect.SetActive(false);

        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        //　コルーチンを開始
        StartCoroutine("Tutorial");
    }

    IEnumerator Tutorial()
    {
        //サウンド用
        //GameStart.menu_Sound = 4;
        playerController.SetAcb(atomLoader.acbAssets[1].Handle);
        playerController.SetCueName("Start_JINGLE");
        playerController.MenuSFXPlay();
        
        async = SceneManager.LoadSceneAsync("Scene2_Tutorial_old"); // シーンの読み込みをする

        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }

    public void LoadingMainStage()
    {
        // セレクトボタンを非表示
        canvas_stageselect.SetActive(false);

        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        //　コルーチンを開始
        StartCoroutine("MainStage");
    }

    IEnumerator MainStage()
    {
        //サウンド用
        //GameStart.menu_Sound = 4;
        playerController.SetAcb(atomLoader.acbAssets[1].Handle);
        playerController.SetCueName("Start_JINGLE");
        playerController.MenuSFXPlay();


        Time.timeScale = 1;
        async = SceneManager.LoadSceneAsync("Scene4_BossStage"); // シーンの読み込みをする

        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }

    public void Home()
    {
        GameStart.menu_Sound = 2;
        SceneManager.LoadScene("Scene1_Start");
    }
}
