using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlyerInterction : MonoBehaviour
{
    PlayerInput _input;


    private float countTime;　　　　　 //タイマー

    private float attackCount;

    [Tooltip("クールタイム")]
    [SerializeField] float CoolTime;

    [Tooltip("攻撃クールタイム")]
    [SerializeField] float attackCoolTime;

    [Tooltip("移動スクリプト")]
    public PlayerControllerInput _moveAction;

    [Tooltip("スキル取得スクリプト")]
    public InputGetSkill _getSkill;

    [Tooltip("カジキ発射スクリプト")]
    public InputKajiki _shotKajiki;

    [Tooltip("カジキ発射スクリプトシーン04")]
    public InputKajikiScne04 _shotKajikiScene04;

    [Tooltip("クラゲシールド！スクリプト")]
    public InputKurage _kurage;

    [Tooltip("クラゲシールドシーン4")]
    public InputKurageScene04 _kurageScene04;

    [Tooltip("ウナギスクリプト")]
    public InputSkillElectronic _unagi;

    [Tooltip("シーン4ウナギスクリプト")]
    public InputElectronicScene4 _unagiScene4;

    [Tooltip("スキルチェンジ")]
    public INputSkillChange _skillChange;

    [Tooltip("スキルチェンジシーン４")]
    public InputSkillChangeScene04 _skillChangeScene04;

    [Tooltip("モリ攻撃")]
    public InputMoriAttack _moriAttack;

    [Tooltip("メニュー")]
    public EscSystem _manyu;

    [Tooltip("メニュー")]
    public EscSystemTute _manyuTute;


    //ボタン

    private InputAction _buttonAction;


    //はるまサウンド用
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

        //ボタンが押された瞬間
        if (_buttonAction.WasPressedThisFrame())
        {

            _moveAction.FirstAttack();


            //モリコライダーをTrueにする
            _moriAttack.MoriAttack();
                  
        }
        

        // ボタンが離された瞬間
        if (_buttonAction.WasReleasedThisFrame())
        {

            //モリのコライダーをFalseにする
            _moriAttack.RaleseMori();
        }

        countTime += Time.deltaTime;
        attackCount += Time.deltaTime;

        //Debug.Log(attackCount);
    }

    private void OnEnable()
    {
        //移動
        _input.actions["Move"].performed += OnMove;
        _input.actions["Move"].canceled += OnMoveStop;

        //回避
        _input.actions["Avoidance"].started += OnAvoidance;

        //スキル取得
        _input.actions["GetSkill"].started += OnGetSkill;

        //スキルチェンジ
        _input.actions["SkillChange"].started += OnSkillChange;

        //スキルチェンジシーン04
        _input.actions["SkillChange"].started += OnSkillChangeScene04;

        //カジキ発射
        _input.actions["Fire"].started += OnShotKajiki;


        //カジキ発射シーン04
        _input.actions["Fire"].started += OnShotKajikiScene04;

        
        //クラゲシールド
        _input.actions["Fire"].started += OnKurage;

        //クラゲシールドシーン4
        _input.actions["Fire"].started += OnKurageScene04;

        //電気ウナギ
        _input.actions["Fire"].started += OnErectronic;

        _input.actions["Unagi"].started += OnErectronic;

        //電気ウナギシーン4
        _input.actions["Fire"].started += OnEretronicSecene4;

        _input.actions["Unagi"].started += OnEretronicSecene4;

        //メインメニュー
        _input.actions["MainManyu"].started += OnManyu;

        //メインメニューシーン4
        _input.actions["MainManyu"].started += OnManyuScene4;


    }


    private void OnDisable()
    {
        //移動
        _input.actions["Move"].performed -= OnMove;
        _input.actions["Move"].canceled -= OnMoveStop;

        //回避
        _input.actions["Avoidance"].started -= OnAvoidance;

        //スキル取得
        _input.actions["GetSkill"].started -= OnGetSkill;

        //スキルチェンジ
        _input.actions["SkillChange"].started -= OnSkillChange;

        //スキルチェンジシーン04
        _input.actions["SkillChange"].started -= OnSkillChangeScene04;


        //クラゲシールド
        _input.actions["Fire"].started -= OnKurage;

        //クラゲシールドシーン4
        _input.actions["Fire"].started -= OnKurageScene04;

        //カジキ発射
        _input.actions["Fire"].started -= OnShotKajiki;

        //カジキ発射シーン04
        _input.actions["Fire"].started -= OnShotKajikiScene04;


        //電気ウナギ
        _input.actions["Fire"].started -= OnErectronic;

        _input.actions["Unagi"].started += OnErectronic;

        //電気ウナギシーン4
        _input.actions["Fire"].started -= OnEretronicSecene4;

        _input.actions["Unagi"].started += OnEretronicSecene4;

        //メインメニュー
        _input.actions["MainManyu"].started -= OnManyu;

        //メインメニューシーン4
        _input.actions["MainManyu"].started -= OnManyuScene4;


    }

    


    /*----------------------------------------------　移動------------------------------------------------------*/

    private void OnMove(InputAction.CallbackContext obj)
    {
        var direction = obj.ReadValue<Vector2>();

        _moveAction.MoveSet(direction);

        //サウンド用
        SFXplayer.isPlayerMoving_S = true;
    }

    

    /*----------------------------------------------　回避 ------------------------------------------------------*/

    private void OnAvoidance(InputAction.CallbackContext obj)
    {
        

        if (countTime >= CoolTime)
        {
            countTime = 0;

            _moveAction.Avoidance();

            SFXplayer.Step_Soud = true;

            Debug.Log("回避");

        }     
        
    }



    private void OnMoveStop(InputAction.CallbackContext obj)
    {
        _moveAction.MoveSet(Vector3.zero);

        //サウンド用
        SFXplayer.isPlayerMoving_S = false;
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

    private void OnSkillChangeScene04(InputAction.CallbackContext obj)
    {
        _skillChangeScene04.SkillChangeScene04();
    }


    /*----------------------------------------------　カジキ発射 ------------------------------------------------------*/

    private void OnShotKajiki(InputAction.CallbackContext obj)
    {
        Debug.Log("Fire");
        _shotKajiki.KazikiShot();
        //カジキの音を鳴らす
        Kajiki_Sound = true;

        Debug.Log(Kajiki_Sound);
    }

    private void OnShotKajikiScene04(InputAction.CallbackContext obj)
    {
        _shotKajikiScene04.KajikiScene04();
    }

    /*----------------------------------------------　クラゲシールド ------------------------------------------------------*/

    private void OnKurage(InputAction.CallbackContext obj)
    {
        _kurage.SkillKurage();
    }

    private void OnKurageScene04(InputAction.CallbackContext obj)
    {
        _kurageScene04.KurageScene04();
    }

    /*----------------------------------------------　電気ウナギ ------------------------------------------------------*/

    private void OnErectronic(InputAction.CallbackContext obj)
    {
        _unagi.Electronic();
        SFXplayer.EE_Sound = 2;
    }
    
    private void OnEretronicSecene4(InputAction.CallbackContext obj)
    {
        _unagiScene4.ElectronicScene4();
    }


    /*----------------------------------------------　メインメニュー ------------------------------------------------------*/

    private void OnManyu(InputAction.CallbackContext obj)
    {
        _manyu.MainManyu();
    }

    private void OnManyuScene4(InputAction.CallbackContext obj)
    {
        _manyuTute.MainMnyuu();
    }



}
