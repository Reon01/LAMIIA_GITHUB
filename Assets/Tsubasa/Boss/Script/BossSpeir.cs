using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpeir : MonoBehaviour
{
    [SerializeField, Tooltip("到達時間")] float period;        //槍攻撃の到達時間
    [Header("最大加速度")]
    [SerializeField] float maxAcceleration = 100;　　　　　　  //加速度の上限
    [Header("ランダムに加える力")]
    [SerializeField] float randomPower;　　　　　　　　　　　　//ランダムに加える力
    [SerializeField] float randomPeriod;　　　　　　　　　　　 //力を加え続ける時間

    private GameObject target;
    private Vector3 position;　　　　　　　　　　　　　　　　　

    public Vector3 velocity;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        position = transform.position;

        if (target == null)
            return;

        var acceleration = Vector3.zero;
        var diff = target.transform.position - position;

        //速度velocityの物体がperiod秒後にdiff進むための加速度
        acceleration += (diff - velocity * period) * 2f / (period * period);

        //randomPeriod秒の間ランダムな力を加え続ける
        if (0 < randomPeriod)
        {
            var xr = Random.Range(-randomPower, randomPower);
            var yr = Random.Range(0, 0);
            var zr = Random.Range(-randomPower, randomPower);
            acceleration += new Vector3(xr, yr, zr);
        }

        if (acceleration.magnitude > maxAcceleration)
        {
            acceleration = acceleration.normalized * maxAcceleration;
        }

        period -= Time.deltaTime;
        randomPeriod -= Time.deltaTime;

        if (period < 0f)
            return;


        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerHP>().speirdamage();
        }

        else if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
