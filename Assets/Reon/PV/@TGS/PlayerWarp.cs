using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarp : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            player.GetComponent<CharacterController>().enabled = false; //�v���C���[�𓮂������߂ɃL�����R��������
            player.transform.position = new Vector3(0.3f, 1.5f, -16);
            player.GetComponent<CharacterController>().enabled = true; //�v���C���[�̃L�����R����߂�
        }
    }
}
