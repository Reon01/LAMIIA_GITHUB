using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider HPBar;
    public int HP = 100;

    //HP数字表示
    public Text Text_HP;
    public int HP_num = 100;

    //死んだときに表示する
    public GameObject canvas_restart;
    private GameObject cursorlocksystem;

    //はるまサウンド用変数
    public static bool damaged_Sound_P = false;

    // Start is called before the first frame update
    void Start()
    {
        cursorlocksystem = GameObject.Find("CursorLockSystem");
    }

    // Update is called once per frame
    void Update()
    {
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;

        if (HP <= 0)
        {
            dead();
        }
    }

    public void damage()
    {
        damaged_Sound_P = true;
        HP -= 10;
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
    }

    public void speirdamage()
    {
        damaged_Sound_P = true;
        HP -= 5;
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
    }

    public void kaihuku()
    {
        if (HP <= 90) //HPが９０以下の時のみ回復できる（HP上限は１００）
        {
            HP += 10;
            HPBar.value = HP;
            HP_num = HP;
            Text_HP.text = "HP:" + HP_num;
            Debug.Log("クラゲ回復");
        }
    }

    public void maxheal()
    {
        HP = 100;
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        Debug.Log("maxheal");
    }

    public void dead()
    {
        canvas_restart.SetActive(true);
        Time.timeScale = 0;
        cursorlocksystem.GetComponent<CursorLockSystem>().cursoropen();
        Debug.Log("死んだｗ");
    }
}
