using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S4_SkillChargeTimer:MonoBehaviour
{
    public GameObject canvas_skillcharge;
    public Slider skillchargetimer;
    public float timer;
    private bool istimer;
    private GameObject enemydestroysystem;
    private GameObject bossspawnsystem;
    public GameObject bossbattletimer;
    public Text text_timer; //�e�L�X�g�̎��ԕ\�L
    public GameObject canvas_enemyhit; //�G���G�Ƃ̐ڐG��UI

    // Start is called before the first frame update
    void Start()
    {
        istimer = true;
        timer = skillchargetimer.value;
        enemydestroysystem = GameObject.Find("EnemyDestroySystem");
        bossspawnsystem = GameObject.Find("BossSpawnSystem");
    }

    // Update is called once per frame
    void Update()
    {
        skillchargetimer.value = timer; //�X���C�_�[�Ǝ��Ԃ����킹��
        text_timer.text = "Time Limit�F" + timer.ToString("f0"); //�e�L�X�g�Ŏc�莞�ԕ\�L
        if (istimer == true)
        {
            timer -= Time.deltaTime; //�P�b�����炷
            if (timer <= 0)�@//�����^�C�}�[���O�ɂȂ����ꍇ
            {
                canvas_skillcharge.SetActive(false); //���ԕ\���̃X���C�_�[���\���ɂ���
                enemydestroysystem.GetComponent<S4_EnemyDestroySystem>().enabled = true; //���̃X�N���v�g���I���ɂ���
                timer = 30;�@//�^�C�}�[��30�ɂ��ČJ��Ԃ����s����Ȃ��悤�ɂ���
                istimer = false;�@//istimer���I�t�ɂ��ČJ��Ԃ��\�h
                bossspawnsystem.GetComponent<S4_BossSpawnSystem>().BossSpawn(); //�{�X����
                bossbattletimer.GetComponent<S4_BossBattleTimer>().timerstart();�@//�{�X�^�C�}�[���N��
                canvas_enemyhit.SetActive(false); //�_���[�W�x����\��
            }
        }
    }

    public void timerstart()
    {
        istimer = true;
    }
}
