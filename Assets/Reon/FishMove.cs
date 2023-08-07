using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    private float chargeTime = 5.0f;
    private float timeCount;

    public bool getdamage;
    private GameObject player;
    private GameObject playertarget;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertarget = GameObject.Find("PlayerTarget");
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        // 自動前進
        transform.position += transform.forward * Time.deltaTime;

        // 指定時間の経過（条件）
        if (timeCount > chargeTime)
        {
            // 進路をランダムに変更する
            Vector3 course = new Vector3(0, Random.Range(0, 180), 0);
            transform.localRotation = Quaternion.Euler(course);

            // タイムカウントを０に戻す
            timeCount = 0;
        }

        if (getdamage == true)
        {
            transform.LookAt(playertarget.transform);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerHP>().fivedamage();
            this.transform.Translate(0, 0, -2);
        }
    }
}
