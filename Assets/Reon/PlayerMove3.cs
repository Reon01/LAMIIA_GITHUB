using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
void Update()
    {
        // カメラの向きからY軸の回転を計算する
        Quaternion horizontalRot = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);

        // カメラの向きからX軸とZ軸の回転を計算する
        Quaternion verticalRot = Quaternion.Euler(Camera.main.transform.eulerAngles.x, 0f, Camera.main.transform.eulerAngles.z);

        // プレイヤーの回転を更新する
        transform.rotation = horizontalRot * verticalRot;
    }
}
