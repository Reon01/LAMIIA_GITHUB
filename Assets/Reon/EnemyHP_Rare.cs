using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP_Rare : MonoBehaviour
{
    public float HP = 150;
    public Slider HPBar;
    public GameObject rareenemy;
    private GameObject Player;
    public GameObject damage10;
    public GameObject damage20;
    public GameObject damage50;
    private float damagecooltime;
    public GameObject damagetextposition;


    //EnemyKill
    private GameObject enemykill;

    //�͂�܃T�E���h�p�ϐ�
    public static int damaged_Sound_E;

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
            enemykill.GetComponent<EnemyKill>().getskill();
            enemykill.GetComponent<EnemyKill>().getskill();
            Destroy(rareenemy);

            damaged_Sound_E = 2;
        }

        //�U�����ꂽ�Ƃ�
        if (HP <= 140)
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
                damaged_Sound_E = 1;
                damagedisplay10(); //�P�O�_���[�W�̃e�L�X�g��\��
            }
            if (Player.GetComponent<SkillElectronic_new>().IsLightning == true)
            {
                HP = HP - 20;
                HPBar.value = HP;
                damaged_Sound_E = 1;

                SkillElectronic.EE_Sound = 2;
                damagedisplay20();�@//�Q�O�_���[�W�̃e�L�X�g��\��
            }
        }

        //���J�W�L�̏ꍇ50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            HP -= 50;
            HPBar.value = HP;
            damagedisplay50();�@//�T�O�_���[�W�̃e�L�X�g��\��
        }
    }

    //�P�O�_���[�W�̃e�L�X�g��\��
    public void damagedisplay10()
    {
        Instantiate(damage10, damagetextposition.transform.position, Quaternion.identity);
    }
    //�Q�O�_���[�W�̃e�L�X�g��\��
    public void damagedisplay20()
    {
        Instantiate(damage20, damagetextposition.transform.position, Quaternion.identity);
    }
    //�T�O�_���[�W�̃e�L�X�g��\��
    public void damagedisplay50()
    {
        Instantiate(damage50, damagetextposition.transform.position, Quaternion.identity);
    }
}
