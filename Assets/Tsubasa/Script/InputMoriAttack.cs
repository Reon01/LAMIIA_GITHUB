using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoriAttack : MonoBehaviour
{
    private Animator animator;
    private string AttackStr = "Attack";

    //はるまサウンド用変数
    public static bool Mori_Sound = false;

    BoxCollider boxCol;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();

        boxCol = GetComponent<BoxCollider>();
    }

   



    public void MoriAttack()
    {
        this.animator.SetBool(AttackStr, true);

        boxCol.enabled = true;

        //はるまサウンド用
        Mori_Sound = true;
    }

    public void EnableMori()
    {
        this.animator.SetBool(AttackStr, false);
    }

    public void RaleseMori()
    {
        boxCol.enabled = false;
    }

}
