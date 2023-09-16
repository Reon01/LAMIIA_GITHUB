using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    //増やす①
    [SerializeField] private GameObject WhaleGO1;
    [SerializeField] private GameObject WhaleGO2;
    [SerializeField] private GameObject WhaleGO3;
    [SerializeField] private GameObject WhaleGO4;
    [SerializeField] private GameObject WhaleGO5;
    [SerializeField] private GameObject WhaleGO6;
    [SerializeField] private GameObject WhaleGO7;
    [SerializeField] private GameObject WhaleGO8;
    [SerializeField] private GameObject WhaleGO9;
    [SerializeField] private GameObject WhaleGO10;
    [SerializeField] private GameObject WhaleGO11;
    [SerializeField] private GameObject WhaleGO12;
    [SerializeField] private GameObject WhaleGO13;
    //[SerializeField] GameObject circlingtarget;
    //public float TurnSpan = 10f;
    //private float currentTime = 0f;
    public float speed;
    private int a;

    // Start is called before the first frame update
    void Start()
    {//デフォルトはWhaleGO1,a=13

        //フィールド上周回
        transform.LookAt(WhaleGO1.transform);
        //各地点お試し用(上のWhaleGOの数字の-1)
        a = 13;
    }

    public void OnTriggerEnter(Collider other)
    {

        //増やす②
        if (a ==13&&other.CompareTag("WhaleGO1"))
        {
            
            a = 1;
            
            Debug.Log("貫通１");
        }
        if (a==1&&other.CompareTag("WhaleGO2"))
        {
            a = 2;
            

        }
        if (a == 2 && other.CompareTag("WhaleGO3"))
        {
            a = 3;
            

        }
        if (a == 3 && other.CompareTag("WhaleGO4"))
        {
            a = 4;
            

        }
        if (a == 4 && other.CompareTag("WhaleGO5"))
        {
            a = 5;
           

        }
        if (a == 5 && other.CompareTag("WhaleGO6"))
        {
            a = 6;
           

        }
        if (a == 6 && other.CompareTag("WhaleGO7"))
        {
            a = 7;
            

        }
        if (a == 7 && other.CompareTag("WhaleGO8"))
        {
            a = 8;


        }
        if (a == 8 && other.CompareTag("WhaleGO9"))
        {
            a = 9;


        }
        if (a == 9 && other.CompareTag("WhaleGO10"))
        {
            a = 10;


        }
        if (a == 10 && other.CompareTag("WhaleGO11"))
        {
            a = 11;


        }
        if (a == 11 && other.CompareTag("WhaleGO12"))
        {
            a = 12;


        }
        if (a == 12 && other.CompareTag("WhaleGO13"))
        {
            a = 13;


        }
    }
    // Update is called once per frame
    void Update()
    {
        if(a==1)
        {
            transform.LookAt(WhaleGO2.transform);
        }
        if (a == 2)
        {
            transform.LookAt(WhaleGO3.transform);
        }
        if (a == 3)
        {
            transform.LookAt(WhaleGO4.transform);
        }
        if (a == 4)
        {
            transform.LookAt(WhaleGO5.transform);
        }
        if (a == 5)
        {
            transform.LookAt(WhaleGO6.transform);
            
        }
        if (a == 6)
        {
            transform.LookAt(WhaleGO7.transform);
            Debug.Log("戻ってる？");
        }
        if (a == 7)
        {
            transform.LookAt(WhaleGO8.transform);
            Debug.Log("進む");
        }
        if (a == 8)
        {
            transform.LookAt(WhaleGO9.transform);
        }
        if (a == 9)
        {
            transform.LookAt(WhaleGO10.transform);
        }
        if (a == 10)
        {
            transform.LookAt(WhaleGO11.transform);
        }
        if (a == 11)
        {
            transform.LookAt(WhaleGO12.transform);
        }
        if (a == 12)
        {
            transform.LookAt(WhaleGO13.transform);
        }
        if (a == 13)
        {
            transform.LookAt(WhaleGO1.transform);
        }

        transform.Translate(0, 0, 0 + speed * Time.deltaTime);

        //主人公に突進
        /*currentTime += Time.deltaTime;
        if ((currentTime > TurnSpan) && (Time.timeScale == 1))
        {
            transform.LookAt(player.transform);
            currentTime = 0f;
        }
        if (Time.timeScale == 1)
        {
            transform.Translate(0, 0, 1.3f);
        }
        */

        //ステージ周回
        //transform.RotateAround(/*クジラの周回の中心になるもの*/circlingtarget.transform.position, Vector3.up, 50 * Time.deltaTime);
    }


}
