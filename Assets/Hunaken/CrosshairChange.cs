using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairChange : MonoBehaviour
{
    [SerializeField]
    private Text Aim;          //クロスヘアの設定　Canvasでやってるならこのままで「Aim」を変えるだけ

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.red, 0.0f);
        if (Physics.Raycast(ray, out hit, 30.0f))
        {
            string hittag = hit.collider.tag;
            if ((hittag.Equals("Enemy")))　//敵に必ず何かしらのタグをつけて！ここでは敵に「Enemy」のタグをつけてる
            {
                Aim.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);　//敵に向けたら赤色
            }
            else
            {
                Aim.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);　//それ以外白色
            }
        }
        else
        {
            Aim.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);　//それ以外白色
        }
    }
}
