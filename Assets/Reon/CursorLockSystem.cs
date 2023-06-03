using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cursorlock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("lock");
    }

    public void cursoropen()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Debug.Log("open");
    }
}
