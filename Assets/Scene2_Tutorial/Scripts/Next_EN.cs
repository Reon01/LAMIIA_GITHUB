using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Next_EN : MonoBehaviour
{
    public GameObject next;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            next.GetComponent<Next>().Yes();
        }
        else if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            next.GetComponent<Next>().No();
        }
    }
}
