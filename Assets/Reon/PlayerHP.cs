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

    //�{�X�Əd�Ȃ������̏����p
    public bool ishitboss;
    public float bosshitcount = 2;
    public GameObject canvas_bosshit;
    public Slider slider_enemyhit;

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

        //�v���C���[���{�X�Əd�Ȃ������̏���
        if (ishitboss == true)
        {
            bosshitcount -= Time.deltaTime;
            slider_enemyhit.value = bosshitcount;
            if (bosshitcount <= 0)
            {
                fivedamage(); //�T�_���H�炤
                bosshitcount = 2; //�J�E���g2�ɖ߂�
            }
        }
    }

    //�v���C���[���{�X�Əd�Ȃ������̏���
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("MediumBoss"))
        {
            ishitboss = true; //�J�E���g�X�^�[�g
            canvas_bosshit.SetActive(true); //�_���[�W�x���\��
        }
    }
    //�{�X�Ƃ̏d�Ȃ肪�I�������
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("MediumBoss"))
        {
            ishitboss = false; //�J�E���g���~�߂�
            bosshitcount = 2; //�J�E���g��2�ɖ߂�
            canvas_bosshit.SetActive(false); //�_���[�W�x����\��
        }
    }

    //�v���C���[���_���[�W���󂯂����̏���
    public void damage()
    {
        damaged_Sound_P = true;
        HP -= 10;
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
        HP -= 5;
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void speirdamage()
    {
        damaged_Sound_P = true;
        HP -= 5;
        HPBar.value = HP;
        HP_num = HP;
        Text_HP.text = "HP:" + HP_num;
        redeffect();
    }

    public void kaihuku()
    {
        if (HP <= 90) //HP���X�O�ȉ��̎��̂݉񕜂ł���iHP����͂P�O�O�j
        {
            HP += 10;
            HPBar.value = HP;
            HP_num = HP;
            Text_HP.text = "HP:" + HP_num;
            Debug.Log("�N���Q��");
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
        Debug.Log("���񂾂�");
    }
}
