using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairChange : MonoBehaviour
{
    [SerializeField]
    public Image Crosshair;          //�N���X�w�A�̐ݒ�@Canvas�ł���Ă�Ȃ炱�̂܂܂ŁuAim�v��ς��邾��

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.red, 0.0f);
        if (Physics.Raycast(ray, out hit, 60.0f))
        {
            string hittag = hit.collider.tag;
            if ((hittag.Equals("Enemy")))�@//�G�ɕK����������̃^�O�����āI�����ł͓G�ɁuEnemy�v�̃^�O�����Ă�
            {
                Crosshair.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);�@//�G�Ɍ�������ԐF
            }
            else
            {
                Crosshair.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);�@//����ȊO���F
            }
        }
        else
        {
            Crosshair.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);�@//����ȊO���F
        }
    }
}
