using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IgnoreSystem : MonoBehaviour
{
    public bool iscount;
    public bool iscount2;
    public float count;
    public float count2;
    public GameObject text1;
    public GameObject text2;

    private GameObject cursourlocksystem;

    // Start is called before the first frame update
    void Start()
    {
        iscount = true; //初めにカウントをオンにする
        cursourlocksystem = GameObject.Find("CursourLockSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (iscount == true) //もしカウントが始まったら
        {
            count += Time.deltaTime; 
            if (count >= 30) //もし３０秒が経過したら
            {
                text1open();　//テキストを表示
                count = 0;　//カウントを０に戻す
                iscount = false;　//カウントを止める
                iscount2 = true; //次のカウントを始める
            }
        }

        if (iscount2 == true)
        {
            count2 += Time.deltaTime;
            if (count2 >= 30) //３０秒＋３０秒の計１分が経過した場合
            {
                text2open();　//テキスト、ボタンを表示
            }
        }
    }

    public void text1open()
    {
        text1.SetActive(true);　//テキストを表示
    }

    public void text2open()
    {
        text2.SetActive(true);　//テキストを表示
        count2 = 0; //カウントを０に戻す
        iscount2 = false;　//カウントを止める
    }

    public void yes() //はいを押した場合
    {
        SceneManager.LoadScene("Scene2_Tutorial(2)");　//左のシーンをやり直す
    }

    public void no()　//いいえを押した場合
    {
        text2.SetActive(false);　//テキストを非表示にする
        Time.timeScale = 1;
        cursourlocksystem.GetComponent<CursorLockSystem>().cursorlock();
    }
}
