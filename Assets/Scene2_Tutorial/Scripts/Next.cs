using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public GameObject canvas_next;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || 
            other.gameObject.CompareTag("Weapon"))
        {
            warning1();
            Time.timeScale = 0;
        }
    }

    //プレイヤーと接触したらテキストを表示
    public void warning1()
    {
        canvas_next.SetActive(true);

        //カーソル再表示
        Cursor.visible = true;
        //カーソルロックを解除
        Cursor.lockState = CursorLockMode.Confined;
    }

    //はいのボタンを押した場合
    public void Yes()
    {
        Time.timeScale = 1;
        canvas_next.SetActive(false);

        //カーソル再表示
        Cursor.visible = false;
        //カーソルロックを解除
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Scene4_BossStage");
    }

    //いいえのボタンを押した場合
    public void No()
    {
        Time.timeScale = 1;
        canvas_next.SetActive(false);

        //カーソル再表示
        Cursor.visible = false;
        //カーソルロックを解除
        Cursor.lockState = CursorLockMode.Locked;
    }
}
