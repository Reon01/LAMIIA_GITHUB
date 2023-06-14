using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpeir : MonoBehaviour
{
    [SerializeField, Tooltip("���B����")] float period;        //���U���̓��B����
    [Header("�ő�����x")]
    [SerializeField] float maxAcceleration = 100;�@�@�@�@�@�@  //�����x�̏��
    [Header("�����_���ɉ������")]
    [SerializeField] float randomPower;�@�@�@�@�@�@�@�@�@�@�@�@//�����_���ɉ������
    [SerializeField] float randomPeriod;�@�@�@�@�@�@�@�@�@�@�@ //�͂����������鎞��

    private GameObject target;
    private Vector3 position;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@

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

        //���xvelocity�̕��̂�period�b���diff�i�ނ��߂̉����x
        acceleration += (diff - velocity * period) * 2f / (period * period);

        //randomPeriod�b�̊ԃ����_���ȗ͂�����������
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
