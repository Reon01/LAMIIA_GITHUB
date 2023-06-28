using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kurage : MonoBehaviour
{
    public GameObject kuragesield, player;
    public int kuragesieldHP;
    public bool isSkill;

    //はるまサウンド用
    public static bool Kurage_Sound_s = false;
    public static bool Kurage_Sound_e = false;

    // Start is called before the first frame update
    void Start()
    {
        kuragesield.SetActive(false);
        kuragesieldHP = 0;
        isSkill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && kuragesield.activeSelf == false && isSkill == true && 
            GetComponent<GetSkill>().a_Kurage >= 1)
        {
            kuragesield.SetActive(true);
            kuragesieldHP = 1;
            player.GetComponent<PlayerHP>().kaihuku();
            GetComponent<GetSkill>().a_Kurage -= 1; //スキルを１消費

            //はるまサウンド用変数true
            Kurage_Sound_s = true;
        }

        if (kuragesieldHP <= 0)
        {
            kuragesield.SetActive(false);
            //Debug.Log("クラゲ消滅");
        }

    }
    public void damage()
    {
        //kuragesieldHP -= 1;
        kuragesield.SetActive(false);
        Debug.Log("クラゲ消滅");
        Kurage_Sound_e = true;
    }
}
