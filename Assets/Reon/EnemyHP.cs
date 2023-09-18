using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float HP = 100;
    public Slider HPBar;
    public GameObject Enemy;
    private GameObject Player;
    public GameObject damage10;
    public GameObject damage20;
    public GameObject damage50;
    private float damagecooltime;
    public GameObject damagetextposition;
    private GameObject EnemyHitDamage;


    //EnemyKill
    private GameObject enemykill;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        enemykill = GameObject.Find("EnemyKillSystem");
        EnemyHitDamage = GameObject.Find("EnemyHitDamage");
    }

    // Update is called once per frame
    void Update()
    {
        //死ぬ処理
        if (HP <= 0)
        {
            EnemyHitDamage.GetComponent<EnemyHitDamage>().EnemyDead();
            enemykill.GetComponent<EnemyKill>().getskill();
            Destroy(Enemy);
        }

        //攻撃されたとき
        if (HP <= 19)
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

                //サウンド用
                SFXplayer.damaged_Sound_E = 1;
                
                damagedisplay10(); //１０ダメージのテキストを表示
            }
            if (Player.GetComponent<SkillElectronic_new>().IsLightning == true)
            {
                HP = HP - 20;
                HPBar.value = HP;
                
                //サウンド用
                SFXplayer.damaged_Sound_E = 1;
                SFXplayer.EE_Sound = 2;

                damagedisplay20();　//２０ダメージのテキストを表示
            }
        }

        //↓カジキの場合50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            HP -= 50;
            HPBar.value = HP;
            damagedisplay50();　//５０ダメージのテキストを表示

            //サウンド用
            SFXplayer.damaged_Sound_E = 3;
        }

        //↓ウナギの場合20DMG
        if (other.gameObject.CompareTag("UnagiAttack"))
        {
            HP -= 20;
            HPBar.value = HP;
            damagedisplay20(); //２０ダメージのテキストを表示

            //サウンド用
            SFXplayer.damaged_Sound_E = 1;
            SFXplayer.EE_Sound = 2;
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
