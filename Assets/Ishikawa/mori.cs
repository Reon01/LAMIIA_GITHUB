using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mori : MonoBehaviour
{
    private Animator animator;
    private string AttackStr = "Attack";

    BoxCollider boxCol;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();

        boxCol = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.animator.SetBool(AttackStr, true);
        }
        else
        {
            this.animator.SetBool(AttackStr, false);
        }

        //Collider‚ğo‚µ‚½‚èÁ‚µ‚½‚è‚·‚éi•Ší‚ğU‚Á‚½‚¾‚¯HP‚ğí‚è‚½‚¢‚©‚çj
        if (Input.GetMouseButtonDown(0))
        {
            boxCol.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            boxCol.enabled = false;
        }
    }
}
