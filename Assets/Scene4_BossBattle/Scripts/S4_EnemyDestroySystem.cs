using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4_EnemyDestroySystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");   //'Enemy'�^�O��T��

        foreach (GameObject enemy in enemys)    //�J��Ԃ�
        {
            Destroy(enemy); //'Enemy'�^�O�������I�u�W�F�N�g��j�󂷂�
        }

        if (enemys.Length <= 0)
        {
            //'Enemy'�^�O�������I�u�W�F�N�g���Ȃ��Ȃ����炱�̃X�N���v�g���I�t�ɂ���
            this.GetComponent<S4_EnemyDestroySystem>().enabled = false;
        }

    }


}
