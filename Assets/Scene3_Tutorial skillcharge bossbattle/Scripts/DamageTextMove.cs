using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, 0.5f * Time.deltaTime, 0.0f);
        Invoke("delete", 120f*Time.deltaTime);
    }

    public void delete()
    {
        Destroy(gameObject);
    }
}
