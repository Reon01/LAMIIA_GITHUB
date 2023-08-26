using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearSystem : MonoBehaviour
{
    public GameObject cleartext;
    public GameObject button_next;

    // Start is called before the first frame update
    void Start()
    {
        cleartext.SetActive(true);
        button_next.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //サウンド用
        GameStart.menu_Sound = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void next()
    {
        //サウンド用
        GameStart.menu_Sound = 1;

        SceneManager.LoadScene("Scene1.5_StageSelect");
    }

    public void startscene()
    {
        //サウンド用
        GameStart.menu_Sound = 1;

        SceneManager.LoadScene("Scene1_Start");
    }
}
