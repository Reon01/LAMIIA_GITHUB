using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] private float lookSensitivity = 5f;
    [SerializeField] GameObject fpsCamera;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraUpAndDownRotation = 0f; //視点上下用の変数
    private float currentCameraUpAndDownRotation = 0f; //視点上下用の変数
    private Rigidbody rb;

    //自分
    public GameObject Mori;
    public PlayableDirector playabledirector;

    //石川君
    private CharacterController charaCon;
    private Vector3 playerVelocity;

    public float playerSpeed = 5.0f;
    public float jumpHeight = 4f;
    public float downHeight = -4f;

    public float rotSpeed = 700f;

    // Start is called before the first frame update
    void Start()
    {
        //カーソル非表示
        Cursor.visible = false;
        //カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();



        //石川君
        charaCon = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //水平移動
        float _xMovement = Input.GetAxis("Horizontal");
        float _zMovement = Input.GetAxis("Vertical");

        Vector3 _movementHorizontal = transform.right * _xMovement;
        Vector3 _movementVertical = transform.forward * _zMovement;

        Vector3 _movementVelocity = (_movementHorizontal + _movementVertical).normalized * speed;
        velocity = _movementVelocity;

        //左右視点
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _rotationVector = new Vector3(0, _yRotation, 0) * lookSensitivity;
        rotation = _rotationVector;

        //上下視点
        float _cameraUpDownRotation = Input.GetAxis("Mouse Y") * lookSensitivity;
        cameraUpAndDownRotation = _cameraUpDownRotation;



        //石川君
        float inputHorizontal;
        float inputVertical;

        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");


        Quaternion horizontalRot = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);


        Vector3 dir = horizontalRot * new Vector3(inputHorizontal, 0, inputVertical).normalized;
        charaCon.Move(dir * Time.deltaTime * playerSpeed);

        if (dir != Vector3.zero)
        {

            Quaternion qua = Quaternion.LookRotation(dir);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, qua, rotSpeed * Time.deltaTime);


        }

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
        charaCon.Move(playerVelocity * Time.deltaTime);

        //攻撃
        if (Input.GetMouseButtonDown(0))
        {
            playabledirector.Play();
            //Mori.transform.position += new Vector3(0f, 0f, 1.5f);
        }
        /*
        if (Input.GetMouseButtonUp(0))
        {
            Mori.transform.position += new Vector3(0f, 0f, -1.5f);
        }
        */
    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (fpsCamera != null)
        {
            currentCameraUpAndDownRotation -= cameraUpAndDownRotation; //カーソルの方を向く回転値にする
            currentCameraUpAndDownRotation = Mathf.Clamp(currentCameraUpAndDownRotation, -80, 80); //値を制限
            fpsCamera.transform.localEulerAngles = new Vector3(currentCameraUpAndDownRotation, 0, 0); //X軸にのみカメラを回転させる
        }
    }
}
