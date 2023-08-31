using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip3 : MonoBehaviour
{
    GameObject player;
    public GameObject nextcanvas;
    public GameObject panel3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //↓もしカジキを10匹手に入れたら
        if (player.GetComponent<GetSkill>().a_Kajiki >= 10)
        {
            //サウンド用
            SFXplayer.radio_Sound = 1;

            nextcanvas.SetActive(true); //次のセリフを表示
            panel3.SetActive(false); //左上のヒントを非表示
            gameObject.SetActive(false); //このスクリプトをつけてるオブジェクトを非表示
        }
    }
}
