using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public GameObject canvas;
    public Slider slider_timer;
    public Text text_timer; //�e�L�X�g�Ŏ��ԕ\�L

    //�v���C���[��HP�\��
    public GameObject hpcanvas;

    //�G�o��
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
        text_timer.text = "�c�莞�ԁF" + timer.ToString("f0"); //�e�L�X�g�Ŏc�莞�ԕ\�L

        if (timer <= 0)
        {
            canvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
