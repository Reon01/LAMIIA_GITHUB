using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillElectronic : MonoBehaviour
{
    public GameObject Lightning;
    public bool IsLightning;
    public bool isSkill;

    public bool iscount;
    public float count;

    private GameObject unagitimer;

    //はるまサウンド用変数
    public static int EE_Sound = 0;


    // Start is called before the first frame update
    void Start()
    {
        IsLightning = false;
        unagitimer = GameObject.Find("UnagiTimer");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isSkill == true &&
            GetComponent<GetSkill>().a_Unagi >= 1)
        {
            Lightning.SetActive(true);
            IsLightning = true;
            spend();
            iscount = true;
            isSkill = false;
            unagitimer.GetComponent<UnagiTimer>().iscount = true;

            EE_Sound = 1;
        }
    }

    public void spend()
    {
        GetComponent<GetSkill>().a_Unagi -= 1; //スキルを１消費
    }
}
