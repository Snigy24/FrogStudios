using System;
using Unity.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerActions))]
public class PlayerCharacter : Character
{
    [field: SerializeField] public override int Health { get; protected set; }

    private PlayerActions playerActions;

    protected void Awake()
    {
        playerActions = GetComponent<PlayerActions>();
        
        base.Awake();
    }
    
    private void Update()
    {
        
    }

    private void OnEnable()
    {
        playerActions.OnPlayerMoveInput += charPhysics.Move2D;
        playerActions.OnPlayerJumpInput += charPhysics.Jump;
    }

    private void OnDisable()
    {
        playerActions.OnPlayerJumpInput -= charPhysics.Jump;
        playerActions.OnPlayerMoveInput -= charPhysics.Move2D;
    }

    public override void Heal(int amount)
    {
        throw new NotImplementedException();
    }

    public override void TakeDamage(int amount)
    {
        throw new NotImplementedException();
    }

    
    
}