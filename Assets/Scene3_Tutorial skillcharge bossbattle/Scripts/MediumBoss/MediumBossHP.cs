using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumBossHP : MonoBehaviour
{
    public Slider slider_mediumbosshp;
    private int hp;
    private GameObject mediumbosssystem;
    public GameObject gameclearsystem;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        mediumbosssystem = GameObject.Find("MediumBossSystem");
        player = GameObject.Find("Player");
        hp = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            gameclearsystem.SetActive(true);
            Time.timeScale = 0;
            Destroy(mediumbosssystem);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            hp -= 10;
            slider_mediumbosshp.value = hp;
        }

        
        //«ƒJƒWƒL‚Ìê‡50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            hp -= 50;
            slider_mediumbosshp.value = hp;
        }
    }
}
