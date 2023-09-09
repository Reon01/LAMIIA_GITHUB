using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4_EnemySpawn : MonoBehaviour
{
    private int enemyamount;
    public GameObject enemy1;
    public GameObject rareenemy;
    public int enemyamountsave;

    private int enemygachanumber; //�K�`���p

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
        enemyamount = Random.Range(10, 21);
        enemyamountsave = enemyamount;
        enemyamountsave += 1;
    }

    // Update is called once per frame
    void Update()
    {
        //�����G�̐����O�ȏゾ������A�K�`���X�^�[�g
        if (enemyamount >= 0)
        {
            //enemyspawn();
            enemygacha();
        }
    }

    //�����ŃK�`���i�m���j�����
    public void enemygacha()
    {
        enemygachanumber = Random.Range(0, 100);
        //70%�̊m��
        if (enemygachanumber >= 31)
        {
            normalenemyspawn();
        }
        //30%�̊m��
        if (enemygachanumber <= 30)
        {
            rareenemyspawn();
        }
    }

    //���ʂ̓G������
    public void normalenemyspawn()
    {
        // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(enemy1, new Vector3(x, y, z), Quaternion.identity);
        enemyamount -= 1;
    }

    //���A�ȓG������
    public void rareenemyspawn()
    {
        // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(rareenemy, new Vector3(x, y, z), Quaternion.identity);
        enemyamount -= 1;
    }

    public void enemyspawn2()
    {
        enemyamount = Random.Range(10, 21);�@//�G�̐�

        /*
        // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(enemy1, new Vector3(x, y, z), Quaternion.identity);
        enemyamount -= 1;
        Debug.Log("�G���I����");
        */
    }
}
