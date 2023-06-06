using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S4_SkillChargeTimer:MonoBehaviour
{
    public GameObject canvas_skillcharge;
    public Slider skillchargetimer;
    public float timer;
    private bool istimer;
    private GameObject enemydestroysystem;

    // Start is called before the first frame update
    void Start()
    {
        istimer = true;
        enemydestroysystem = GameObject.Find("EnemyDestroySystem");
    }

    // Update is called once per frame
    void Update()
    {
        skillchargetimer.value = timer;
        if (istimer == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                canvas_skillcharge.SetActive(false);
                enemydestroysystem.GetComponent<S4_EnemyDestroySystem>().enabled = true;
                timer = 1;
                istimer = false;
            }
        }
    }
}
