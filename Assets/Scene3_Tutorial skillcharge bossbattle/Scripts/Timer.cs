using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public GameObject canvas;
    public Slider slider_timer;
    public Text text_timer; //テキストで時間表記

    //プレイヤーのHP表示
    public GameObject hpcanvas;

    //敵出現
    public GameObject enemybattlesystem;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        hpcanvas.SetActive(true);
        enemybattlesystem.SetActive(true);
        player = GameObject.Find("Player");
        player.GetComponent<PlayerHP>().maxheal();
        timer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        slider_timer.value = timer;
        text_timer.text = "残り時間：" + timer.ToString("f0"); //テキストで残り時間表記

        if (timer <= 0)
        {
            canvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
