using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;


public class PCExpander : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    public static GameObject bossObj;

    // Start is called before the first frame update
    void Start(){
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update(){}

    public void SetVolume_as(float vol)
    {
        GameObject SoundObject = GameObject.Find("AudioManager");
        if (SoundObject != null)
        {
            playerController.SetVolume(vol);
        }
    }
}
