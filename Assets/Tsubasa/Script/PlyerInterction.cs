using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlyerInterction : MonoBehaviour
{
    PlayerInput _input;

    public PlayerControllerInput _moveAction;

    private void Awake()
    {
        TryGetComponent(out _input);

    }

    private void OnEnable()
    {
        _input.actions["Move"].performed += OnMove;
        _input.actions["Move"].canceled += OnMoveStop;
    }


    private void OnDisable()
    {
        _input.actions["Move"].started -= OnMove;
        _input.actions["Move"].canceled += OnMoveStop;
    }


    private void OnMove(InputAction.CallbackContext obj)
    {
        var direction = obj.ReadValue<Vector2>();

        _moveAction.MoveSet(direction);

    }

    private void OnMoveStop(InputAction.CallbackContext obj)
    {
        _moveAction.MoveSet(Vector3.zero);
    }


}
