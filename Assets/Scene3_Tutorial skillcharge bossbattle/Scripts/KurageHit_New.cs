using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurageHit_New : MonoBehaviour
{
    private GameObject fishskillsystem;

    // Start is called before the first frame update
    void Start()
    {
        fishskillsystem = GameObject.Find("FishSkillSystem");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //fishskillsystem.GetComponent<FishSkillSystem>().damage();　ボツ案
            fishskillsystem.GetComponent<InputKurageScene04>().damage();
        }
        else if (other.CompareTag("MediumBoss"))
        {
            //fishskillsystem.GetComponent<FishSkillSystem>().damage();　ボツ案
            fishskillsystem.GetComponent<InputKurageScene04>().damage();
        }
        else if (other.CompareTag("Boss"))
        {
            //fishskillsystem.GetComponent<FishSkillSystem>().damage();　ボツ案
            fishskillsystem.GetComponent<InputKurageScene04>().damage();
        }
        else if (other.CompareTag("EnemyAttack"))
        {
            //fishskillsystem.GetComponent<FishSkillSystem>().damage();　ボツ案
            fishskillsystem.GetComponent<InputKurageScene04>().damage();
        }

    }
}
