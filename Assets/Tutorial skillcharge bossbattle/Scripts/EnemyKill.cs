using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKill : MonoBehaviour
{
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


    //�G�����񂾂�
    private GameObject enemy1prefab;

    // Start is called before the first frame update
    void Start()
    {
        a_Kajiki = 0;
        a_Kurage = 0;
        a_Unagi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        enemy1prefab = GameObject.FindGameObjectWithTag("Enemy1");
        if (enemy1prefab.GetComponent<EnemyHP>().HP <= 0)
        {
            getskill();
            Debug.Log("Dead");
        }
        */
    }

    public void getskill()
    {
        Debug.Log("Hi");

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
