using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float HP = 100;
    public Slider HPBar;
    public GameObject Enemy;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //éÄÇ èàóù
        if (HP <= 0)
        {
            Destroy(Enemy);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (Player.GetComponent<SkillElectronic>().IsLightning == false)
            {
                HP = HP - 10;
                HPBar.value = HP;
            }
            if (Player.GetComponent<SkillElectronic>().IsLightning == true)
            {
                HP = HP - 20;
                HPBar.value = HP;
            }
        }
    }
}
