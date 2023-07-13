using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        SceneManager.LoadScene("Scene3_Tutorial skillcharge bossbattle");
    }

    public void S4restart()
    {
        SceneManager.LoadScene("Scene4_BossStage");
    }
}
