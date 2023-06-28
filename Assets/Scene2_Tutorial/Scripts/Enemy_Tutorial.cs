using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tutorial : MonoBehaviour
{
    public GameObject enemy; 
    public bool isspawn;
    public GameObject[] tagObjects;

    // Start is called before the first frame update
    void Start()
    {
        //���G�P�̏���
        Instantiate(enemy, new Vector3(3f, 0f, 6f), Quaternion.identity);
        isspawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�������Enemy�^�O�����m
        tagObjects = GameObject.FindGameObjectsWithTag("Enemy");

        //������Enemy�^�O��0�������ꍇ
        if (tagObjects.Length == 0 && isspawn == true)
        {
            Invoke(nameof(enemyspawn),2f); //2f���enemyspawn()�����s
            isspawn = false;
        }
    }

    public void enemyspawn() //�G��1�̏���
    {
        Instantiate(enemy, new Vector3(3f, 0f, 6f), Quaternion.identity);
        isspawn = true;
    }
}
