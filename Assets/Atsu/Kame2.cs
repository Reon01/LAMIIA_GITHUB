using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kame2 : MonoBehaviour
{
    public GameObject Turtle;
    public float i;
    public bool iscount;
    private bool cooltime = true; //スキルのクールタイム

    //スキルを使ったかをGetSkillに送るためのbool
    public bool spendskill;

    //PlayerについてるGetSkillScriptから、数を取得
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        int amountkame = player.GetComponent<GetSkill>().a_Kame;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && cooltime == true && player.GetComponent<GetSkill>().a_Kame >= 1)
        {
            Turtle.SetActive(true);
            iscount = true;
            player.GetComponent<GetSkill>().a_Kame -= 1;
            spendskill = true;
            cooltime = false;
        }

        if (iscount == true)
        {
            i++;
            if (i >= 300)
            {
                Turtle.SetActive(false);
                i = 0;
                iscount = false;
                cooltime = true;
            }
        }
    }
}
