using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBossAttack : MonoBehaviour
{
    public float timer = 0;
    public GameObject ball;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�X�L�������܂ł̃N�[���^�C��
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            skill1();
            timer = 0;
        }
    }

    //�e���΂��X�L��
    public void skill1()
    {
        Vector3 pos = gameObject.transform.position;
        Instantiate(ball, pos, Quaternion.identity);
    }

    //�v���C���[�ɐڐG������_���[�W��^����
    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerHP>().damage();
        }
    }
    */
}
