using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseZako : MonoBehaviour
{
    
    GameObject taget;

    Vector3 tagetPos;

    float timer;

    [SerializeField]
    float chaseTime;

    [SerializeField]
    float speed;


    private void Start()
    {
        taget = GameObject.FindGameObjectWithTag("Player");

        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer < chaseTime)
        {
            tagetPos.z = speed;

            transform.LookAt(taget.transform);

            transform.Translate(tagetPos * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
        }

    }


}
