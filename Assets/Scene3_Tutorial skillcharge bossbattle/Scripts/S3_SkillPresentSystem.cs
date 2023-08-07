using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3_SkillPresentSystem : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject enemybattlesystem;
    private GameObject enemykillsystem;
    private bool ispresent;

    // Start is called before the first frame update
    void Start()
    {
        enemykillsystem = GameObject.Find("EnemyKillSystem");
        ispresent = true;
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length == enemybattlesystem.GetComponent<EnemyBattleSystem>().enemyamountsave && ispresent == true)
        {
            present();
        }
    }

    public void present()
    {
        enemykillsystem.GetComponent<EnemyKill>().getskill();
        enemykillsystem.GetComponent<EnemyKill>().getskill();
        enemykillsystem.GetComponent<EnemyKill>().getskill();
        ispresent = false;
    }
}
