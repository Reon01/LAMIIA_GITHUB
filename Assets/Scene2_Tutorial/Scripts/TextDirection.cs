using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Camera.main.transform.position; //���C���J�����̃|�W�V�����擾
        cameraPos.y = gameObject.transform.position.y;
        transform.rotation = Quaternion.LookRotation�@//�e�L�X�g���J�����̂ق��Ɍ����悤�ɂ���
            (transform.position - cameraPos);
    }
}
