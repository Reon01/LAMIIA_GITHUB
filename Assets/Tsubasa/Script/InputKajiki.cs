using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKajiki : MonoBehaviour
{

    //�ꂨ�������
    public bool isSkill; //�X�L�����I������Ă邩����
    public bool spendskill; //�X�L��������

    [SerializeField] GameObject kajiki;

    private float fishspeed = 1000;

    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    private GameObject enemykillsystem;

    // Start is called before the first frame update
    void Start()
    {
        isSkill = false;
        enemykillsystem = GameObject.Find("EnemyKillSystem");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FishShot()
    {
        //�e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        GameObject ball = (GameObject)Instantiate(kajiki, bulletPosition, transform.rotation);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

        ballRigidbody.AddForce(transform.forward * fishspeed);
        Destroy(ball, 3.0f);
    }

    public void KazikiShot()
    {
        //��Scene2�p
        if (isSkill == true && enemykillsystem.GetComponent<EnemyKillTute>().a_Kajiki >= 1 && Time.timeScale == 1)
        {
            FishShot();
           enemykillsystem.GetComponent<EnemyKillTute>().a_Kajiki -= 1; //�X�L�����P����
            spendskill = true;
            Debug.Log("�J�W�L����");

            //�͂�܃T�E���h�ϐ�true
            SFXplayer.Sf_Sound = 1;
        }

        //��Scene3�p
        if (isSkill == true && enemykillsystem.GetComponent<EnemyKill>().a_Kajiki >= 1 && Time.timeScale == 1)
        {
            FishShot();
            enemykillsystem.GetComponent<EnemyKill>().a_Kajiki -= 1; //�X�L�����P����
            spendskill = true;
            Debug.Log("�J�W�L����");

            //�͂�܃T�E���h�ϐ�true
            SFXplayer.Sf_Sound = 1;
        }
    }
}
