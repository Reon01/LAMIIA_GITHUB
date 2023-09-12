using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseZako : MonoBehaviour
{
    
    GameObject taget;

    Vector3 tagetPos;

    [SerializeField]
    float speed;


    private void Start()
    {
        taget = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        tagetPos.z = speed;

        transform.LookAt(taget.transform);

        transform.Translate(tagetPos * Time.deltaTime);

    }


}
