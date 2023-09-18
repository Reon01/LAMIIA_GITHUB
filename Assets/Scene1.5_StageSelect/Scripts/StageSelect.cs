using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CriWare;

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

    //�T�E���h�p
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    AtomLoader atomLoader;

    public GameObject canvas_stageselect;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("AudioManager").GetComponent<PlayerController>();
        atomLoader = GameObject.Find("AudioManager").GetComponent<AtomLoader>();
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
        //�T�E���h�p
        //GameStart.menu_Sound = 4;
        playerController.SetAcb(atomLoader.acbAssets[1].Handle);
        playerController.SetCueName("Start_JINGLE");
        playerController.MenuSFXPlay();
        
        async = SceneManager.LoadSceneAsync("Scene2_Tutorial_old"); // �V�[���̓ǂݍ��݂�����

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
        //�T�E���h�p
        //GameStart.menu_Sound = 4;
        playerController.SetAcb(atomLoader.acbAssets[1].Handle);
        playerController.SetCueName("Start_JINGLE");
        playerController.MenuSFXPlay();


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
