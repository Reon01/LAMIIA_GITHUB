using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlyerInterction : MonoBehaviour
{
    PlayerInput _input;

    [Tooltip("移動スクリプト")]
    public PlayerControllerInput _moveAction;

    [Tooltip("スキル取得スクリプト")]
    public InputGetSkill _getSkill;

    [Tooltip("カジキ発射スクリプト")]
    public InputKajiki _shotKajiki;

    [Tooltip("クラゲシールド！スクリプト")]
    public InputKurage _kurage;

    [Tooltip("ウナギスクリプト")]
    public InputSkillElectronic _unagi;

    [Tooltip("スキルチェンジ")]
    public INputSkillChange _skillChange;



    //はるまサウンド用
    public static bool Kajiki_Sound = false;

    private void Awake()
    {
        TryGetComponent(out _input);

    }

    private void OnEnable()
    {
        //移動
        _input.actions["Move"].performed += OnMove;
        _input.actions["Move"].canceled += OnMoveStop;

        //スキル取得
        _input.actions["GetSkill"].started += OnGetSkill;

        //スキルチェンジ
        _input.actions["SkillChange"].started += OnSkillChange;

        //カジキ発射
        _input.actions["Fire"].started += OnShotKajiki;

        //クラゲシールド
        _input.actions["Fire"].started += OnKurage;

        //電気ウナギ
        _input.actions["Fire"].started += OnErectronic;


    }

  

    private void OnDisable()
    {
        //移動
        _input.actions["Move"].performed -= OnMove;
        _input.actions["Move"].canceled -= OnMoveStop;

        //スキル取得
        _input.actions["GetSkill"].started -= OnGetSkill;

        //スキルチェンジ
        _input.actions["SkillChange"].started -= OnSkillChange;

        
        //クラゲシールド
        _input.actions["Fire"].started -= OnKurage;

        //カジキ発射
        _input.actions["Fire"].started -= OnShotKajiki;


        //電気ウナギ
        _input.actions["Fire"].started -= OnErectronic;


    }

    


    /*----------------------------------------------　移動------------------------------------------------------*/

    private void OnMove(InputAction.CallbackContext obj)
    {
        var direction = obj.ReadValue<Vector2>();

        _moveAction.MoveSet(direction);

    }

    private void OnMoveStop(InputAction.CallbackContext obj)
    {
        _moveAction.MoveSet(Vector3.zero);
    }

    /*----------------------------------------------　スキル取得 ------------------------------------------------------*/

    private void OnGetSkill(InputAction.CallbackContext obj)
    {
        _getSkill.GetSkill();
    }

    /*----------------------------------------------　スキルチェンジ ------------------------------------------------------*/


    private void OnSkillChange(InputAction.CallbackContext obj)
    {
        _skillChange.SkillChange();
    }


    /*----------------------------------------------　カジキ発射 ------------------------------------------------------*/

    private void OnShotKajiki(InputAction.CallbackContext obj)
    {
        _shotKajiki.KazikiShot();
        //カジキの音を鳴らす
        Kajiki_Sound = true;

        Debug.Log(Kajiki_Sound);
    }

    /*----------------------------------------------　クラゲシールド ------------------------------------------------------*/

    private void OnKurage(InputAction.CallbackContext obj)
    {
        _kurage.SkillKurage();
    }

    /*----------------------------------------------　電気ウナギ ------------------------------------------------------*/

    private void OnErectronic(InputAction.CallbackContext obj)
    {
        _unagi.Electronic();
    }



}
