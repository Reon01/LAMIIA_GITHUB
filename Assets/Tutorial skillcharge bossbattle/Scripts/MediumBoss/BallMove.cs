using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private GameObject player;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerHP>().damage();
        }
    }
}