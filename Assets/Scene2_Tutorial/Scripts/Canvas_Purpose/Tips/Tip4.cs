using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip4 : MonoBehaviour
{
    private GameObject[] enemytag;
    public GameObject nextcanvas;
    public GameObject panel4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemytag = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemytag.Length == 0)
        {
            //�T�E���h�p
            SFXplayer.radio_Sound = 1;

            nextcanvas.SetActive(true); //���̃Z���t��\��
            panel4.SetActive(false); //����̃q���g���\��
            gameObject.SetActive(false); //���̃X�N���v�g�����Ă�I�u�W�F�N�g���\��
        }
    }
}
