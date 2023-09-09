using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mori : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            this.animator.SetBool(AttackStr, true);
        }
        else
        {
            this.animator.SetBool(AttackStr, false);
        }

        //Colliderを出したり消したりする（武器を振った時だけHPを削りたいから）
        if (Input.GetMouseButtonDown(0)&&Time.timeScale==1)
        {
            boxCol.enabled = true;

            //はるまサウンド用
            Mori_Sound = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            boxCol.enabled = false;
        }
    }
}
