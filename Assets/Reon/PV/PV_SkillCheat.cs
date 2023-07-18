using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PV_SkillCheat : MonoBehaviour
{
    public GameObject enemykill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cheat();
        }
    }

    public void cheat()
    {
        enemykill.GetComponent<EnemyKill>().getskill();
    }
}
