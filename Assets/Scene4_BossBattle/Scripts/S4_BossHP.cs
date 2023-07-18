using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S4_BossHP : MonoBehaviour
{
    public Slider slider_bosshp;
    public int hp = 3000;
    public GameObject gameclearsystem;
    public GameObject bosssystems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            gameclearsystem.SetActive(true);
            bosssystems.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            hp -= 10;
            slider_bosshp.value = hp;
        }

        //«ƒJƒWƒL‚Ìê‡50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            hp -= 50;
            slider_bosshp.value = hp;
        }
    }
}
