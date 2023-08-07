using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControllerInput : MonoBehaviour
{
    InputAction _input;


    //回避
    public Rigidbody rb;
    public float avoidanceForce;

    //３次元の移動
    Vector3 moveDirection;
    [SerializeField] float speed = 5.0f;


    //上下移動
    private Vector3 playerVelocity;
    public float jumpHeight = 4f;
    public float downHeight = -4f;


    public Animator anim;



    void Start()
    {
        //カーソル非表示
        Cursor.visible = false;
        //カーソルを画面中央にロックする
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



        //上下移動
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


    //------------------------------------------ 関数 ------------------------------------------------------------//

    /// <summary>
    /// 移動方向の設定
    /// </summary>
    /// <param name="direction"></param>
    public void MoveSet(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, 0, direction.y).normalized * speed * Time.deltaTime;
    }


    /// <summary>
    /// 回避
    /// </summary>
    void Avoidance()
    {
        float horizontalInout = Input.GetAxisRaw("Horizontal");
        float varticalInout = Input.GetAxisRaw("Vertical");


        Vector3 dir = transform.forward * varticalInout + transform.right * horizontalInout;

        Debug.Log(dir);


        //前方回避
        if (varticalInout > 0 && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("前方回避！");
            rb.AddForce(dir.normalized * avoidanceForce, ForceMode.Impulse);
        }
        //右回避
        else if (horizontalInout > 0 && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("右回避！");
            rb.AddForce(transform.forward * avoidanceForce, ForceMode.Impulse);
        }
        //左回避
        else if (horizontalInout < 0 && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("左回避！");
            rb.AddForce(transform.forward * avoidanceForce, ForceMode.Impulse);
        }
        //後方回避
        else if (varticalInout < 0 && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("後方回避！");
            rb.AddForce(transform.forward * avoidanceForce, ForceMode.Impulse);
        }

    }
}  


