using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBossAttack : MonoBehaviour
{
    public float timer = 0;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //スキル発動までのクールタイム
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            skill1();
            timer = 0;
        }
    }

    //弾を飛ばすスキル
    public void skill1()
    {
        Vector3 pos = gameObject.transform.position;
        Instantiate(ball, pos, Quaternion.identity);
    }
}
