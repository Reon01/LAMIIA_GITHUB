using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider slider_timer;
    public GameObject player;
    public GameObject warppoint;
    public GameObject mediumbosssystem;
    public GameObject mediumboss;

    private GameObject[] enemy;
    public int amount;
    public GameObject enemybattlesystem;
    private GameObject skillcheat;

    // Start is called before the first frame update
    void Start()
    {
        skillcheat = GameObject.Find("SkillCheat");
    }

    // Update is called once per frame
    void Update()
    {
        amount = enemybattlesystem.GetComponent<EnemyBattleSystem>().enemyamountsave;
        if (slider_timer.value <= 0)
        {
            warp();
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemy.Length == amount)
            {
                skillcheat.GetComponent<PV_SkillCheat>().cheat();
                Debug.Log("スキル配布");
            }
            gameObject.SetActive(false);
        }
    }

    public void warp()
    {
        player.GetComponent<CharacterController>().enabled = false;
        Vector3 point = warppoint.transform.position;
        player.transform.position = point;
        mediumbosssystem.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
    }
}
