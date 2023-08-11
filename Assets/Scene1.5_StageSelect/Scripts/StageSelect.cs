using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tutorial()
    {
        GameStart.menu_Sound = 4;
        SceneManager.LoadScene("Scene2_Tutorial");
    }

    public void MainStage()
    {
        GameStart.menu_Sound = 4;
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene4_BossStage");
    }

    public void Home()
    {
        GameStart.menu_Sound = 2;
        SceneManager.LoadScene("Scene1_Start");
    }
}
