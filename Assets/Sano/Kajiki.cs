using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kajiki : MonoBehaviour
{
    //�ꂨ�������
    public bool isSkill; //�X�L�����I������Ă邩����
    public bool spendskill; //�X�L��������

    [SerializeField] GameObject kajiki;

    private float fishspeed = 1000;

    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    /*
    [SerializeField]
    [Tooltip("�Q���̔��ˏꏊ")]
    private GameObject firingPoint2;


    [SerializeField]
    [Tooltip("�Q��")]
    private GameObject guruguru;
    */

    // Start is called before the first frame update
    void Start()
    {
        isSkill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isSkill == true && GetComponent<GetSkill>().a_Kajiki >= 1)
        {
            FishShot();
            GetComponent<GetSkill>().a_Kajiki -= 1; //�X�L�����P����
            spendskill = true;
        }
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {

            {
                // �Q���𔭎˂���ꏊ���擾
                Vector3 guruguruPosition = firingPoint2.transform.position;
                // ��Ŏ擾�����ꏊ�ɁA"guruguru"��Prefab���o��������
                GameObject newBall = Instantiate(guruguru, guruguruPosition, transform.rotation);
                // �o���������{�[���̖��O��"guruguru"�ɕύX
                newBall.name = guruguru.name;
                // �o���������{�[����b��ɏ���
                Destroy(newBall, 1.5f);
            }
        }
        */
    }
    private void FishShot()
    {
        //�e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        GameObject ball = (GameObject)Instantiate(kajiki, bulletPosition, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

        ballRigidbody.AddForce(transform.forward * fishspeed);
        Destroy(ball, 3.0f);
    }
}
