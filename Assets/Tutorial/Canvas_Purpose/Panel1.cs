using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel1 : MonoBehaviour
{
    private float count;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 5)
        {
            canvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
