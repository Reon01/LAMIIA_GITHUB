using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel1 : MonoBehaviour
{
    private float count;
    public float timer = 5;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= timer)
        {
            canvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
