using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip8 : MonoBehaviour
{
    private GameObject player;
    public GameObject nextcanvas;
    public GameObject panel8;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�������N���Q��3�C�g�p������
        if (player.GetComponent<GetSkill>().a_Kurage <= 9)
        {
            nextcanvas.SetActive(true); //���̃Z���t��\��
            panel8.SetActive(false); //����̃q���g���\��
            gameObject.SetActive(false); //���̃X�N���v�g�����Ă�I�u�W�F�N�g���\��
        }
    }
}
