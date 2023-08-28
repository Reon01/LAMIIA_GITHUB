using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    [SerializeField]
    GameObject CameraTransform;

    [SerializeField]
    GameObject MarinTransform;

    float marinPosX;
    float marinPosY;
    float marinPosZ;
    float cameraPosX;
    float cameraPosY;
    float cameraPosZ;


    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        marinPosX = MarinTransform.transform.position.x;
        marinPosY = MarinTransform.transform.position.y;
        marinPosZ = MarinTransform.transform.position.z;
        cameraPosX = CameraTransform.transform.position.x;
        cameraPosY = CameraTransform.transform.position.y;
        cameraPosZ = CameraTransform.transform.position.z;

        transform.position = new Vector3(cameraPosX, cameraPosY, cameraPosZ);


        transform.rotation = MarinTransform.transform.rotation;
    }
}
