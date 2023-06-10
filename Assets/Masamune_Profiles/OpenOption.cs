using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOption : MonoBehaviour
{
    public GameObject OptionMenu;
    private bool isOption;
    // Start is called before the first frame update
    void Start()
    {
        isOption = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            {
                isOption = true;


                //カーソル再表示
                Cursor.visible = true;
                //カーソルロックを解除
                Cursor.lockState = CursorLockMode.Confined;
            }



        }
        if (isOption == true)
        {
            OptionMenu.SetActive(!OptionMenu.activeSelf);
            isOption = false;
        }
    }
}
