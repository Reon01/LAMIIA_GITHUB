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

    //↓ダメージ表記用
    public GameObject damage10;
    public GameObject damage20;
    public GameObject damage50;
    public float damagecooltime;
    public GameObject damagetextposition;

    // Start is called before the first frame update
    void Start()
    {
        mediumbosssystem = GameObject.Find("MediumBossSystem");
        player = GameObject.Find("Player");
        hp = 1000;
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
            damagedisplay10(); //１０ダメージのテキストを表示
        }

        
        //↓カジキの場合50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            hp -= 50;
            slider_mediumbosshp.value = hp;
            damagedisplay50();　//５０ダメージのテキストを表示
        }
    }

    //１０ダメージのテキストを表示
    public void damagedisplay10()
    {
        Instantiate(damage10, damagetextposition.transform.position, Quaternion.identity);
    }
    //２０ダメージのテキストを表示
    public void damagedisplay20()
    {
        Instantiate(damage20, damagetextposition.transform.position, Quaternion.identity);
    }
    //５０ダメージのテキストを表示
    public void damagedisplay50()
    {
        Instantiate(damage50, damagetextposition.transform.position, Quaternion.identity);
    }
}
