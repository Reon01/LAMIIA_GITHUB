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

    public GameObject panel;
    public GameObject tip;
    public GameObject HP;

    // Start is called before the first frame update
    void Start()
    {
        textLabel.text = charaName + "\n" + word[num];
        Time.timeScale = 0;

        //サウンド用
        SFXplayer.radio_Sound = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(1) || 
            Input.GetKeyDown(KeyCode.Space))
        {
            //サウンド用
            SFXplayer.radio_Sound_obs = true;

            if (num == word.Length - 1)
            {
                //サウンド用
                SFXplayer.radio_Sound = 3;
                
                this.gameObject.SetActive(false);
                Time.timeScale = 1;
                panel.SetActive(true);
                tip.SetActive(true);
                HP.SetActive(true);

                return;
            }

            num += 1;

            textLabel.text = charaName + "\n" + word[num];
        }
    }
}
