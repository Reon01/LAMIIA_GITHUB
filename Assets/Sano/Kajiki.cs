using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kajiki : MonoBehaviour
{
    //�ꂨ�������
    public bool isSkill; //�X�L�����I������Ă邩����
    public bool spendskill; //�X�L��������

    //�͂�܃T�E���h�p
    public static bool Kajiki_Sound = false;

    [SerializeField] GameObject kajiki;

    private float fishspeed = 1000;

    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

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
            Debug.Log("�J�W�L����");
            //�͂�܃T�E���h�ϐ�true
            Kajiki_Sound = true;
        }
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
}
