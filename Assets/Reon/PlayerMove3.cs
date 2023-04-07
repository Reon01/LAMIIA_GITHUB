using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
void Update()
    {
        // �J�����̌�������Y���̉�]���v�Z����
        Quaternion horizontalRot = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);

        // �J�����̌�������X����Z���̉�]���v�Z����
        Quaternion verticalRot = Quaternion.Euler(Camera.main.transform.eulerAngles.x, 0f, Camera.main.transform.eulerAngles.z);

        // �v���C���[�̉�]���X�V����
        transform.rotation = horizontalRot * verticalRot;
    }
}
