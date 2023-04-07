using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kurage : MonoBehaviour
{
    public GameObject kuragesield, player;
    public int kuragesieldHP;
    public bool isSkill;

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
        if (Input.GetKeyDown(KeyCode.F) && kuragesield.activeSelf == false && isSkill == true)
        {
            kuragesield.SetActive(true);
            kuragesieldHP = 1;
            player.GetComponent<PlayerHP>().kaihuku();
        }
        if (kuragesieldHP == 0)
        {
            kuragesield.SetActive(false);
        }

    }
    public void damage()
    {

        kuragesieldHP -= 1;

    }
}
