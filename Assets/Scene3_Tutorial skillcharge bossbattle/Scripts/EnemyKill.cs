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
    public int a_Kajiki; //�����v�Z����

    //�E�i�M
    public Text amount_Unagi;�@//�c��̐���\�L����e�L�X�g
    public int a_Unagi; //�����v�Z����

    //�N���Q
    public Text amount_Kurage;�@//�c��̐���\�L����e�L�X�g
    public int a_Kurage; //�����v�Z����


    //�G�����񂾂�
    private GameObject enemy1prefab;


    //�T�E���h�p
    public static bool e_Defeat_Sound = false;

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
        amount_Kajiki.text = "" + a_Kajiki;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
        amount_Unagi.text = "" + a_Unagi;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
        amount_Kurage.text = "" + a_Kurage;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
    }

    public void getskill()
    {
        //�J�W�L
        value = Random.Range(2, 4);
        a_Kajiki += value; //�X�L���̐��{value

        //�E�i�M
        value = Random.Range(3, 5);
        a_Unagi += value; //�X�L���̐��{value

        //�N���Q
        value = Random.Range(1, 2);
        a_Kurage += value; //�X�L���̐��{value


        //�T�E���h�p
        e_Defeat_Sound = true;
    }
}
