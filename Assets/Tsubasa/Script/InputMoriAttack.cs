using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoriAttack : MonoBehaviour
{
    private Animator animator;
    private string AttackStr = "Attack";
    private bool reloading = false;  // To control reloading

    //�͂�܃T�E���h�p�ϐ�
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

            //�͂�܃T�E���h�p
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
        // 0.5�b�ҋ@�i�K�v�ɉ����Ē������Ă��������j
        yield return new WaitForSeconds(0.3f);
        reloading = false;
    }
}