using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP_Rare : MonoBehaviour
{
    public float HP = 150;
    public Slider HPBar;
    public GameObject rareenemy;
    private GameObject Player;
    public GameObject damage10;
    public GameObject damage20;
    public GameObject damage50;
    private float damagecooltime;
    public GameObject damagetextposition;


    //EnemyKill
    private GameObject enemykill;

    //はるまサウンド用変数
    public static int damaged_Sound_E;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        enemykill = GameObject.Find("EnemyKillSystem");
    }

    // Update is called once per frame
    void Update()
    {
        //死ぬ処理
        if (HP <= 0)
        {
            enemykill.GetComponent<EnemyKill>().getskill();
            enemykill.GetComponent<EnemyKill>().getskill();
            Destroy(rareenemy);

            damaged_Sound_E = 2;
        }

        //攻撃されたとき
        if (HP <= 140)
        {
            this.GetComponent<FishMove>().getdamage = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (Player.GetComponent<SkillElectronic_new>().IsLightning == false)
            {
                HP = HP - 10;
                HPBar.value = HP;
                damaged_Sound_E = 1;
                damagedisplay10(); //１０ダメージのテキストを表示
            }
            if (Player.GetComponent<SkillElectronic_new>().IsLightning == true)
            {
                HP = HP - 20;
                HPBar.value = HP;
                damaged_Sound_E = 1;

                SkillElectronic.EE_Sound = 2;
                damagedisplay20();　//２０ダメージのテキストを表示
            }
        }

        //↓カジキの場合50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            HP -= 50;
            HPBar.value = HP;
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
