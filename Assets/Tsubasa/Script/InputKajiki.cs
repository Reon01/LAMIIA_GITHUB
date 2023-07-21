using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKajiki : MonoBehaviour
{

    //れおん改訂版
    public bool isSkill; //スキルが選択されてるか制御
    public bool spendskill; //スキルを消費

    //はるまサウンド用
    public static bool Kajiki_Sound = false;

    [SerializeField] GameObject kajiki;

    private float fishspeed = 1000;

    [SerializeField]
    [Tooltip("弾の発射場所")]
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
        //弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;
        GameObject ball = (GameObject)Instantiate(kajiki, bulletPosition, transform.rotation);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

        ballRigidbody.AddForce(transform.forward * fishspeed);
        Destroy(ball, 3.0f);
    }

    public void KazikiShot()
    {
        //↓Scene2用
        if (isSkill == true && GetComponent<GetSkill>().a_Kajiki >= 1)
        {
            FishShot();
            GetComponent<GetSkill>().a_Kajiki -= 1; //スキルを１消費
            spendskill = true;
            Debug.Log("カジキ発射");
            //はるまサウンド変数true
            Kajiki_Sound = true;
        }

        //↓Scene3用
        if (isSkill == true && enemykillsystem.GetComponent<EnemyKill>().a_Kajiki >= 1)
        {
            FishShot();
            enemykillsystem.GetComponent<EnemyKill>().a_Kajiki -= 1; //スキルを１消費
            spendskill = true;
            Debug.Log("カジキ発射");
            //はるまサウンド変数true
            Kajiki_Sound = true;
        }
    }
}
