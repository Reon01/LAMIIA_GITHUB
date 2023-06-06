using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumBossHP : MonoBehaviour
{
    public Slider slider_mediumbosshp;
    private int hp = 200;
    private GameObject mediumbosssystem;
    public GameObject gameclearsystem;

    // Start is called before the first frame update
    void Start()
    {
        mediumbosssystem = GameObject.Find("MediumBossSystem");
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
    }
}
