using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject canvas;
    public GameObject storytext;
    public GameObject backbutton;

    // �͂�ܗp�T�E���h�ϐ�
    public static bool menu_C = false;

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
        menu_C = true;
        SceneManager.LoadScene("Scene2_Tutorial");
    }


    public void keyconfig()
    {

    }

    public void story()
    {
        canvas.SetActive(false);
        storytext.SetActive(true);
        backbutton.SetActive(true);
    }

    public void back()
    {
        canvas.SetActive(true);
        storytext.SetActive(false);
        backbutton.SetActive(false);
    }

    public void quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }

}
