using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip8 : MonoBehaviour
{
    private GameObject player;
    public GameObject nextcanvas;
    public GameObject panel8;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //↓もしクラゲを3匹使用したら
        if (player.GetComponent<GetSkill>().a_Kurage <= 9)
        {
            nextcanvas.SetActive(true); //次のセリフを表示
            panel8.SetActive(false); //左上のヒントを非表示
            gameObject.SetActive(false); //このスクリプトをつけてるオブジェクトを非表示
        }
    }
}
