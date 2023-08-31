using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHitDamage : MonoBehaviour
{
    public float bosshitcount = 3;
    public float enemyhitcount = 1;
    public GameObject canvas_bosshit;
    public Slider slider_bosshit;
    public GameObject canvas_enemyhit;
    public Slider slider_enemyhit;
    private GameObject player;
    public GameObject[] amount_boss;
    private GameObject[] amount_mediumboss;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("MediumBoss"))
        {
            canvas_bosshit.SetActive(true); //�_���[�W�x���\��
            bosshitcount -= Time.deltaTime;
            slider_bosshit.value = bosshitcount;
            if (bosshitcount <= 0)
            {
                player.GetComponent<PlayerHP>().fivedamage(); //�T�_���H�炤
                bosshitcount = 3; //�J�E���g3�ɖ߂�
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            canvas_enemyhit.SetActive(true); //�_���[�W�x���\��
            enemyhitcount -= Time.deltaTime;
            slider_enemyhit.value = enemyhitcount;
            if (enemyhitcount <= 0)
            {
                player.GetComponent<PlayerHP>().fivedamage(); //�T�_���H�炤
                enemyhitcount = 1; //�J�E���g1�ɖ߂�
            }
        }
    }

    //�{�X�A�G���G�Ƃ̏d�Ȃ肪�I�������
    public void OnTriggerExit(Collider other)
    {
        //���{�X�A���{�X�̏���
        if (other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("MediumBoss"))
        {
            bosshitcount = 3; //�J�E���g��3�ɖ߂�
            canvas_bosshit.SetActive(false); //�_���[�W�x����\��
        }

        //���G���G�̏���
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyhitcount = 1; //�J�E���g��1�ɖ߂�
            canvas_enemyhit.SetActive(false); //�_���[�W�x����\��
        }
    }

    //���G���G�����񂾂Ƃ��Ɏ��s
    public void EnemyDead()
    {
        enemyhitcount = 1; //�J�E���g��1�ɖ߂�
        canvas_enemyhit.SetActive(false); //�_���[�W�x����\��
    }
}
