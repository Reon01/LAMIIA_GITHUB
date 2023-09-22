using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlyerInterction : MonoBehaviour
{
    PlayerInput _input;


    private float countTime;�@�@�@�@�@ //�^�C�}�[

    private float attackCount;

    [Tooltip("�N�[���^�C��")]
    [SerializeField] float CoolTime;

    [Tooltip("�U���N�[���^�C��")]
    [SerializeField] float attackCoolTime;

    [Tooltip("�ړ��X�N���v�g")]
    public PlayerControllerInput _moveAction;

    [Tooltip("�X�L���擾�X�N���v�g")]
    public InputGetSkill _getSkill;

    [Tooltip("�J�W�L���˃X�N���v�g")]
    public InputKajiki _shotKajiki;

    [Tooltip("�J�W�L���˃X�N���v�g�V�[��04")]
    public InputKajikiScne04 _shotKajikiScene04;

    [Tooltip("�N���Q�V�[���h�I�X�N���v�g")]
    public InputKurage _kurage;

    [Tooltip("�N���Q�V�[���h�V�[��4")]
    public InputKurageScene04 _kurageScene04;

    [Tooltip("�E�i�M�X�N���v�g")]
    public InputSkillElectronic _unagi;

    [Tooltip("�V�[��4�E�i�M�X�N���v�g")]
    public InputElectronicScene4 _unagiScene4;

    [Tooltip("�X�L���`�F���W")]
    public INputSkillChange _skillChange;

    [Tooltip("�X�L���`�F���W�V�[���S")]
    public InputSkillChangeScene04 _skillChangeScene04;

    [Tooltip("�����U��")]
    public InputMoriAttack _moriAttack;

    [Tooltip("���j���[")]
    public EscSystem _manyu;

    [Tooltip("���j���[")]
    public EscSystemTute _manyuTute;


    //�{�^��

    private InputAction _buttonAction;


    //�͂�܃T�E���h�p
    public static bool Kajiki_Sound = false;


    private void Awake()
    {
        TryGetComponent(out _input);


        _buttonAction = _input.actions.FindAction("MoriAttack");


    }

    private void Update()
    {
        if (_input.actions["UpMove"].ReadValue<float>() > 0f)
        {
            _moveAction.UpMove();

            Debug.Log("UP");

        }

        else if(_input.actions["DownMove"].ReadValue<float>() > 0f)
        {
            _moveAction.DownMOve();
        }

        //�{�^���������ꂽ�u��
        if (_buttonAction.WasPressedThisFrame())
        {

            _moveAction.FirstAttack();


            //�����R���C�_�[��True�ɂ���
            _moriAttack.MoriAttack();
                  
        }
        

        // �{�^���������ꂽ�u��
        if (_buttonAction.WasReleasedThisFrame())
        {

            //�����̃R���C�_�[��False�ɂ���
            _moriAttack.RaleseMori();
        }

        countTime += Time.deltaTime;
        attackCount += Time.deltaTime;

        //Debug.Log(attackCount);
    }

    private void OnEnable()
    {
        //�ړ�
        _input.actions["Move"].performed += OnMove;
        _input.actions["Move"].canceled += OnMoveStop;

        //���
        _input.actions["Avoidance"].started += OnAvoidance;

        //�X�L���擾
        _input.actions["GetSkill"].started += OnGetSkill;

        //�X�L���`�F���W
        _input.actions["SkillChange"].started += OnSkillChange;

        //�X�L���`�F���W�V�[��04
        _input.actions["SkillChange"].started += OnSkillChangeScene04;

        //�J�W�L����
        _input.actions["Fire"].started += OnShotKajiki;


        //�J�W�L���˃V�[��04
        _input.actions["Fire"].started += OnShotKajikiScene04;

        
        //�N���Q�V�[���h
        _input.actions["Fire"].started += OnKurage;

        //�N���Q�V�[���h�V�[��4
        _input.actions["Fire"].started += OnKurageScene04;

        //�d�C�E�i�M
        _input.actions["Fire"].started += OnErectronic;

        _input.actions["Unagi"].started += OnErectronic;

        //�d�C�E�i�M�V�[��4
        _input.actions["Fire"].started += OnEretronicSecene4;

        _input.actions["Unagi"].started += OnEretronicSecene4;

        //���C�����j���[
        _input.actions["MainManyu"].started += OnManyu;

        //���C�����j���[�V�[��4
        _input.actions["MainManyu"].started += OnManyuScene4;


    }


    private void OnDisable()
    {
        //�ړ�
        _input.actions["Move"].performed -= OnMove;
        _input.actions["Move"].canceled -= OnMoveStop;

        //���
        _input.actions["Avoidance"].started -= OnAvoidance;

        //�X�L���擾
        _input.actions["GetSkill"].started -= OnGetSkill;

        //�X�L���`�F���W
        _input.actions["SkillChange"].started -= OnSkillChange;

        //�X�L���`�F���W�V�[��04
        _input.actions["SkillChange"].started -= OnSkillChangeScene04;


        //�N���Q�V�[���h
        _input.actions["Fire"].started -= OnKurage;

        //�N���Q�V�[���h�V�[��4
        _input.actions["Fire"].started -= OnKurageScene04;

        //�J�W�L����
        _input.actions["Fire"].started -= OnShotKajiki;

        //�J�W�L���˃V�[��04
        _input.actions["Fire"].started -= OnShotKajikiScene04;


        //�d�C�E�i�M
        _input.actions["Fire"].started -= OnErectronic;

        _input.actions["Unagi"].started += OnErectronic;

        //�d�C�E�i�M�V�[��4
        _input.actions["Fire"].started -= OnEretronicSecene4;

        _input.actions["Unagi"].started += OnEretronicSecene4;

        //���C�����j���[
        _input.actions["MainManyu"].started -= OnManyu;

        //���C�����j���[�V�[��4
        _input.actions["MainManyu"].started -= OnManyuScene4;


    }

    


    /*----------------------------------------------�@�ړ�------------------------------------------------------*/

    private void OnMove(InputAction.CallbackContext obj)
    {
        var direction = obj.ReadValue<Vector2>();

        _moveAction.MoveSet(direction);

        //�T�E���h�p
        SFXplayer.isPlayerMoving_S = true;
    }

    

    /*----------------------------------------------�@��� ------------------------------------------------------*/

    private void OnAvoidance(InputAction.CallbackContext obj)
    {
        

        if (countTime >= CoolTime)
        {
            countTime = 0;

            _moveAction.Avoidance();

            SFXplayer.Step_Soud = true;

            Debug.Log("���");

        }     
        
    }



    private void OnMoveStop(InputAction.CallbackContext obj)
    {
        _moveAction.MoveSet(Vector3.zero);

        //�T�E���h�p
        SFXplayer.isPlayerMoving_S = false;
    }

    /*----------------------------------------------�@�X�L���擾 ------------------------------------------------------*/

    private void OnGetSkill(InputAction.CallbackContext obj)
    {
        _getSkill.GetSkill();
    }

    /*----------------------------------------------�@�X�L���`�F���W ------------------------------------------------------*/


    private void OnSkillChange(InputAction.CallbackContext obj)
    {
        _skillChange.SkillChange();
    }

    private void OnSkillChangeScene04(InputAction.CallbackContext obj)
    {
        _skillChangeScene04.SkillChangeScene04();
    }


    /*----------------------------------------------�@�J�W�L���� ------------------------------------------------------*/

    private void OnShotKajiki(InputAction.CallbackContext obj)
    {
        Debug.Log("Fire");
        _shotKajiki.KazikiShot();
        //�J�W�L�̉���炷
        Kajiki_Sound = true;

        Debug.Log(Kajiki_Sound);
    }

    private void OnShotKajikiScene04(InputAction.CallbackContext obj)
    {
        _shotKajikiScene04.KajikiScene04();
    }

    /*----------------------------------------------�@�N���Q�V�[���h ------------------------------------------------------*/

    private void OnKurage(InputAction.CallbackContext obj)
    {
        _kurage.SkillKurage();
    }

    private void OnKurageScene04(InputAction.CallbackContext obj)
    {
        _kurageScene04.KurageScene04();
    }

    /*----------------------------------------------�@�d�C�E�i�M ------------------------------------------------------*/

    private void OnErectronic(InputAction.CallbackContext obj)
    {
        _unagi.Electronic();
        SFXplayer.EE_Sound = 2;
    }
    
    private void OnEretronicSecene4(InputAction.CallbackContext obj)
    {
        _unagiScene4.ElectronicScene4();
    }


    /*----------------------------------------------�@���C�����j���[ ------------------------------------------------------*/

    private void OnManyu(InputAction.CallbackContext obj)
    {
        _manyu.MainManyu();
    }

    private void OnManyuScene4(InputAction.CallbackContext obj)
    {
        _manyuTute.MainMnyuu();
    }



}
