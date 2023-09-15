using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionAble : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()//つけてるオブジェクトがアクティブなとき
    {
        Time.timeScale = 0;
    }
    private void OnDisable()//アクティブじゃないとき
    {
        
            Time.timeScale = 1;
        
       
    }
}
