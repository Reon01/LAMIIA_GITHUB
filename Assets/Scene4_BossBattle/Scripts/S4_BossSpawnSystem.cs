using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4_BossSpawnSystem : MonoBehaviour
{
    public GameObject canvas_boss;
    public GameObject boss;
    private GameObject bossbattletimer;

    // Start is called before the first frame update
    void Start()
    {
        bossbattletimer = GameObject.Find("BossBattleTimer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossSpawn()
    {
        canvas_boss.SetActive(true); //�^�C�}�[�A�̗͂�\��
        boss.SetActive(true);   //�{�X����
        bossbattletimer.GetComponent<S4_BossBattleTimer>().enabled = true;  //�^�C�}�[�̃X�N���v�g�N��
    }
}
