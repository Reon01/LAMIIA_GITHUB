using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider HPBar;
    public float HP = 100;

    //HP数字表示
    public Text Text_HP;
    public int HP_num = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text_HP.text = "HP:" + HP_num;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HP -= 10;
            HPBar.value = HP;
            HP_num -= 10;
        }
    }

    
    public void kaihuku()
    {
        if (HP <= 90) //HPが９０以下の時のみ回復できる（HP上限は１００）
        {
            HP += 10;
            HPBar.value = HP;
            HP_num += 10;
        }
    }
}
