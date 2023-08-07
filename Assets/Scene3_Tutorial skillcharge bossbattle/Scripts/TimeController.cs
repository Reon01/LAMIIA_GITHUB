using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider slider_timer;
    public GameObject player;
    public GameObject warppoint;
    public GameObject mediumbosssystem;
    public GameObject mediumboss;

    private GameObject[] enemy;
    public int amount;
    public GameObject enemybattlesystem;
    //private GameObject skillcheat;
    public GameObject tip2;

    // Start is called before the first frame update
    void Start()
    {
        //skillcheat = GameObject.Find("SkillCheat");
    }

    // Update is called once per frame
    void Update()
    {
        amount = enemybattlesystem.GetComponent<EnemyBattleSystem>().enemyamountsave;
        if (slider_timer.value <= 0)
        {
            warp();
            /*
            enemy = GameObject.FindGameObjectsWithTag("Enemy");�@//�G�̐��𐔂���
            if (enemy.Length == amount)�@//�����G���P�̂��|���Ȃ�������
            {
                skillcheat.GetComponent<PV_SkillCheat>().cheat();�@//�X�L����z�z����
            }
            */
            gameObject.SetActive(false);�@//�^�C�}�[�̃X�N���v�g������
        }
    }

    public void warp()
    {
        tip2.SetActive(false); //����̃q���g������
        player.GetComponent<CharacterController>().enabled = false; //�v���C���[�𓮂������߂ɃL�����R��������
        Vector3 point = warppoint.transform.position; //warppoint�Ƀ|�W�V������ς���
        player.transform.position = point;
        mediumbosssystem.SetActive(true); //�{�X����
        player.GetComponent<CharacterController>().enabled = true; //�v���C���[�̃L�����R����߂�
    }
}
