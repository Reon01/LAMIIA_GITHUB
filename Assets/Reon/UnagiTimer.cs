using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnagiTimer : MonoBehaviour
{
    public bool iscount = false;
    public float count;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (iscount == true)
        {
            count += Time.deltaTime;
            if (count >= 3)
            {
                //Scene2—p
                //player.GetComponent<SkillElectronic>().Lightning.SetActive(false);
                player.GetComponent<SkillElectronic>().IsLightning = false;
                player.GetComponent<SkillElectronic>().isSkill = true;

                count = 0;
                iscount = false;

                SkillElectronic.EE_Sound = 3;
            }
        }
    }
}
