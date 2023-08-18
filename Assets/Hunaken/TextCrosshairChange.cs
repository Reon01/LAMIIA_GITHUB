using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextCrosshairChange : MonoBehaviour
{
    [SerializeField]
    public Text Text_Crosshair;          //クロスヘアの設定　Canvasでやってるならこのままで「Aim」を変えるだけ

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.red, 0.0f);
      
        if (Physics.Raycast(ray, out hit))
        {
            
            if ((hit.transform.CompareTag("Enemy")))　
            {
                Text_Crosshair.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);　//敵に向けたら赤色
            }

            else if ((hit.transform.CompareTag("Boss")))　
            {
                Text_Crosshair.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);　//敵に向けたら赤色
            }

            else
            {
                Text_Crosshair.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);　//それ以外白色
            }
        }
        else
        {
            Text_Crosshair.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);　//それ以外白色
        }
    }
}