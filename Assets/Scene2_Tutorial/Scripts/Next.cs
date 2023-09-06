using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public GameObject canvas_next;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || 
            other.gameObject.CompareTag("Weapon"))
        {
            warning1();
            Time.timeScale = 0;
        }
    }

    //�v���C���[�ƐڐG������e�L�X�g��\��
    public void warning1()
    {
        canvas_next.SetActive(true);

        //�J�[�\���ĕ\��
        Cursor.visible = true;
        //�J�[�\�����b�N������
        Cursor.lockState = CursorLockMode.Confined;
    }

    //�͂��̃{�^�����������ꍇ
    public void Yes()
    {
        Time.timeScale = 1;
        canvas_next.SetActive(false);

        //�J�[�\���ĕ\��
        Cursor.visible = false;
        //�J�[�\�����b�N������
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Scene4_BossStage");
    }

    //�������̃{�^�����������ꍇ
    public void No()
    {
        Time.timeScale = 1;
        canvas_next.SetActive(false);

        //�J�[�\���ĕ\��
        Cursor.visible = false;
        //�J�[�\�����b�N������
        Cursor.lockState = CursorLockMode.Locked;
    }
}
