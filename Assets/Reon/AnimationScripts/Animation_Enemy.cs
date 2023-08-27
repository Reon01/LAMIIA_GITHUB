using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Enemy : MonoBehaviour
{
    private Animator animator;
    private string walkStr = "IsWalk";

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool(walkStr, true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
