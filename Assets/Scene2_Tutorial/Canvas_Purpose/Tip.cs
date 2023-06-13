using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{
    public GameObject w;
    public GameObject s;
    public GameObject a;
    public GameObject d;
    public GameObject space;
    public GameObject ctrl;
    public GameObject mouse;
    public GameObject correct;
    public GameObject nextcanvas;
    public GameObject panel;
    private int step;
    private float count;
    private bool iscount;

    // Start is called before the first frame update
    void Start()
    {
        W();
        step = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ステップに応じてキーを押すことで次に進む
        if (Input.GetKeyDown(KeyCode.W)&&step == 0)
        {
            showcorrect();//正解の円を出す
            Invoke(nameof(S), 2f);//２秒後に次のステップに進む
        }
        if (Input.GetKeyDown(KeyCode.S)&&step == 1)
        {
            showcorrect();
            Invoke(nameof(A), 2f);
        }
        if (Input.GetKeyDown(KeyCode.A)&&step == 2)
        {
            showcorrect();
            Invoke(nameof(D), 2f);
        }
        if (Input.GetKeyDown(KeyCode.D) && step == 3)
        {
            showcorrect();
            Invoke(nameof(Space), 2f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && step == 4)
        {
            showcorrect();
            Invoke(nameof(Ctrl), 2f);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && step == 5)
        {
            showcorrect();
            Invoke(nameof(Mouse), 2f);
            iscount = true;
        }
        //マウスの動きは、５秒のカウントをしたら丸が出るようにする
        if (iscount == true)
        {
            count += Time.deltaTime;
            if (count >= 5)
            {
                showcorrect();
                Invoke(nameof(end), 2f);
                count = 0;
                iscount = false;
            }
        }
    }

    void showcorrect()
    {
        correct.SetActive(true);//丸を出す
    }

    void W()
    {
        w.SetActive(true);
    }
    void S()
    {
        s.SetActive(true);
        w.SetActive(false);
        correct.SetActive(false);
        step = 1;
    }
    void A()
    {
        a.SetActive(true);
        s.SetActive(false);
        correct.SetActive(false);
        step = 2;
    }
    void D()
    {
        d.SetActive(true);
        a.SetActive(false);
        correct.SetActive(false);
        step = 3;
    }
    void Space()
    {
        space.SetActive(true);
        d.SetActive(false);
        correct.SetActive(false);
        step = 4;
    }
    void Ctrl()
    {
        ctrl.SetActive(true);
        space.SetActive(false);
        correct.SetActive(false);
        step = 5;
    }
    void Mouse()
    {
        mouse.SetActive(true);
        ctrl.SetActive(false);
        correct.SetActive(false);
        step = 6;
    }
    void end()
    {
        mouse.SetActive(false);
        correct.SetActive(false);
        step = 7;
        nextcanvas.SetActive(true);
        panel.SetActive(false);
        gameObject.GetComponent<Tip>().enabled = false;
    }
}
