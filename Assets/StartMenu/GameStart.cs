using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject canvas;
    public GameObject storytext;
    public GameObject backbutton;

    // はるま用サウンド変数
    public static int menu_Sound = 0; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gamestart()
    {
        menu_Sound = 1;
        SceneManager.LoadScene("Scene2_Tutorial");
    }


    public void keyconfig()
    {
        menu_Sound = 1;

    }

    public void story()
    {
        menu_Sound = 1;
        canvas.SetActive(false);
        storytext.SetActive(true);
        backbutton.SetActive(true);
    }

    public void back()
    {
        menu_Sound = 2;
        canvas.SetActive(true);
        storytext.SetActive(false);
        backbutton.SetActive(false);
    }

    public void quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

}
