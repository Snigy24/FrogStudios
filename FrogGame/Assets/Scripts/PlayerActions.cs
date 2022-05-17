using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private PlayerInputActions playerInputs;

    private InputAction move;
    private float movementInput;
    private InputAction jump;
    private bool jumpInput;

    public event Action<float> OnPlayerMoveInput;
    public event Action OnPlayerJumpInput;

    private void Awake()
    {
        playerInputs = new PlayerInputActions();
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
        if (jumpInput) OnPlayerJumpInput?.Invoke();
        if (movementInput != 0f) OnPlayerMoveInput?.Invoke(movementInput);
    }
}
