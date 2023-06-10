using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscSystem : MonoBehaviour
{
    public GameObject canvas_esc;
    private GameObject cursourlocksystem;
    public GameObject canvas_option;

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
        }
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
    }

    public void GameContinue()
    {
        Time.timeScale = 1;
        cursourlocksystem.GetComponent<CursorLockSystem>().cursorlock();
        canvas_esc.SetActive(false);
    }

    public void Back()
    {
        canvas_esc.SetActive(true);
        canvas_option.SetActive(false);
        Time.timeScale = 0;
    }
}
