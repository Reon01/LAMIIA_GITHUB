using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKurageScene04 : MonoBehaviour
{
    private GameObject enemykill;
    public GameObject player;

    //↓クラゲシステム
    public bool iskurage;
    public GameObject kuragesield;
    public int kuragesieldHP;

    //はるまサウンド用変数
    public static bool Kurage_Sound_s_2 = false;
    public static bool Kurage_Sound_e_2 = false;

    void Start()
    {
        enemykill = GameObject.Find("EnemyKillSystem");
    }

    private void Update()
    {
        if (kuragesieldHP == 0)
        {
            kuragesield.SetActive(false);
        }
    }

    public void KurageScene04()
    {
        if (iskurage == true && enemykill.GetComponent<EnemyKill>().a_Kurage >= 1)
        {
            Kurage();
        }

    }


    public void Kurage()
    {
        kuragesield.SetActive(true);
        kuragesieldHP = 1;
        player.GetComponent<PlayerHP>().kaihuku();
        enemykill.GetComponent<EnemyKill>().a_Kurage -= 1;
        Debug.Log("クラゲ使用");

        Kurage_Sound_s_2 = true;
    }

    public void damage()
    {
        kuragesieldHP -= 1;

        Kurage_Sound_e_2 = true;
    }


}
