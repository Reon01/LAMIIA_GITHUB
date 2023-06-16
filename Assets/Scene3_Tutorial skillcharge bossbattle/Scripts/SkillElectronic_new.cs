using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillElectronic_new : MonoBehaviour
{
    public GameObject Lightning;
    public bool IsLightning;
    public bool isSkill;

    public bool iscount;
    public float count;

    // Start is called before the first frame update
    void Start()
    {
        IsLightning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (iscount == true)
        {
            count += Time.deltaTime;
            if (count >= 3)
            {
                Lightning.SetActive(false);
                IsLightning = false;
                count = 0;
                iscount = false;

                SkillElectronic.EE_Sound = 3;
            }
        }
    }

    public void skill()
    {
        Lightning.SetActive(true);
        IsLightning = true;
        iscount = true;

        SkillElectronic.EE_Sound = 1;
    }
}