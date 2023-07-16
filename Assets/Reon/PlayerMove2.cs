using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    //３次元の移動
    public float speed = 8.0f;
    private CharacterController characterController;

    //上下移動
    private Vector3 playerVelocity;
    public float jumpHeight = 4f;
    public float downHeight = -4f;

    public Animator anim;


    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //カーソル非表示
        Cursor.visible = false;
        //カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
            anim.SetFloat("Move", 1f);
        }

       else if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
            anim.SetFloat("Move", 1f);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
            anim.SetFloat("Move", 1f);
        }

       else if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
            anim.SetFloat("Move", 1f);
        }

        else
        {
            anim.SetFloat("Move", 0f);
        }
        
        moveDirection.Normalize();


        characterController.Move(moveDirection * speed * Time.deltaTime);


        //上下移動
        if (Input.GetKey(KeyCode.Space))
        {

            playerVelocity.y = jumpHeight;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerVelocity.y = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {

            playerVelocity.y = downHeight;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerVelocity.y = 0;
        }
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
