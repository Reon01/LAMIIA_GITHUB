using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider HPBar;
    public int HP = 100;

    //HPêîéöï\é¶
    public Text Text_HP;
    public int HP_num = 100;

    //éÄÇÒÇæÇ∆Ç´Ç…ï\é¶Ç∑ÇÈ
    public GameObject canvas_restart;
    private GameObject cursorlocksystem;

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
        HP -= 10;
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
    }

    public void kaihuku()
    {
        if (HP <= 90) //HPÇ™ÇXÇOà»â∫ÇÃéûÇÃÇ›âÒïúÇ≈Ç´ÇÈÅiHPè„å¿ÇÕÇPÇOÇOÅj
        {
            HP += 10;
            HPBar.value = HP;
            HP_num = HP;
            Text_HP.text = "HP:" + HP_num;
            Debug.Log("ÉNÉâÉQâÒïú");
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
        Debug.Log("éÄÇÒÇæÇó");
    }
}
