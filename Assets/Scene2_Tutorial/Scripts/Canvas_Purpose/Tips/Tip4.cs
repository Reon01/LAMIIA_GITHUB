using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip4 : MonoBehaviour
{
    private GameObject[] enemytag;
    public GameObject nextcanvas;
    public GameObject panel4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemytag = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemytag.Length == 0)
        {
            //サウンド用
            SFXplayer.radio_Sound = 1;

            nextcanvas.SetActive(true); //次のセリフを表示
            panel4.SetActive(false); //左上のヒントを非表示
            gameObject.SetActive(false); //このスクリプトをつけてるオブジェクトを非表示
        }
    }
}
