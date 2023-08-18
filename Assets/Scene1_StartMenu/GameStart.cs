using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject button_back;

    public GameObject button_keyconfig;
    public GameObject keyconfiggallary;
    public GameObject backgrounds;

    //canvas一覧
    public GameObject canvas_start;
    public GameObject canvas_option;
    public GameObject canvas_keyconfig;
    public GameObject canvas_credit;

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
        SceneManager.LoadScene("Scene1.5_StageSelect");
    }


    public void option()
    {
        menu_Sound = 1;
        canvas_start.SetActive(false);
        canvas_option.SetActive(true);
    }

    public void KeyConfig()
    {
        menu_Sound = 1;
        backgrounds.SetActive(false);
        keyconfiggallary.SetActive(true);
        canvas_option.SetActive(false);
        canvas_keyconfig.SetActive(true);
    }
    
    public void back1()
    {
        menu_Sound = 2;
        canvas_start.SetActive(true);
        canvas_option.SetActive(false);
        backgrounds.SetActive(true);
    }

    public void back2()
    {
        menu_Sound = 2;
        canvas_option.SetActive(true);
        canvas_keyconfig.SetActive(false);
        keyconfiggallary.SetActive(false);
        backgrounds.SetActive(true);
    }
    
    　//クレジット用
    public void back3()
    {
        menu_Sound = 2;
        canvas_start.SetActive(true);
        canvas_credit.SetActive(false);
        backgrounds.SetActive(true);
    }
    public void Credit()
    {
        menu_Sound = 1;
        canvas_start.SetActive(false);
        canvas_credit.SetActive(true);
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
