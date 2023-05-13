using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text textLabel;
    public string charaName;
    public string[] word;
    private int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        textLabel.text = charaName + "\n" + word[num];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (num == word.Length - 1)
            {
                this.gameObject.SetActive(false);
                return;
            }

            num += 1;

            textLabel.text = charaName + "\n" + word[num];
        }
    }
}
