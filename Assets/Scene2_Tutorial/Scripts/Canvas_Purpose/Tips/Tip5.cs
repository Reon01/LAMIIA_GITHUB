using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip5 : MonoBehaviour
{
    private GameObject player;
    public GameObject nextcanvas;
    public GameObject panel5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�������E�i�M��10�C��ɓ��ꂽ��
        if (player.GetComponent<GetSkill>().a_Unagi >= 10)
        {
            //�T�E���h�p
            SFXplayer.radio_Sound = 1;

            nextcanvas.SetActive(true); //���̃Z���t��\��
            panel5.SetActive(false); //����̃q���g���\��
            gameObject.SetActive(false); //���̃X�N���v�g�����Ă�I�u�W�F�N�g���\��
        }
    }
}
