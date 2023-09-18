using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIOnOff : MonoBehaviour
{
    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject Canvas3;
    public GameObject Skill;
    public GameObject HP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Canvas1.activeInHierarchy == false)&& (Canvas2.activeInHierarchy == false) && (Canvas3.activeInHierarchy == false))
        {
            HP.SetActive(true);
            Skill.SetActive(true);
        }
    }
}
