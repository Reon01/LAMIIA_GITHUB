using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amount_Skill : MonoBehaviour
{
    public Text amount_Kajiki;�@//�c��̐���\�L����e�L�X�g
    public Text amount_Kurage;�@//�c��̐���\�L����e�L�X�g
    public Text amount_Unagi;�@//�c��̐���\�L����e�L�X�g

    public int a_Kajiki; //�����v�Z����
    public int a_Kurage; //�����v�Z����
    public int a_Unagi; //�����v�Z����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        amount_Kajiki.text = "" + a_Kajiki;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
        amount_Unagi.text = "" + a_Unagi;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
        amount_Kurage.text = "" + a_Kurage;�@//�X�L���̐���\�L����e�L�X�g�̒��g��ύX
    }
}