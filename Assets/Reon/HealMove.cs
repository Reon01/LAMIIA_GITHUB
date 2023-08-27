using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, 50f * Time.deltaTime, 0.0f);
        Invoke("delete", 2f);
    }

    public void delete()
    {
        Destroy(gameObject);
    }
}
