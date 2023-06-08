using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    public void OnClickFullHD()
    {
        Screen.SetResolution(1920, 1280, FullScreenMode.FullScreenWindow, 60);
    }

    public void OnClickHD()
    {
        //�{��HD�@
        Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow, 60);
        //��������掿
        //Screen.SetResolution(128, 72, FullScreenMode.FullScreenWindow, 60);
    }
}
