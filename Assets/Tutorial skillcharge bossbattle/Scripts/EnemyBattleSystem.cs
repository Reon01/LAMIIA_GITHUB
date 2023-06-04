using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleSystem : MonoBehaviour
{
    private int enemyamount;
    public GameObject enemy1;

    public float timer;

    //ƒ‰ƒ“ƒ_ƒ€‚ÈˆÊ’u¶¬
    [SerializeField]
    [Tooltip("¶¬‚·‚é”ÍˆÍA")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("¶¬‚·‚é”ÍˆÍB")]
    private Transform rangeB;

    GameObject[] tagObjects; //ƒ^ƒO‚ÌŽæ“¾

    // Start is called before the first frame update
    void Start()
    {
        enemyamount = Random.Range(5, 10);
        tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyamount >= 0)
        {
            enemyspawn();
        }

        /*
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy")); //ŽG‹›“G‚ðŽE‚·
            Debug.Log("ŽG‹›“G”rœ");
        }
        else if (tagObjects.Length == 0)
        {
            timer = 1000000; //‚à‚¤‚P“xŽG‹›“G‚ðŽE‚³‚È‚¢‚æ‚¤‚Éƒ^ƒCƒ}[‚ð‚ß‚Á‚¿‚áL‚Î‚·
            Debug.Log("‘S–Å");
        }
        */
    }

    public void enemyspawn()
    {
        // rangeA‚ÆrangeB‚ÌxÀ•W‚Ì”ÍˆÍ“à‚Åƒ‰ƒ“ƒ_ƒ€‚È”’l‚ðì¬
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeA‚ÆrangeB‚ÌyÀ•W‚Ì”ÍˆÍ“à‚Åƒ‰ƒ“ƒ_ƒ€‚È”’l‚ðì¬
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeA‚ÆrangeB‚ÌzÀ•W‚Ì”ÍˆÍ“à‚Åƒ‰ƒ“ƒ_ƒ€‚È”’l‚ðì¬
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(enemy1, new Vector3(x,y,z), Quaternion.identity);
        enemyamount -= 1;
    }
}
