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
    public float bosshitcount;

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
            bosshitcount += Time.deltaTime;
            if (bosshitcount >= 2)
            {
                fivedamage(); //�T�_���H�炤
                bosshitcount = 0; //�J�E���g�O�ɖ߂�
                ishitboss = false; //�J�E���g�~�߂�
            }
        }
    }

    //�v���C���[���{�X�Əd�Ȃ������̏���
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            ishitboss = true;
        }
    }
    //�{�X�Ƃ̏d�Ȃ肪�I�������
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Boss"))
        {
            ishitboss = false; //�J�E���g���~�߂�
            bosshitcount = 0; //�J�E���g��0�ɖ߂�
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
