using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S4_BossHP : MonoBehaviour
{
    public Slider slider_bosshp;
    public int hp = 3000;
    public GameObject gameclearsystem;
    public GameObject bosssystems;

    //���_���[�W�\�L�p
    public GameObject damage10;
    public GameObject damage20;
    public GameObject damage50;
    public float damagecooltime;
    public GameObject damagetextposition;

    private GameObject player;

    //�T�E���h�p
    public static int bossHP;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        //�T�E���h�p
        bossHP = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            gameclearsystem.SetActive(true);
            bosssystems.SetActive(false);
            Time.timeScale = 0;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (player.GetComponent<SkillElectronic_new>().IsLightning == false)
            {
                hp = hp - 10;
                slider_bosshp.value = hp;
                damagedisplay10(); //�P�O�_���[�W�̃e�L�X�g��\��

                //�T�E���h�p
                bossHP = hp;
            }
            if (player.GetComponent<SkillElectronic_new>().IsLightning == true)
            {
                hp = hp - 20;
                slider_bosshp.value = hp;

                SkillElectronic.EE_Sound = 2;
                damagedisplay20();�@//�Q�O�_���[�W�̃e�L�X�g��\��

                //�T�E���h�p
                bossHP = hp;
            }
        }

        //���J�W�L�̏ꍇ50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            hp -= 50;
            slider_bosshp.value = hp;
            damagedisplay50(); //�T�O�_���[�W�̃e�L�X�g��\��

            //�T�E���h�p
            bossHP = hp;
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
