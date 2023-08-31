using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marin_Idol_Animation : MonoBehaviour
{
    private Animator animator;
    private string idolStr = "IsIdol";

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool(idolStr, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
