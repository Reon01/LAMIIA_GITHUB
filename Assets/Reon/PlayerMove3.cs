using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove3 : MonoBehaviour
{
    public CinemachineBrain brain;
    private ICinemachineCamera Cam;
    private CinemachineVirtualCamera vcam;
    public float kando;
    private GameObject vCamObj;

    void Start()
    {
        GameObject vCamObj = GameObject.Find("GameObject");
        vcam = vCamObj.GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        var pov = vcam.GetCinemachineComponent<CinemachinePOV>();
        pov.m_VerticalAxis.m_MaxSpeed = kando;
        pov.m_HorizontalAxis.m_MaxSpeed = kando;
        // �J�����̌�������Y���̉�]���v�Z����
        Quaternion horizontalRot = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);

        // �J�����̌�������X����Z���̉�]���v�Z����
        Quaternion verticalRot = Quaternion.Euler(Camera.main.transform.eulerAngles.x, 0f, Camera.main.transform.eulerAngles.z);

        // �v���C���[�̉�]���X�V����
        transform.rotation = horizontalRot * verticalRot;
    }
}
