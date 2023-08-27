using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider HPBar;
    public int HP = 100;

    //HP�����\��
    public Text Text_HP;
    public int HP_num = 100;

    //���񂾂Ƃ��ɕ\������
    public GameObject canvas_restart;
    private GameObject cursorlocksystem;

    public GameObject hitdamege;
    public float redcooltime = 0.5f;

    //�񕜕\�L
    public GameObject canvas_heal;

    //�͂�܃T�E���h�p�ϐ�
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

    //�v���C���[���_���[�W���󂯂����̏���
    public void damage()
    {
        damaged_Sound_P = true;
        HP -= 5; //TSG�����ɂP�O�_������T�_���ɕύX
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void redeffect()
    {
        hitdamege.SetActive(true);
        Invoke("redeffectoff", redcooltime);
        Debug.Log("�ԃG�t�F�N�g");
    }

    public void redeffectoff()
    {
        hitdamege.SetActive(false);
    }

    public void fivedamage()
    {
        damaged_Sound_P = true;
        HP -= 2; //TSG�����ɂT�_������Q�_���ɕύX
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void speirdamage()
    {
        damaged_Sound_P = true;
        HP -= 2; //TSG�����ɂT�_������Q�_���ɕύX
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void kaihuku()
    {
        if (HP <= 99) //HP���X�X�ȉ��̎��̂݉񕜂ł���iHP����͂P�O�T�j
        {
            HP += 10;
            HPBar.value = HP;
            HP_num = HP;
            Text_HP.text = "HP:" + HP_num;
            Debug.Log("�N���Q��");
            canvas_heal.SetActive(true); //�񕜕\�L
            Invoke("healend", 1f); //�Q�b��ɉ񕜕\�L���I�t
        }
    }

    public void healend()�@
    {
        canvas_heal.SetActive(false); //�񕜕\�L���I�t
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
        Debug.Log("���񂾂�");
    }
}
