using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    //�@�񓯊�����Ŏg�p����AsyncOperation
    private AsyncOperation async;
    //�@�V�[�����[�h���ɕ\������UI���
    [SerializeField]
    private GameObject loadUI;
    //�@�ǂݍ��ݗ���\������X���C�_�[
    [SerializeField]
    private Slider slider;

    public GameObject canvas_stageselect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadingTutorial()
    {
        // �Z���N�g�{�^�����\��
        canvas_stageselect.SetActive(false);

        //�@���[�h���UI���A�N�e�B�u�ɂ���
        loadUI.SetActive(true);

        //�@�R���[�`�����J�n
        StartCoroutine("Tutorial");
    }

    IEnumerator Tutorial()
    {
        GameStart.menu_Sound = 4;
        async = SceneManager.LoadSceneAsync("Scene2_Tutorial"); // �V�[���̓ǂݍ��݂�����

        //�@�ǂݍ��݂��I���܂Ői���󋵂��X���C�_�[�̒l�ɔ��f������
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }

    public void LoadingMainStage()
    {
        // �Z���N�g�{�^�����\��
        canvas_stageselect.SetActive(false);

        //�@���[�h���UI���A�N�e�B�u�ɂ���
        loadUI.SetActive(true);

        //�@�R���[�`�����J�n
        StartCoroutine("MainStage");
    }

    IEnumerator MainStage()
    {
        GameStart.menu_Sound = 4;
        Time.timeScale = 1;
        async = SceneManager.LoadSceneAsync("Scene4_BossStage"); // �V�[���̓ǂݍ��݂�����

        //�@�ǂݍ��݂��I���܂Ői���󋵂��X���C�_�[�̒l�ɔ��f������
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }

    public void Home()
    {
        GameStart.menu_Sound = 2;
        SceneManager.LoadScene("Scene1_Start");
    }
}
