using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumBossHP : MonoBehaviour
{
    public Slider slider_mediumbosshp;
    private int hp;
    private GameObject mediumbosssystem;
    public GameObject gameclearsystem;

    private GameObject player;

    //���_���[�W�\�L�p
    public GameObject damage10;
    public GameObject damage20;
    public GameObject damage50;
    public float damagecooltime;
    public GameObject damagetextposition;

    // Start is called before the first frame update
    void Start()
    {
        mediumbosssystem = GameObject.Find("MediumBossSystem");
        player = GameObject.Find("Player");
        hp = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            gameclearsystem.SetActive(true);
            Time.timeScale = 0;
            Destroy(mediumbosssystem);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            hp -= 10;
            slider_mediumbosshp.value = hp;
            damagedisplay10(); //�P�O�_���[�W�̃e�L�X�g��\��
        }

        
        //���J�W�L�̏ꍇ50DMG
        if (other.gameObject.CompareTag("KajikiAttack"))
        {
            hp -= 50;
            slider_mediumbosshp.value = hp;
            damagedisplay50();�@//�T�O�_���[�W�̃e�L�X�g��\��
        }
    }

    //�P�O�_���[�W�̃e�L�X�g��\��
    public void damagedisplay10()
    {
        Instantiate(damage10, damagetextposition.transform.position, Quaternion.identity);
    }
    //�Q�O�_���[�W�̃e�L�X�g��\��
    public void damagedisplay20()
    {
        Instantiate(damage20, damagetextposition.transform.position, Quaternion.identity);
    }
    //�T�O�_���[�W�̃e�L�X�g��\��
    public void damagedisplay50()
    {
        Instantiate(damage50, damagetextposition.transform.position, Quaternion.identity);
    }
}
