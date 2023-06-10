using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    [SerializeField] private GameObject WhaleGO1;
    [SerializeField] private GameObject WhaleGO2;
    [SerializeField] private GameObject WhaleGO3;
    [SerializeField] private GameObject WhaleGO4;
    //[SerializeField] GameObject circlingtarget;
    //public float TurnSpan = 10f;
    //private float currentTime = 0f;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //フィールド上周回
        transform.LookAt(WhaleGO1.transform);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WhaleGO1"))
        {
            transform.LookAt(WhaleGO2.transform);
            Debug.Log("貫通１");
        }
        if (other.CompareTag("WhaleGO2"))
        {
            transform.LookAt(WhaleGO3.transform);

        }
        if (other.CompareTag("WhaleGO3"))
        {
            transform.LookAt(WhaleGO4.transform);

        }
        if (other.CompareTag("WhaleGO4"))
        {
            transform.LookAt(WhaleGO1.transform);

        }
    }
    // Update is called once per frame
    void Update()
    {


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
