using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip6 : MonoBehaviour
{
    GameObject[] tagObjects;
    public GameObject nextcanvas;
    public GameObject panel6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�������_�~�[��|��������s
        tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (tagObjects.Length == 0)
        {
            //�T�E���h�p
            SFXplayer.radio_Sound = 1;

            nextcanvas.SetActive(true); //���̃Z���t��\��
            panel6.SetActive(false); //����̃q���g���\��
            gameObject.SetActive(false); //���̃X�N���v�g��t���Ă�I�u�W�F�N�g���\��
        }
    }
}
