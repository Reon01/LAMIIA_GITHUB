using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBossMove : MonoBehaviour
{
    private float chargeTime = 5.0f;
    private float timeCount;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        timeCount += Time.deltaTime;

        if (timeCount > chargeTime)
        {
            // 進路をランダムに変更する
            Vector3 course = new Vector3(0, Random.Range(0, 180), 0);
            transform.localRotation = Quaternion.Euler(course);

            // タイムカウントを０に戻す
            timeCount = 0;
        }
    }
}
