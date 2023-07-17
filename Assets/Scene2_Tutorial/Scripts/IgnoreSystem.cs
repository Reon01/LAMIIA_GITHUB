using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IgnoreSystem : MonoBehaviour
{
    public bool iscount;
    public bool iscount2;
    public float count;
    public float count2;
    public GameObject text1;
    public GameObject text2;

    private GameObject cursourlocksystem;

    // Start is called before the first frame update
    void Start()
    {
        iscount = true; //���߂ɃJ�E���g���I���ɂ���
        cursourlocksystem = GameObject.Find("CursourLockSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (iscount == true) //�����J�E���g���n�܂�����
        {
            count += Time.deltaTime; 
            if (count >= 30) //�����R�O�b���o�߂�����
            {
                text1open();�@//�e�L�X�g��\��
                count = 0;�@//�J�E���g���O�ɖ߂�
                iscount = false;�@//�J�E���g���~�߂�
                iscount2 = true; //���̃J�E���g���n�߂�
            }
        }

        if (iscount2 == true)
        {
            count2 += Time.deltaTime;
            if (count2 >= 30) //�R�O�b�{�R�O�b�̌v�P�����o�߂����ꍇ
            {
                text2open();�@//�e�L�X�g�A�{�^����\��
            }
        }
    }

    public void text1open()
    {
        text1.SetActive(true);�@//�e�L�X�g��\��
    }

    public void text2open()
    {
        text2.SetActive(true);�@//�e�L�X�g��\��
        count2 = 0; //�J�E���g���O�ɖ߂�
        iscount2 = false;�@//�J�E���g���~�߂�
    }

    public void yes() //�͂����������ꍇ
    {
        SceneManager.LoadScene("Scene2_Tutorial(2)");�@//���̃V�[������蒼��
    }

    public void no()�@//���������������ꍇ
    {
        text2.SetActive(false);�@//�e�L�X�g���\���ɂ���
        Time.timeScale = 1;
        cursourlocksystem.GetComponent<CursorLockSystem>().cursorlock();
    }
}
