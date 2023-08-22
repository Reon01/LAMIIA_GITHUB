using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject canvas_stageselect;

    // Start is called before the first frame update
    void Start()
    {

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
        GameStart.menu_Sound = 4;
        async = SceneManager.LoadSceneAsync("Scene2_Tutorial"); // シーンの読み込みをする

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
        GameStart.menu_Sound = 4;
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
