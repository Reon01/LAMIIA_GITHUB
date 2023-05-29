using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float HP = 100;
    public Slider HPBar;
    public GameObject Enemy;
    private GameObject Player;

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

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //���ʏ���
        if (HP <= 0)
        {
            getskill();
            Destroy(Enemy);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (Player.GetComponent<SkillElectronic>().IsLightning == false)
            {
                HP = HP - 10;
                HPBar.value = HP;
            }
            if (Player.GetComponent<SkillElectronic>().IsLightning == true)
            {
                HP = HP - 20;
                HPBar.value = HP;
            }
        }
    }

    public void getskill()
    {
        //�J�W�L
        value = Random.Range(5, 10);
        a_Kajiki += value; //�X�L���̐��{value
        amount_Kajiki.text = "" + a_Kajiki;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX

        //�E�i�M
        value = Random.Range(5, 10);
        a_Unagi += value; //�X�L���̐��{value
        amount_Unagi.text = "" + a_Unagi;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX

        //�N���Q
        value = Random.Range(5, 10);
        a_Kurage += value; //�X�L���̐��{value
        amount_Kurage.text = "" + a_Kurage;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
    }
}
