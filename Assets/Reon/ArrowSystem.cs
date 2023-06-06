using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSystem : MonoBehaviour
{
    public GameObject arrow;
    public GameObject enemyarrow;
    public GameObject kajikiarrow;
    public GameObject allarrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            EnemyArrow();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            KajikiArrow();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            AllArrow();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            CloseArrow();
        }
    }

    void EnemyArrow()
    {
        arrow.SetActive(true);
        Vector3 point = enemyarrow.transform.position;
        arrow.transform.position = point;
    }

    void KajikiArrow()
    {
        arrow.SetActive(true);
        Vector3 point = kajikiarrow.transform.position;
        arrow.transform.position = point;
    }

    void AllArrow()
    {
        allarrow.SetActive(true);
    }

    void CloseArrow()
    {
        arrow.SetActive(false);
        allarrow.SetActive(false);
    }
}
