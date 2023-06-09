using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider HPBar;
    public int HP = 100;

    //HP”š•\¦
    public Text Text_HP;
    public int HP_num = 100;

    //€‚ñ‚¾‚Æ‚«‚É•\¦‚·‚é
    public GameObject canvas_restart;
    private GameObject cursorlocksystem;

    //‚Í‚é‚ÜƒTƒEƒ“ƒh—p•Ï”
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

    public void kaihuku()
    {
        if (HP <= 90) //HP‚ª‚X‚OˆÈ‰º‚Ì‚Ì‚İ‰ñ•œ‚Å‚«‚éiHPãŒÀ‚Í‚P‚O‚Oj
        {
            HP += 10;
            HPBar.value = HP;
            HP_num = HP;
            Text_HP.text = "HP:" + HP_num;
            Debug.Log("ƒNƒ‰ƒQ‰ñ•œ");
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
        Debug.Log("€‚ñ‚¾‚—");
    }
}
