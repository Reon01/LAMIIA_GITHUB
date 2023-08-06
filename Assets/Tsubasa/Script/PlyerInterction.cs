using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlyerInterction : MonoBehaviour
{
    PlayerInput _input;

    [Tooltip("�ړ��X�N���v�g")]
    public PlayerControllerInput _moveAction;

    [Tooltip("�X�L���擾�X�N���v�g")]
    public InputGetSkill _getSkill;

    [Tooltip("�J�W�L���˃X�N���v�g")]
    public InputKajiki _shotKajiki;

    [Tooltip("�N���Q�V�[���h�I�X�N���v�g")]
    public InputKurage _kurage;

    [Tooltip("�E�i�M�X�N���v�g")]
    public InputSkillElectronic _unagi;

    [Tooltip("�X�L���`�F���W")]
    public INputSkillChange _skillChange;



    //�͂�܃T�E���h�p
    public static bool Kajiki_Sound = false;

    private void Awake()
    {
        TryGetComponent(out _input);

    }

    private void OnEnable()
    {
        //�ړ�
        _input.actions["Move"].performed += OnMove;
        _input.actions["Move"].canceled += OnMoveStop;

        //�X�L���擾
        _input.actions["GetSkill"].started += OnGetSkill;

        //�X�L���`�F���W
        _input.actions["SkillChange"].started += OnSkillChange;

        //�J�W�L����
        _input.actions["Fire"].started += OnShotKajiki;

        //�N���Q�V�[���h
        _input.actions["Fire"].started += OnKurage;

        //�d�C�E�i�M
        _input.actions["Fire"].started += OnErectronic;


    }

  

    private void OnDisable()
    {
        //�ړ�
        _input.actions["Move"].performed -= OnMove;
        _input.actions["Move"].canceled -= OnMoveStop;

        //�X�L���擾
        _input.actions["GetSkill"].started -= OnGetSkill;

        //�X�L���`�F���W
        _input.actions["SkillChange"].started -= OnSkillChange;

        
        //�N���Q�V�[���h
        _input.actions["Fire"].started -= OnKurage;

        //�J�W�L����
        _input.actions["Fire"].started -= OnShotKajiki;


        //�d�C�E�i�M
        _input.actions["Fire"].started -= OnErectronic;


    }

    


    /*----------------------------------------------�@�ړ�------------------------------------------------------*/

    private void OnMove(InputAction.CallbackContext obj)
    {
        var direction = obj.ReadValue<Vector2>();

        _moveAction.MoveSet(direction);

    }

    private void OnMoveStop(InputAction.CallbackContext obj)
    {
        _moveAction.MoveSet(Vector3.zero);
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


    /*----------------------------------------------�@�J�W�L���� ------------------------------------------------------*/

    private void OnShotKajiki(InputAction.CallbackContext obj)
    {
        _shotKajiki.KazikiShot();
        //�J�W�L�̉���炷
        Kajiki_Sound = true;

        Debug.Log(Kajiki_Sound);
    }

    /*----------------------------------------------�@�N���Q�V�[���h ------------------------------------------------------*/

    private void OnKurage(InputAction.CallbackContext obj)
    {
        _kurage.SkillKurage();
    }

    /*----------------------------------------------�@�d�C�E�i�M ------------------------------------------------------*/

    private void OnErectronic(InputAction.CallbackContext obj)
    {
        _unagi.Electronic();
    }



}
