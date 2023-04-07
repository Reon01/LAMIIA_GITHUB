using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelect : MonoBehaviour
{
    private bool isSkill;
    public GameObject Kajiki_Button;
    public GameObject Kurage_Button;
    public GameObject Unagi_Button;

    public GameObject Canvas_SkillSelect;

    // Start is called before the first frame update
    void Start()
    {
        isSkill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            isSkill = true;

            //カーソル再表示
            Cursor.visible = true;
            //カーソルロックを解除
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (isSkill == true)
        {
            Canvas_SkillSelect.SetActive(true);
            isSkill = false;
        }
    }
}
