using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Boss : MonoBehaviour
{
    private Animator animator;
    private string walkStr = "IsWalk";

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.animator.SetBool(walkStr, true);
    }
}
