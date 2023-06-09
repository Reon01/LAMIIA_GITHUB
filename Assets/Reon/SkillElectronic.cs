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

    //はるまサウンド用変数
    public static int EE_Sound = 0;


    // Start is called before the first frame update
    void Start()
    {
        IsLightning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isSkill == true &&
            GetComponent<GetSkill>().a_Unagi >= 1)
        {
            Lightning.SetActive(true);
            IsLightning = true;
            spend();
            iscount = true;
            isSkill = false;

            EE_Sound = 1;
        }


        if (iscount == true)
        {
            count += Time.deltaTime;          
            if (count >= 3)
            {
                Lightning.SetActive(false);
                IsLightning = false;
                isSkill = true;
                count = 0;
                iscount = false;

                EE_Sound = 3;
            }
        }
    }

    public void spend()
    {
        GetComponent<GetSkill>().a_Unagi -= 1; //スキルを１消費
    }
}
