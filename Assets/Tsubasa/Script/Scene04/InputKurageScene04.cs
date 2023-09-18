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

        //サウンド用
        if(enemykill.GetComponent<EnemyKill>().a_Kurage >= 1){
            SFXplayer.c_Jf_S = true;
        }
        else{
            SFXplayer.c_Jf_S = false;
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

        SFXplayer.Jf_S = 1;
    }

    public void damage()
    {
        kuragesieldHP -= 1;

        SFXplayer.Jf_S = 2;
    }


}
