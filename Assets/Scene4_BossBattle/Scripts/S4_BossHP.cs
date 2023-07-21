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

    //↓ダメージ表記用
    public GameObject damage10;
    public GameObject damage20;
    public GameObject damage50;
    public float damagecooltime;
    public GameObject damagetextposition;

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
            damagedisplay10(); //１０ダメージのテキストを表示
        }

        //↓カジキの場合50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            hp -= 50;
            slider_bosshp.value = hp;
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
