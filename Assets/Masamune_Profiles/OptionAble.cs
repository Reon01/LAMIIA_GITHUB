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

    private void OnEnable()//���Ă�I�u�W�F�N�g���A�N�e�B�u�ȂƂ�
    {
        Time.timeScale = 0;
    }
    private void OnDisable()//�A�N�e�B�u����Ȃ��Ƃ�
    {
        
            Time.timeScale = 1;
        
       
    }
}
