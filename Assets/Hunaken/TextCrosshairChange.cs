using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextCrosshairChange : MonoBehaviour
{
    [SerializeField]
    public Text Text_Crosshair;          //�N���X�w�A�̐ݒ�@Canvas�ł���Ă�Ȃ炱�̂܂܂ŁuAim�v��ς��邾��

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.red, 0.0f);
      
        if (Physics.Raycast(ray, out hit))
        {
            
            if ((hit.transform.CompareTag("Enemy")))�@
            {
                Text_Crosshair.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);�@//�G�Ɍ�������ԐF
            }

            else if ((hit.transform.CompareTag("Boss")))�@
            {
                Text_Crosshair.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);�@//�G�Ɍ�������ԐF
            }

            else
            {
                Text_Crosshair.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);�@//����ȊO���F
            }
        }
        else
        {
            Text_Crosshair.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);�@//����ȊO���F
        }
    }
}