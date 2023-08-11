using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private GameObject player;
    public int speed;
    private GameObject playertarget;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playertarget = GameObject.Find("PlayerTarget");
        transform.LookAt(playertarget.transform);
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
        else if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
