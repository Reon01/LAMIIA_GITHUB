
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuteFishHP : MonoBehaviour
{
    public float HP = 100;
    public Slider HPBar;
    public GameObject Enemy;
    private GameObject Player;
    public GameObject damage10;
    public GameObject damagetextposition;

    /*
    //�X�L���擾
    private int value;

    
    //�J�W�L
    public Text amount_Kajiki;�@//�c��̐���\�L����e�L�X�g
    private int a_Kajiki; //�����v�Z����

    //�E�i�M
    public Text amount_Unagi;�@//�c��̐���\�L����e�L�X�g
    private int a_Unagi; //�����v�Z����

    //�N���Q
    public Text amount_Kurage;�@//�c��̐���\�L����e�L�X�g
    private int a_Kurage; //�����v�Z����
    */


    //EnemyKill
    private GameObject enemykill;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        enemykill = GameObject.Find("EnemyKillSystem");
    }

    // Update is called once per frame
    void Update()
    {
        //���ʏ���
        if (HP <= 0)
        {
            //getskill();
            enemykill.GetComponent<EnemyKillTute>().getskill();
            Destroy(Enemy);
        }

        //�U�����ꂽ�Ƃ�
        if (HP <= 90)
        {
            //this.GetComponent<FishMove>().getdamage = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (Player.GetComponent<InputSkillElectronic>().IsLightning == false)
            {
                HP = HP - 10;
                HPBar.value = HP;
                damagedisplay10(); //�P�O�_���[�W�̃e�L�X�g��\��
            }
            if (Player.GetComponent<InputSkillElectronic>().IsLightning == true)
            {
                HP = HP - 20;
                HPBar.value = HP;
            }
        }

        //���J�W�L�̏ꍇ50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            HP -= 50;
            HPBar.value = HP;
        }

        //���E�i�M�̏ꍇ20DMG
        if (other.gameObject.CompareTag("UnagiAttack"))
        {
            HP -= 20;
            HPBar.value = HP;
            //damagedisplay20(); //�Q�O�_���[�W�̃e�L�X�g��\��

            //�T�E���h�p
            SFXplayer.damaged_Sound_E = 1;
            SkillElectronic.EE_Sound = 2;
        }
    }

    public void damagedisplay10()
    {
        Instantiate(damage10, damagetextposition.transform.position, Quaternion.identity);
    }


}