using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscSystemTute : MonoBehaviour
{
    public GameObject canvas_esc;
    private GameObject cursourlocksystem;
    public GameObject canvas_option;
    public GameObject story;
    public GameObject story2;
    public GameObject story3;



    // Start is called before the first frame update
    void Start()
    {
        cursourlocksystem = GameObject.Find("CursorLockSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            canvas_esc.SetActive(true);

            GameStart.menu_Sound = 1;
        }
    }

    public void MainMnyuu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        canvas_esc.SetActive(true);

        GameStart.menu_Sound = 1;
    }

    public void quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

    public void Options()
    {
        canvas_option.SetActive(true);
        canvas_esc.SetActive(false);

        GameStart.menu_Sound = 1;
    }

    public void GameContinue()
    {
        if (story.activeInHierarchy == false&& story2.activeInHierarchy == false && story3.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }
        
        cursourlocksystem.GetComponent<CursorLockSystem>().cursorlock();
        canvas_esc.SetActive(false);

        GameStart.menu_Sound = 2;
    }

    public void Home()
    {
        SceneManager.LoadScene("Scene1_Start");
    }

    public void Back()
    {
        canvas_esc.SetActive(true);
        canvas_option.SetActive(false);
        Time.timeScale = 0;

        GameStart.menu_Sound = 2;
    }
}
