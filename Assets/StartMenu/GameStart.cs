using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CriWare;

public class GameStart : MonoBehaviour
{
    public GameObject canvas;
    public GameObject storytext;
    public GameObject backbutton;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private AtomLoader atomLoader;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gamestart()
    {
        SceneManager.LoadScene("Scene_Tutorial");
    }

    public void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        playerController.SetAcb(atomLoader.acbAssets[0].Handle);
        playerController.SetCueName("Tutorial_BGM");
        Debug.Log("Tutorial_BGM");
        playerController.Play();
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
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

}
