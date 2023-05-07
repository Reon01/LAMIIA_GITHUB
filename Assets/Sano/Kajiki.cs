using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kajiki : MonoBehaviour
{
    //れおん改訂版
    public bool isSkill; //スキルが選択されてるか制御
    public bool spendskill; //スキルを消費

    [SerializeField] GameObject kajiki;

    private float fishspeed = 1000;

    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    /*
    [SerializeField]
    [Tooltip("渦巻の発射場所")]
    private GameObject firingPoint2;


    [SerializeField]
    [Tooltip("渦巻")]
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
            GetComponent<GetSkill>().a_Kajiki -= 1; //スキルを１消費
            spendskill = true;
        }
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {

            {
                // 渦巻を発射する場所を取得
                Vector3 guruguruPosition = firingPoint2.transform.position;
                // 上で取得した場所に、"guruguru"のPrefabを出現させる
                GameObject newBall = Instantiate(guruguru, guruguruPosition, transform.rotation);
                // 出現させたボールの名前を"guruguru"に変更
                newBall.name = guruguru.name;
                // 出現させたボールを秒後に消す
                Destroy(newBall, 1.5f);
            }
        }
        */
    }
    private void FishShot()
    {
        //弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;
        GameObject ball = (GameObject)Instantiate(kajiki, bulletPosition, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

        ballRigidbody.AddForce(transform.forward * fishspeed);
        Destroy(ball, 3.0f);
    }
}
