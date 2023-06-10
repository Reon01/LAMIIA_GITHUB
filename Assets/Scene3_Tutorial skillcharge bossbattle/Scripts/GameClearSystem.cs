using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearSystem : MonoBehaviour
{
    public GameObject cleartext;
    public GameObject button_next;

    // Start is called before the first frame update
    void Start()
    {
        cleartext.SetActive(true);
        button_next.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void next()
    {
        SceneManager.LoadScene("Scene1.5_StageSelect");
    }

    public void startscene()
    {
        SceneManager.LoadScene("Scene1_Start");
    }
}
