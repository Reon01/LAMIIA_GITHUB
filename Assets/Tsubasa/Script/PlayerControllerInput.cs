using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControllerInput : MonoBehaviour
{
    InputAction _input;


    //���
    public Rigidbody rb;
    public float avoidanceForce;

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


    /// <summary>
    /// ���
    /// </summary>
    void Avoidance()
    {
        float horizontalInout = Input.GetAxisRaw("Horizontal");
        float varticalInout = Input.GetAxisRaw("Vertical");


        Vector3 dir = transform.forward * varticalInout + transform.right * horizontalInout;

        Debug.Log(dir);


        //�O�����
        if (varticalInout > 0 && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("�O������I");
            rb.AddForce(dir.normalized * avoidanceForce, ForceMode.Impulse);
        }
        //�E���
        else if (horizontalInout > 0 && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("�E����I");
            rb.AddForce(transform.forward * avoidanceForce, ForceMode.Impulse);
        }
        //�����
        else if (horizontalInout < 0 && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("������I");
            rb.AddForce(transform.forward * avoidanceForce, ForceMode.Impulse);
        }
        //������
        else if (varticalInout < 0 && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("�������I");
            rb.AddForce(transform.forward * avoidanceForce, ForceMode.Impulse);
        }

    }
}  


