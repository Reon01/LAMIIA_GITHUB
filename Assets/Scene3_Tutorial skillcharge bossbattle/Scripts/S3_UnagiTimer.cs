using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3_UnagiTimer : MonoBehaviour
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
                player.GetComponent<SkillElectronic_new>().Lightning.SetActive(false);
                player.GetComponent<SkillElectronic_new>().IsLightning = false;

                count = 0;
                iscount = false;

                SkillElectronic.EE_Sound = 3;
            }
        }
    }
}
