using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleSystem : MonoBehaviour
{
    public int enemyamount;
    public GameObject enemy1;
    public int enemyamountsave;

    public float timer;

    //�����_���Ȉʒu����
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;

    // Start is called before the first frame update
    void Start()
    {
        enemyamount = Random.Range(5, 10);
        enemyamountsave = enemyamount;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyamount >= 0)
        {
            enemyspawn();
        }
    }

    public void enemyspawn()
    {
        // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(enemy1, new Vector3(x,y,z), Quaternion.identity);
        enemyamount -= 1;
    }
}
