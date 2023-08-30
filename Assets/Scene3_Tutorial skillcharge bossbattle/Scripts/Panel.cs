using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private GameObject[] enemy;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length == 0)
        {
            //サウンド用
            SFXplayer.radio_Sound = 1;

            canvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void CountStart()
    {

    }
}
