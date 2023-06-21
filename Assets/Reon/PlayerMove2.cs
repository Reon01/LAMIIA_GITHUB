using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    //�R�����̈ړ�
    public float speed = 5.0f;
    private CharacterController characterController;

    //�㉺�ړ�
    private Vector3 playerVelocity;
    public float jumpHeight = 4f;
    public float downHeight = -4f;


    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //�J�[�\����\��
        Cursor.visible = false;
        //�J�[�\������ʒ����Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }
        moveDirection.Normalize();


        characterController.Move(moveDirection * speed * Time.deltaTime);


        //�㉺�ړ�
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
