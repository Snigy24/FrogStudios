using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerCharacter))]
public class PlayerActions : MonoBehaviour
{
    private PlayerInputActions playerInputs;

    private InputAction move;
    private float movementInput;
    private InputAction jump;
    private bool jumpInput;

    private IMoveable moveable;



    private void Awake()
    {
        playerInputs = new PlayerInputActions();
        moveable = GetComponent<IMoveable>();
    }
    
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        move = playerInputs.Player.Move;
        move.Enable();
        
        jump = playerInputs.Player.Jump;
        jump.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }
    
    private void Update()
    {
        movementInput = move.ReadValue<float>();
        jumpInput = jump.ReadValue<float>() > 0f;
        if (movementInput == 0f && !jumpInput) return;
        if (jumpInput) moveable.Jump();
        moveable.Move2D(movementInput);
    }
}
