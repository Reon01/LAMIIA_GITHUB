using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S4_BossBattleTimer : MonoBehaviour
{
    public Slider slider_bosstimer;
    public float timer;
    private bool istimer;
    public GameObject boss;
    public GameObject canvas_boss;
    private GameObject enemyspawn;
    public GameObject canvas_skillchargetimer;
    public Text text_timer; //�e�L�X�g�Ŏ��ԕ\�L
    public GameObject canvas_bosshit;

    // Start is called before the first frame update
    void Start()
    {
        enemyspawn = GameObject.Find("EnemySpawn");
        timer = slider_bosstimer.value;
        istimer = true;
        timer = 30;�@//�ŏ���30�b���w�肷��
    }

    // Update is called once per frame
    void Update()
    {
        slider_bosstimer.value = timer; //�X���C�_�[�Ǝ��Ԃ����킹��
        text_timer.text = "Time Limit�F" + timer.ToString("f0"); //�e�L�X�g�Ŏc�莞�ԕ\�L
        if (istimer == true)
        {
            timer -= Time.deltaTime; //�P�b�����炷
            if (timer <= 0)�@//�����^�C�}�[���O�ɂȂ����ꍇ
            {
                canvas_bosshit.SetActive(false); //�ڐG���̃Q�[�W������
                enemyspawn.GetComponent<S4_EnemySpawn>().enemyspawn2();
                canvas_skillchargetimer.SetActive(true);
                canvas_skillchargetimer.GetComponent<S4_SkillChargeTimer>().timerstart();
                boss.SetActive(false);
                canvas_boss.SetActive(false);
                timer = 30;
                istimer = false;

                //�T�E���h�p
                PCExpander.bossObjChk = false;
            }
        }
    }

    public void timerstart()
    {
        istimer = true;
    }
}
