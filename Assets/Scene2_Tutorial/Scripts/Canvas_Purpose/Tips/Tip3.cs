using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip3 : MonoBehaviour
{
    GameObject player;
    public GameObject nextcanvas;
    public GameObject panel3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�������J�W�L��10�C��ɓ��ꂽ��
        if (player.GetComponent<GetSkill>().a_Kajiki >= 10)
        {
            //�T�E���h�p
            SFXplayer.radio_Sound = 1;

            nextcanvas.SetActive(true); //���̃Z���t��\��
            panel3.SetActive(false); //����̃q���g���\��
            gameObject.SetActive(false); //���̃X�N���v�g�����Ă�I�u�W�F�N�g���\��
        }
    }
}
