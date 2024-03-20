using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoriAttack : MonoBehaviour
{
    private Animator animator;
    private string AttackStr = "Attack";
    private bool reloading = false;  // To control reloading

    //はるまサウンド用変数
    public static bool Mori_Sound = false;

    BoxCollider boxCol;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider>();
        reloading = false; // Initialize reloading to false
    }

    public void MoriAttack()
    {
        if (!reloading)
        {
            boxCol.enabled = true;

            //はるまサウンド用
            Mori_Sound = true;

            // Start reloading
            StartCoroutine(Reload());
        }
    }

    public void RaleseMori()
    {
        boxCol.enabled = false;
    }

    private IEnumerator Reload()
    {
        reloading = true;
        // 0.5秒待機（必要に応じて調整してください）
        yield return new WaitForSeconds(0.3f);
        reloading = false;
    }
}