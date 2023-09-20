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
    public GameObject canvas_language;

    // はるま用サウンド変数
    public static int menu_Sound; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Language()
    {
        canvas_language.SetActive(true);
        canvas_option.SetActive(false);
    }

    public void gamestart()
    {
        menu_Sound = 1;
        Debug.Log(menu_Sound);
        SceneManager.LoadScene("Scene1.5_StageSelect");
    }


    public void option()
    {
        canvas_start.SetActive(false);
        canvas_option.SetActive(true);
        menu_Sound = 1;
        Debug.Log(menu_Sound);
    }

    public void KeyConfig()
    {
        backgrounds.SetActive(false);
        keyconfiggallary.SetActive(true);
        canvas_option.SetActive(false);
        canvas_keyconfig.SetActive(true);
        menu_Sound = 1;
        Debug.Log(menu_Sound);
    }
    
    public void back1()
    {
        canvas_start.SetActive(true);
        canvas_option.SetActive(false);
        backgrounds.SetActive(true);
        canvas_language.SetActive(false);
        menu_Sound = 2;
        Debug.Log(menu_Sound);
    }

    public void back2()
    {
        canvas_option.SetActive(true);
        canvas_keyconfig.SetActive(false);
        keyconfiggallary.SetActive(false);
        canvas_language.SetActive(false);
        backgrounds.SetActive(true);
        menu_Sound = 2;
        Debug.Log(menu_Sound);
    }
    
    　//クレジット用
    public void back3()
    {
        canvas_start.SetActive(true);
        canvas_credit.SetActive(false);
        backgrounds.SetActive(true);
        menu_Sound = 2;
        Debug.Log(menu_Sound);
    }
    public void Credit()
    {
        canvas_start.SetActive(false);
        canvas_credit.SetActive(true);
        menu_Sound = 1;
        Debug.Log(menu_Sound);
    }


    public void quit()
    {
        menu_Sound = 2;
        Debug.Log(menu_Sound);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

}
