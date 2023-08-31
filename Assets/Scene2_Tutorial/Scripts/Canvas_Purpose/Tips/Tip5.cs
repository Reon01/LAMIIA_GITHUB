using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip5 : MonoBehaviour
{
    private GameObject player;
    public GameObject nextcanvas;
    public GameObject panel5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //↓もしウナギを10匹手に入れたら
        if (player.GetComponent<GetSkill>().a_Unagi >= 10)
        {
            //サウンド用
            SFXplayer.radio_Sound = 1;

            nextcanvas.SetActive(true); //次のセリフを表示
            panel5.SetActive(false); //左上のヒントを非表示
            gameObject.SetActive(false); //このスクリプトをつけてるオブジェクトを非表示
        }
    }
}
