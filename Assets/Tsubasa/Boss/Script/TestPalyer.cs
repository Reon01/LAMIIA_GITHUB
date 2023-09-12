using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPalyer : MonoBehaviour
{
    float horizontal, vertical;

    [SerializeField] float speed;

    Vector3 moveDirection;

    private void Update()
    {
        

        horizontal = Input.GetAxisRaw("Horizontal");

        vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
