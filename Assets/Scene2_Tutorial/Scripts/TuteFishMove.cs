using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuteFishMove : MonoBehaviour
{
    public GameObject circlingtarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(/*����̒��S*/circlingtarget.transform.position, -Vector3.up, -10 * Time.deltaTime);
    }
}
