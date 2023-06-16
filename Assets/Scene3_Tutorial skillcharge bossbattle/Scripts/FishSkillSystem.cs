using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSkillSystem : MonoBehaviour
{
    public bool iskajiki;
    public bool isunagi;
    public bool iskurage;

    private GameObject enemykill;
    public GameObject player;
    private GameObject cursorlocksystem;
    public GameObject Canvas_SkillSelect;

    //↓クラゲシステム
    public GameObject kuragesield;
    public int kuragesieldHP;

    //はるまサウンド用変数
    public static bool Kurage_Sound_s_2 = false;
    public static bool Kurage_Sound_e_2 = false;

    // Start is called before the first frame update
    void Start()
    {
        enemykill = GameObject.Find("EnemyKillSystem");
        cursorlocksystem = GameObject.Find("CursorLockSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (iskajiki == true && Input.GetKeyDown(KeyCode.F) &&
            enemykill.GetComponent<EnemyKill>().a_Kajiki >= 1)
        {
            Kajiki();
            Debug.Log("カジキ使用");
        }

        if (isunagi == true && Input.GetKeyDown(KeyCode.F) &&
            enemykill.GetComponent<EnemyKill>().a_Unagi >= 1)
        {
            Unagi();
            Debug.Log("ウナギ使用");
        }

        if (iskurage == true && Input.GetKeyDown(KeyCode.F) &&
            enemykill.GetComponent<EnemyKill>().a_Kurage >= 1)
        {
            Kurage();
        }

        if (kuragesieldHP == 0)
        {
            kuragesield.SetActive(false);
        }
    }


    public void Kajiki()
    {
        player.GetComponent<Kajiki>().FishShot();
        enemykill.GetComponent<EnemyKill>().a_Kajiki -= 1;
    }
    public void KajikiClick()
    {
        iskajiki = true;
        isunagi = false;
        iskurage = false;
        cursorlocksystem.GetComponent<CursorLockSystem>().cursorlock();
        Canvas_SkillSelect.SetActive(false);
    }

    public void Unagi()
    {
        player.GetComponent<SkillElectronic_new>().skill();
        enemykill.GetComponent<EnemyKill>().a_Unagi -= 1;
    }

    public void UnagiClick()
    {
        isunagi = true;
        iskajiki = false;
        iskurage = false;
        cursorlocksystem.GetComponent<CursorLockSystem>().cursorlock();
        Canvas_SkillSelect.SetActive(false);
    }

    public void Kurage()
    {
        kuragesield.SetActive(true);
        kuragesieldHP = 1;
        player.GetComponent<PlayerHP>().kaihuku();
        enemykill.GetComponent<EnemyKill>().a_Kurage -= 1;
        Debug.Log("クラゲ使用");

        Kurage_Sound_s_2 = true;
    }

    public void KurageClick()
    {
        iskurage = true;
        iskajiki = false;
        isunagi = false;
        cursorlocksystem.GetComponent<CursorLockSystem>().cursorlock();
        Canvas_SkillSelect.SetActive(false);
    }

    public void damage()
    {
        kuragesieldHP -= 1;

        Kurage_Sound_e_2 = true;
    }
}
