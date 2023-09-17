using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    InputAction _input;


    //���
    public Rigidbody rb;
    public float avoidanceForce;

    Vector3 avoidanceDir;

    //�R�����̈ړ�
    Vector3 moveDirection;
    [SerializeField] float speed = 5.0f;


    //�㉺�ړ�
    private Vector3 playerVelocity;
    public float jumpHeight = 4f;
    public float downHeight = -4f;


    public Animator anim;



    void Start()
    {
        //�J�[�\����\��
        Cursor.visible = false;
        //�J�[�\������ʒ����Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

         if (!(moveDirection.magnitude == 0))
         {
             anim.SetFloat("Move", 1f);
         }
         else
         {
             anim.SetFloat("Move", 0f);
         }

        Debug.Log(moveDirection.magnitude);


        transform.Translate(moveDirection.x, moveDirection.y, moveDirection.z);

        if (moveDirection == Vector3.zero)
            return;

        Quaternion rotate = Quaternion.LookRotation(moveDirection, Vector3.up);

        //transform.rotation = rotate;



        //�㉺�ړ�
        if (Input.GetKey(KeyCode.Space))
        {

            playerVelocity.y = jumpHeight;



        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerVelocity.y = 0;

        }
        if (Input.GetKey(KeyCode.LeftControl))
        {

            playerVelocity.y = downHeight;

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerVelocity.y = 0;
        }


    }


    //------------------------------------------ �֐� ------------------------------------------------------------//

    /// <summary>
    /// �ړ������̐ݒ�
    /// </summary>
    /// <param name="direction"></param>
    public void MoveSet(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, 0, direction.y).normalized * speed * Time.deltaTime;
    }


    public void UpMove()
    {
        transform.Translate(0, jumpHeight * Time.deltaTime, 0);
    }


    public void DownMOve()
    {
        transform.Translate(0, downHeight * Time.deltaTime, 0);
    }


    /// <summary>
    /// ���
    /// </summary>
    public void Avoidance()
    {
        avoidanceDir = transform.right * moveDirection.x + transform.forward * moveDirection.z;



        rb.AddForce(avoidanceDir.normalized * avoidanceForce, ForceMode.Impulse);

    }
}
