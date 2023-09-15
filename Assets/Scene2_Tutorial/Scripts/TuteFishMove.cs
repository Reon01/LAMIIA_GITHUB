using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuteFishMove : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(/*周回の中心(動かないエネミーの位置を変えたときここも変える)*/new Vector3(-47f, 0f, 6f), Vector3.up, 10 * Time.deltaTime);
    }
}
