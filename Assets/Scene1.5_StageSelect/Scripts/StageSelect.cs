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
        SceneManager.LoadScene("Scene2_Tutorial");
    }

    public void MainStage()
    {
        SceneManager.LoadScene("Scene4_BossStage");
    }
}
