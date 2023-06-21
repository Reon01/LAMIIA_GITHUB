using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ST_SkillSelect : MonoBehaviour
{
    public Button button_kajiki;
    public Button button_kurage;
    public Button button_unagi;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            count += 1;
        }

        if (count == 1)
        {
            kajikicolor();
        }
        if (count == 2)
        {
            kuragecolor();
        }
        if (count == 3)
        {
            unagicolor();
            count = 0;
        }
    }

    public void kajikicolor()
    {
        button_kajiki.image.color = Color.yellow;
        button_unagi.image.color = Color.white;
    }
    public void kuragecolor()
    {
        button_kurage.image.color = Color.yellow;
        button_kajiki.image.color = Color.white;
    }
    public void unagicolor()
    {
        button_unagi.image.color = Color.yellow;
        button_kurage.image.color = Color.white;
    }
}
