using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3_Kajiki : MonoBehaviour
{
    //れおん改訂版
    public bool isSkill; //スキルが選択されてるか制御
    public bool spendskill; //スキルを消費

    [SerializeField] GameObject kajiki;

    private float fishspeed = 1000;

    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    private GameObject enemykillsystem;

    //ReloadTime
    //[SerializeField] 
    bool reloading;


    // Start is called before the first frame update
    void Start()
    {
        isSkill = false;
        enemykillsystem = GameObject.Find("EnemyKillSystem");

        //Reload
        reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetMouseButtonDown(0) && isSkill == true && enemykillsystem.GetComponent<EnemyKill>().a_Kajiki >= 1 && Time.timeScale == 1 && !reloading)
            {
                FishShot();
                enemykillsystem.GetComponent<EnemyKill>().a_Kajiki -= 1; //スキルを１消費
                spendskill = true;
                Debug.Log("カジキ発射");
                //はるまサウンド変数true
                SFXplayer.Sf_Sound = 1;

                //Reload
                StartCoroutine(Reload());
            }
        
 
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

    private IEnumerator Reload()
    {
        Debug.Log("Reloading");
        reloading = true;

        yield return new WaitForSeconds(2); //ReloadTime

        Debug.Log("Reload");
        reloading = false;
    }
}
